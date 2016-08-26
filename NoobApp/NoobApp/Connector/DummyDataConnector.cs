using NoobApp.Entity;
using System;
using System.ComponentModel;

namespace NoobApp.Connector {
  public static class DummyDataConnector {

    #region - Attendance -

    public static Attendance Attendance1 {
      get {
        return new Attendance() {
          AttendanceId = 1,
          AttendanceEventRef = Event1,
          AttendanceUserRef = User1,
          AttendanceStartDateTime = new DateTime(2016, 10, 13),
          AttendanceEndDateTime = new DateTime(2016, 10, 15),
        };
      }
    }

    #endregion

    #region - AttendanceType -

    public static AttendanceType AttendanceType1 {
      get {
        return new AttendanceType() {
          AttendanceTypeId = 1,
          AttendanceTypeName = "1 Nacht",
        };
      }
    }

    public static AttendanceType AttendanceType2 {
      get {
        return new AttendanceType() {
          AttendanceTypeId = 2,
          AttendanceTypeName = "2 Nächte",
        };
      }
    }

    public static AttendanceType AttendanceType3 {
      get {
        return new AttendanceType() {
          AttendanceTypeId = 3,
          AttendanceTypeName = "3 Nächte",
        };
      }
    }

    #endregion

    #region - Event -

    public static Entity.Event Event1 {
      get {
        return new Entity.Event() {
          EventId = 1,
          EventName = "NoobLan2016.2",
          EventStartDate = new DateTime(2016, 10, 13),
          EventEndDate = new DateTime(2016, 10, 16),
        };
      }
    }

