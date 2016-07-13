using GalaSoft.MvvmLight;
using System;

namespace NoobApp.Entity {
  public class Event : ViewModelBase {

    #region - Constructor -

    public Event() {

    }

    #endregion

    #region - Properties -

    #region -- EventId --

    public static string EventIdPropertyName = "EventId";
    private int _eventId;
    public int EventId {
      get {
        return _eventId;
      }
      set {
        if (_eventId == value) {
          return;
        }

        _eventId = value;
        RaisePropertyChanged(EventIdPropertyName);
      }
    }

    #endregion

    #region -- EventName --

    public static string EventNamePropertyName = "EventName";
    private string _eventName;
    public string EventName {
      get {
        return _eventName;
      }
      set {
        if (_eventName == value) {
          return;
        }

        _eventName = value;
        RaisePropertyChanged(EventNamePropertyName);
      }
    }

    #endregion

    #region -- EventStartDate --

    public static string EventStartDatePropertyName = "EventStartDate";
    private DateTime _eventStartDate;
    public DateTime EventStartDate {
      get {
        return _eventStartDate;
      }
      set {
        if (_eventStartDate == value) {
          return;
        }

        _eventStartDate = value;
        RaisePropertyChanged(EventStartDatePropertyName);
      }
    }

    #endregion

    #region -- EventEndDate --

    public static string EventEndDatePropertyName = "EventEndDate";
    private DateTime _eventEndDate;
    public DateTime EventEndDate {
      get {
        return _eventEndDate;
      }
      set {
        if (_eventEndDate == value) {
          return;
        }

        _eventEndDate = value;
        RaisePropertyChanged(EventEndDatePropertyName);
      }
    }

    #endregion

    #endregion

  }
}
