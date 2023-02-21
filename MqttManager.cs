using DotNetNuke.Framework;
using DotNetNuke.Instrumentation;
using Newtonsoft.Json;
using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;

namespace DnnSummit2023
{
  public class MqttManager : ServiceLocator<IMqttManager, MqttManager>, IMqttManager
  {
    private MqttClient client { get; set; }
    private AppSettings settings { get; set; }
    private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(MqttManager));

    protected override Func<IMqttManager> GetFactory()
    {
      return () => new MqttManager();
    }

    public MqttManager()
    {
      try
      {
        settings = AppSettings.GetAppSettings();
        if (!string.IsNullOrEmpty(settings.MqttServer))
        {
          client = new MqttClient(settings.MqttServer, settings.MqttPort, false, null, MqttSslProtocols.None);
          this.Reconnect();
        }
      }
      catch (Exception ex)
      {
        DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Couldn't connect to MQTT server", ex));
      }
    }

    public void SendMessage(string topic, object message)
    {
      try
      {
        if (!client.IsConnected)
        {
          this.Reconnect();
        }
        client.Publish(topic, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
      }
      catch (Exception ex)
      {
        Logger.Error($"Error sending MQTT message");
        DotNetNuke.Services.Exceptions.Exceptions.LogException(new Exception("Couldn't send message to MQTT server", ex));
      }
    }

    private void Reconnect()
    {
      client.Connect((new Guid()).ToString());
    }
  }

  public interface IMqttManager
  {
    void SendMessage(string topic, object message);
  }
}
