using DotNetNuke.Common.Utilities;
using System.IO;
using System.Web.Caching;

namespace DnnSummit2023
{
  public class AppSettings
  {
    public string MqttServer { get; set; } = "my.mqtt.server";
    public int MqttPort { get; set; } = 1883;

    public static AppSettings GetAppSettings()
    {
      const string cacheKey = "DnnSummit2023AppSettings";
      return CBO.GetCachedObject<AppSettings>(new CacheItemArgs(cacheKey, CacheItemPriority.Default), GetAppSettingsCallback);
    }

    private static object GetAppSettingsCallback(CacheItemArgs dataArgs)
    {
      var fileName = DotNetNuke.Common.Globals.ApplicationMapPath + "\\Config\\DnnSummit2023.config";
      var res = Globals.GetObject(fileName, new AppSettings());
      if (!File.Exists(fileName))
      {
        Globals.SaveObject(fileName, res);
      }
      return res;
    }
  }
}
