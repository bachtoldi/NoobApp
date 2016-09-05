using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [Key]
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

    #endregion

  }
}
