using GalaSoft.MvvmLight;

namespace NoobApp.Entity {
  public class EventPrice : ViewModelBase {

    #region - Constructor -

    public EventPrice() {

    }

    #endregion

    #region - Properties -

    #region -- EventPriceId --

    public static string EventPriceIdPropertyName = "EventPriceId";
    private int _eventPriceId;
    public int EventPriceId {
      get {
        return _eventPriceId;
      }
      set {
        if (_eventPriceId == value) {
          return;
        }

        _eventPriceId = value;
        RaisePropertyChanged(EventPriceIdPropertyName);
      }
    }

    #endregion

    #region -- EventPriceValue --

    public static string EventPriceValuePropertyName = "EventPriceValue";
    private float _eventPriceValue;
    public float EventPriceValue {
      get {
        return _eventPriceValue;
      }
      set {
        if (_eventPriceValue == value) {
          return;
        }

        _eventPriceValue = value;
        RaisePropertyChanged(EventPriceValuePropertyName);
      }
    }

    #endregion

    #region -- EventPriceAttendanceTypeRef --

    public static string EventPriceAttendanceTypeRefPropertyName = "EventPriceAttendanceTypeRef";
    private AttendanceType _eventPriceAttendanceTypeRef;
    public AttendanceType EventPriceAttendanceTypeRef {
      get {
        return _eventPriceAttendanceTypeRef;
      }
      set {
        if (_eventPriceAttendanceTypeRef == value) {
          return;
        }

        _eventPriceAttendanceTypeRef = value;
        RaisePropertyChanged(EventPriceAttendanceTypeRefPropertyName);
      }
    }

    #endregion

    #region -- EventPriceEventRef --

    #endregion

    #endregion

  }
}
