using DotNetNuke.Application;
using DotNetNuke.UI.Skins.EventListeners;
using DotNetNuke.Web.Api;

namespace DnnSummit2023
{
  public class Routemapper : IServiceRouteMapper
  {
    public void RegisterRoutes(IMapRoute mapRouteManager)
    {
      DotNetNukeContext.Current.SkinEventListeners.Add(new SkinEventListener(SkinEventType.OnSkinLoad, MySkinEventHandler.OnSkinLoad));
    }
  }
}
