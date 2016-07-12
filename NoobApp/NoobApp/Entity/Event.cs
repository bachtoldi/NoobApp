using GalaSoft.MvvmLight;
using System;

namespace NoobApp.Entity {
  public class Event : ViewModelBase {

    #region - Constructor -

    public Event() {

    }

    #endregion

    #region - Properties -

    #region -- Id --

    public static string IdPropertyName = "Id";
    private int _id;
    public int Id {
      get {
        return _id;
      }
      set {
        if (_id == value) {
          return;
        }

        _id = value;
        RaisePropertyChanged(IdPropertyName);
      }
    }

    #endregion

    #region -- Name --

    public static string NamePropertyName = "Name";
    private string _name;
    public string Name {
      get {
        return _name;
      }
      set {
        if (_name == value) {
          return;
        }

        _name = value;
        RaisePropertyChanged(NamePropertyName);
      }
    }

    #endregion

    #region -- StartDate --

    public static string StartDatePropertyName = "StartDate";
    private DateTime _startDate;
    public DateTime StartDate {
      get {
        return _startDate;
      }
      set {
        if (_startDate == value) {
          return;
        }

        _startDate = value;
        RaisePropertyChanged(StartDatePropertyName);
      }
    }

    #endregion

    #region -- EndDate --

    public static string EndDatePropertyName = "EndDate";
    private DateTime _endDate;
    public DateTime EndDate {
      get {
        return _endDate;
      }
      set {
        if (_endDate == value) {
          return;
        }

        _endDate = value;
        RaisePropertyChanged(EndDatePropertyName);
      }
    }

    #endregion

    #endregion

  }
}
