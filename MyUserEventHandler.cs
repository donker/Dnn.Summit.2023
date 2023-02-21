using DotNetNuke.Entities.Users;
using System.ComponentModel.Composition;

namespace DnnSummit2023
{
  [Export(typeof(IUserEventHandlers))]
  public class MyUserEventHandler : MyEventHandler, IUserEventHandlers
  {
    public void UserApproved(object sender, UserEventArgs args)
      => SendMessage("user/approved", args);

    public void UserAuthenticated(object sender, UserEventArgs args)
      => SendMessage("user/authenticated", args);

    public void UserCreated(object sender, UserEventArgs args)
      => SendMessage("user/created", args);

    public void UserDeleted(object sender, UserEventArgs args)
      => SendMessage("user/deleted", args);

    public void UserRemoved(object sender, UserEventArgs args)
      => SendMessage("user/removed", args);

    public void UserUpdated(object sender, UpdateUserEventArgs args)
      => SendMessage("user/updated", args);
  }
}
