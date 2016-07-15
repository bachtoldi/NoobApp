using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobApp.Entity {
  public class AttendanceType : ViewModelBase {

    #region - Constructor -

    public AttendanceType() {

    }

    #endregion

    #region - Properties -

    #region -- AttendanceTypeId --

    public static string AttendanceTypeIdPropertyName = "AttendanceTypeId";
    private int _attendanceTypeId;
    public int AttendanceTypeId {
      get {
        return _attendanceTypeId;
      }
      set {
        if (_attendanceTypeId == value) {
          return;
        }

        _attendanceTypeId = value;
        RaisePropertyChanged(AttendanceTypeIdPropertyName);
      }
    }

    #endregion

    #region -- AttendanceTypeName --

    public static string AttendanceTypeNamePropertyName = "AttendanceTypeName";
    private string _attendanceTypeName;
    public string AttendanceTypeName {
      get {
        return _attendanceTypeName;
      }
      set {
        if (_attendanceTypeName == value) {
          return;
        }

        _attendanceTypeName = value;
        RaisePropertyChanged(AttendanceTypeNamePropertyName);
      }
    }

    #endregion

    #region -- AttendanceTypeEventPriceRef --

    public static string AttendanceTypeEventPriceRefPropertyName = "AttendanceTypeEventPriceRef";
    private EventPrice _attendanceTypeEventPriceRef;
    public EventPrice AttendanceTypeEventPriceRef {
      get {
        return _attendanceTypeEventPriceRef;
      }
      set {
        if (_attendanceTypeEventPriceRef == value) {
          return;
        }

        _attendanceTypeEventPriceRef = value;
        RaisePropertyChanged(AttendanceTypeEventPriceRefPropertyName);
      }
    }

    #endregion

    #endregion

  }
}