    public static Entity.Event Event2 {
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

    #region - EventInventory -

    public static EventInventory EventInventory1 {
      get {
        return new EventInventory() {
          EventInventoryId = 1,
          EventInventoryEventRef = Event1,
          EventIntenvotryItemRef = Item1,
          EventInventoryPrice = 2,
        };
      }
    }

    public static EventInventory EventInventory2 {
      get {
        return new EventInventory() {
          EventInventoryId = 2,
          EventInventoryEventRef = Event1,
          EventIntenvotryItemRef = Item2,
          EventInventoryPrice = 2,
        };
      }
    }

    public static EventInventory EventInventory3 {
      get {
        return new EventInventory() {
          EventInventoryId = 3,
          EventInventoryEventRef = Event1,
          EventIntenvotryItemRef = Item3,
          EventInventoryPrice = 2,
        };
      }
    }

    public static EventInventory EventInventory4 {
      get {
        return new EventInventory() {
          EventInventoryId = 4,
          EventInventoryEventRef = Event1,
          EventIntenvotryItemRef = Item4,
          EventInventoryPrice = 5,
        };
      }
    }

    public static EventInventory EventInventory5 {
      get {
        return new EventInventory() {
          EventInventoryId = 5,
          EventInventoryEventRef = Event1,
          EventIntenvotryItemRef = Item5,
          EventInventoryPrice = 1,
        };
      }
    }

    #endregion

    #region - EventPrice -

    public static EventPrice EventPrice1 {
      get {
        return new EventPrice() {
          EventPriceId = 1,
          EventPriceEventRef = Event1,
          EventPriceAttendanceTypeRef = AttendanceType1,
          EventPriceValue = 30,
        };
      }
    }

    public static EventPrice EventPrice2 {
      get {
        return new EventPrice() {
          EventPriceId = 2,
          EventPriceEventRef = Event1,
          EventPriceAttendanceTypeRef = AttendanceType2,
          EventPriceValue = 50,
        };
      }
    }

    public static EventPrice EventPrice3 {
      get {
        return new EventPrice() {
          EventPriceId = 3,
          EventPriceEventRef = Event1,
          EventPriceAttendanceTypeRef = AttendanceType3,
          EventPriceValue = 70,
        };
      }
    }

    #endregion

    #region - Item -

    public static Item Item1 {
      get {
        return new Item() {
          ItemId = 1,
          ItemName = "Coca Cola",
        };
      }
    }

    public static Item Item2 {
      get {
        return new Item() {
          ItemId = 2,
          ItemName = "Coca Cola Zero",
        };
      }
    }

    public static Item Item3 {
      get {
        return new Item() {
          ItemId = 3,
          ItemName = "MBudget Energy Drink",
        };
      }
    }

    public static Item Item4 {
      get {
        return new Item() {
          ItemId = 4,
          ItemName = "Pizza Prosciutto",
        };
      }
    }

    public static Item Item5 {
      get {
        return new Item() {
          ItemId = 5,
          ItemName = "Snickers",
        };
      }
    }

    #endregion

    #region - Purchase -

    public static Purchase Purchase1 {
      get {
        return new Purchase() {
          PurchaseId = 1,
          PurchaseUserRef = User1,
          PurchaseEventInventoryRef = EventInventory1,
          PurchaseBilled = false,
        };
      }
    }

    public static Purchase Purchase2 {
      get {
        return new Purchase() {
          PurchaseId = 2,
          PurchaseUserRef = User1,
          PurchaseEventInventoryRef = EventInventory4,
          PurchaseBilled = false,
        };
      }
    }

    #endregion

    #region - User -

    public static User User1 {
      get {
        return new User() {
          UserId = 1,
          UserFirstName = "Pascal",
          UserLastName = "Schneider",
          UserDisplayName = "BACHTOLDI",
        };
      }
    }

    public static User User2 {
      get {
        return new User() {
          UserId = 2,
          UserFirstName = "Michi",
          UserLastName = "Rickli",
          UserDisplayName = "Gnorsh",
        };
      }
    }

    public static User User3 {
      get {
        return new User() {
          UserId = 3,
          UserFirstName = "Beni",
          UserLastName = "Käslin",
          UserDisplayName = "Prelmoid",
        };
      }
    }

    public static User User4 {
      get {
        return new User() {
          UserId = 4,
          UserFirstName = "Donat",
          UserLastName = "Roduner",
          UserDisplayName = "Skatanic",
        };
      }
    }

    public static User User5 {
      get {
        return new User() {
          UserId = 5,
          UserFirstName = "Oli",
          UserLastName = "Bachem",
          UserDisplayName = "DrNoEscape",
        };
      }
    }

    public static User User6 {
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

    public static BindingList<Attendance> GetAttendanceList() {
      BindingList<Attendance> attendanceList = new BindingList<Attendance>();

      attendanceList.Add(Attendance1);

      return attendanceList;
    }

    public static BindingList<AttendanceType> GetAttendanceTypeList() {
      BindingList<AttendanceType> attendanceTypeList = new BindingList<AttendanceType>();

      attendanceTypeList.Add(AttendanceType1);
      attendanceTypeList.Add(AttendanceType2);
      attendanceTypeList.Add(AttendanceType3);

      return attendanceTypeList;
    }

    public static BindingList<Entity.Event> GetEventList() {
      BindingList<Entity.Event> eventList = new BindingList<Entity.Event>();

      eventList.Add(Event1);
      eventList.Add(Event2);

      return eventList;
    }

    public static BindingList<EventInventory> GetEventInventoryList() {
      BindingList<EventInventory> eventInventoryList = new BindingList<EventInventory>();

      eventInventoryList.Add(EventInventory1);
      eventInventoryList.Add(EventInventory2);
      eventInventoryList.Add(EventInventory3);
      eventInventoryList.Add(EventInventory4);
      eventInventoryList.Add(EventInventory5);

      return eventInventoryList;
    }

    public static BindingList<EventPrice> GetEventPriceList() {
      BindingList<EventPrice> eventPriceList = new BindingList<EventPrice>();

      eventPriceList.Add(EventPrice1);
      eventPriceList.Add(EventPrice2);
      eventPriceList.Add(EventPrice3);

      return eventPriceList;
    }

    public static BindingList<Item> GetItemList() {
      BindingList<Item> itemList = new BindingList<Item>();

      itemList.Add(Item1);
      itemList.Add(Item2);
      itemList.Add(Item3);
      itemList.Add(Item4);
      itemList.Add(Item5);

      return itemList;
    }

    public static BindingList<Purchase> GetPurchaseList() {
      BindingList<Purchase> purchaseList = new BindingList<Purchase>();

      purchaseList.Add(Purchase1);
      purchaseList.Add(Purchase2);

      return purchaseList;
    }

    public static BindingList<User> GetUserList() {
      BindingList<User> userList = new BindingList<User>();

      userList.Add(User1);
      userList.Add(User2);
      userList.Add(User3);
      userList.Add(User4);
      userList.Add(User5);
      userList.Add(User6);

      return userList;
    }

  }
}
