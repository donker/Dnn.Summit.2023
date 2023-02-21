using DotNetNuke.UI.Skins.EventListeners;
using System.Web;

namespace DnnSummit2023
{
  public class MySkinEventHandler : MyEventHandler
  {
    public static void OnSkinLoad(object sender, SkinEventArgs e)
    {
      SendMessage("page/load", new
      {
        t = HttpContext.Current.Request.QueryString["TabId"],
        l = System.Threading.Thread.CurrentThread.CurrentCulture.Name,
        u = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo()
      });
    }
  }
}
