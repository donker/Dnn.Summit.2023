using System.IO;

namespace DnnSummit2023
{
  public static class Globals
  {
    public static void SaveObject(string filename, object objectToSave)
    {
      using (var sw = new StreamWriter(filename))
      {
        sw.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(objectToSave, Newtonsoft.Json.Formatting.Indented));
      }
    }
    public static T GetObject<T>(string filename, T defaultObject)
    {
      T res = defaultObject;
      if (File.Exists(filename))
      {
        using (var sr = new StreamReader(filename))
        {
          var list = sr.ReadToEnd();
          res = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(list);
        }
      }
      return res;
    }
  }
}