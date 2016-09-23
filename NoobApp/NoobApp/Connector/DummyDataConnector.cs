using NoobApp.Entity;
using NoobApp.Model;
using System;
using System.ComponentModel;

namespace NoobApp.Connector {
  public static class DummyDataConnector {

    public static void PopulateDatabase() {
      var random = new Random();
      foreach (var user in GetUserList()) {
        Global.DataService.Users.Add(user);
      }

      foreach (var item in GetItemList()) {
        Global.DataService.Items.Add(item);
      }

      foreach (var _event in GetEventList()) {
        Global.DataService.Events.Add(_event);
      }

      foreach (var attendanceType in GetAttendanceTypeList()) {
        Global.DataService.AttendanceTypes.Add(attendanceType);
      }

      Global.DataService.SaveChanges();

      foreach (var _event in Global.DataService.Events.Local) {
        foreach (var attendanceType in Global.DataService.AttendanceTypes.Local) {
          Global.DataService.EventPrices.Add(new EventPrice() {
            EventPriceAttendanceTypeRef = attendanceType,
            EventPriceEventRef = _event,
            EventPriceValue = random.Next(20, 81),
          });
        }
      }

      foreach (var _event in Global.DataService.Events.Local) {
        foreach (var item in Global.DataService.Items.Local) {
          Global.DataService.EventInventories.Add(new EventInventory() {
            EventIntenvotryItemRef = item,
            EventInventoryEventRef = _event,
            EventInventoryPrice = random.Next(1, 6),
          });
        }
      }

      Global.DataService.SaveChanges();

    }

    #region - AttendanceType -

    private static BindingList<AttendanceType> GetAttendanceTypeList() {
      BindingList<AttendanceType> attendanceTypeList = new BindingList<AttendanceType>();

      attendanceTypeList.Add(AttendanceType1);
      attendanceTypeList.Add(AttendanceType2);
      attendanceTypeList.Add(AttendanceType3);

      return attendanceTypeList;
    }

    private static AttendanceType AttendanceType1 {
      get {
        return new AttendanceType() {
          AttendanceTypeId = 1,
          AttendanceTypeName = "1 Nacht",
        };
      }
    }

    private static AttendanceType AttendanceType2 {
      get {
        return new AttendanceType() {
          AttendanceTypeId = 2,
          AttendanceTypeName = "2 Nächte",
        };
      }
    }

    private static AttendanceType AttendanceType3 {
      get {
        return new AttendanceType() {
          AttendanceTypeId = 3,
          AttendanceTypeName = "3 Nächte",
        };
      }
    }

    #endregion

    #region - Event -

    private static BindingList<Entity.Event> GetEventList() {
      BindingList<Entity.Event> eventList = new BindingList<Entity.Event>();

      eventList.Add(Event1);
      eventList.Add(Event2);

      return eventList;
    }

    private static Entity.Event Event1 {
      get {
        return new Entity.Event() {
          EventId = 1,
          EventName = "NoobLan2016.2",
          EventStartDate = new DateTime(2016, 10, 13),
          EventEndDate = new DateTime(2016, 10, 16),
        };
      }
    }

    private static Entity.Event Event2 {
      get {
        return new Entity.Event() {
          EventId = 2,
          EventName = "NoobLand2017.1",
          EventStartDate = new DateTime(2017, 03, 01),
          EventEndDate = new DateTime(2017, 03, 04),
        };
      }
    }

    #endregion

    #region - Item -

    private static BindingList<Item> GetItemList() {
      BindingList<Item> itemList = new BindingList<Item>();

      itemList.Add(Item1);
      itemList.Add(Item2);
      itemList.Add(Item3);
      itemList.Add(Item4);
      itemList.Add(Item5);

      return itemList;
    }

    private static Item Item1 {
      get {
        return new Item() {
          ItemId = 1,
          ItemName = "Coca Cola",
        };
      }
    }

    private static Item Item2 {
      get {
        return new Item() {
          ItemId = 2,
          ItemName = "Coca Cola Zero",
        };
      }
    }

    private static Item Item3 {
      get {
        return new Item() {
          ItemId = 3,
          ItemName = "MBudget Energy Drink",
        };
      }
    }

    private static Item Item4 {
      get {
        return new Item() {
          ItemId = 4,
          ItemName = "Pizza Prosciutto",
        };
      }
    }

    private static Item Item5 {
      get {
        return new Item() {
          ItemId = 5,
          ItemName = "Snickers",
        };
      }
    }

    #endregion

    #region - User -

    private static BindingList<User> GetUserList() {
      BindingList<User> userList = new BindingList<User>();

      userList.Add(User1);
      userList.Add(User2);
      userList.Add(User3);
      userList.Add(User4);
      userList.Add(User5);
      userList.Add(User6);

      return userList;
    }

    private static User User1 {
      get {
        return new User() {
          UserId = 1,
          UserFirstName = "Pascal",
          UserLastName = "Schneider",
          UserDisplayName = "Bachtoldi",
        };
      }
    }

    private static User User2 {
      get {
        return new User() {
          UserId = 2,
          UserFirstName = "Michi",
          UserLastName = "Rickli",
          UserDisplayName = "Gnorsh",
        };
      }
    }

    private static User User3 {
      get {
        return new User() {
          UserId = 3,
          UserFirstName = "Beni",
          UserLastName = "Käslin",
          UserDisplayName = "Prelmoid",
        };
      }
    }

    private static User User4 {
      get {
        return new User() {
          UserId = 4,
          UserFirstName = "Donat",
          UserLastName = "Roduner",
          UserDisplayName = "Skatanic",
        };
      }
    }

    private static User User5 {
      get {
        return new User() {
          UserId = 5,
          UserFirstName = "Oli",
          UserLastName = "Bachem",
          UserDisplayName = "DrNoEscape",
        };
      }
    }

    private static User User6 {
      get {
        return new User() {
          UserId = 6,
          UserFirstName = "Lukas",
          UserLastName = "Tuggener",
          UserDisplayName = "Schnidlauch",
        };
      }
    }

    #endregion

  }
}
