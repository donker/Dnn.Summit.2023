using DotNetNuke.Instrumentation;

namespace DnnSummit2023
{
  public class MyEventHandler
  {
    public static readonly IMqttManager Mqtt = MqttManager.Instance;
    private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(MyEventHandler));

    public static void SendMessage(string topic, object args)
    {
      Logger.Info($"Publishing message to {topic}");
      Mqtt.SendMessage(topic, args);
    }
  }
}
