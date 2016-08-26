using NoobApp.Entity;
using System.Collections.Generic;
using System.ComponentModel;

namespace NoobApp.Connector {
  public static class DummyDataConnector {

    public static BindingList<User> GetUserList() {
      BindingList<User> userList = new BindingList<User>();

      userList.Add(new User() { UserId = 1, UserFirstName = "Pascal", UserLastName = "Schneider", UserDisplayName = "BACHTOLDI", });
      userList.Add(new User() { UserId = 2, UserFirstName = "Michi", UserLastName = "Rickli", UserDisplayName = "Gnorsh", });
      userList.Add(new User() { UserId = 3, UserFirstName = "Beni", UserLastName = "Käslin", UserDisplayName = "Prelmoid", });
      userList.Add(new User() { UserId = 4, UserFirstName = "Donat", UserLastName = "Roduner", UserDisplayName = "Skatanic", });
      userList.Add(new User() { UserId = 5, UserFirstName = "Oli", UserLastName = "Bachem", UserDisplayName = "DrNoEscape", });
      userList.Add(new User() { UserId = 6, UserFirstName = "Lukas", UserLastName = "Tuggener", UserDisplayName = "Schnidlauch", });

      return userList;
    }

  }
}
