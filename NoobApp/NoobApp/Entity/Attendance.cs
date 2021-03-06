﻿using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations;

namespace NoobApp.Entity {
  public class Attendance : ViewModelBase {

    #region - Constructor -

    public Attendance() {

    }

    #endregion

    #region - Properties -

    #region -- AttendanceId --

    public static string AttendanceIdPropertyName = "AttendanceId";
    private int _attendanceId;
   [Key] 
    public int AttendanceId {
      get {
        return _attendanceId;
      }
      set {
        if (_attendanceId == value) {
          return;
        }

        _attendanceId = value;
        RaisePropertyChanged(AttendanceIdPropertyName);
      }
    }

    #endregion

    //#region -- AttendanceStartDateTime --

    //public static string AttendanceStartDateTimePropertyName = "AttendanceStartDateTime";
    //private DateTime _attendanceStartDateTime;
    //public DateTime AttendanceStartDateTime {
    //  get {
    //    return _attendanceStartDateTime;
    //  }
    //  set {
    //    if (_attendanceStartDateTime == value) {
    //      return;
    //    }

    //    _attendanceStartDateTime = value;
    //    RaisePropertyChanged(AttendanceStartDateTimePropertyName);
    //  }
    //}

    //#endregion

    //#region -- AttendanceEndDateTime --

    //public static string AttendanceEndDateTimePropertyName = "AttendanceEndDateTime";
    //private DateTime _attendanceEndDateTime;
    //public DateTime AttendanceEndDateTime {
    //  get {
    //    return _attendanceEndDateTime;
    //  }
    //  set {
    //    if (_attendanceEndDateTime == value) {
    //      return;
    //    }

    //    _attendanceEndDateTime = value;
    //    RaisePropertyChanged(AttendanceEndDateTimePropertyName);
    //  }
    //}

    //#endregion

    #region -- AttendanceAttendanceTypeRef --

    public static string AttendanceAttendanceTypeRefPropertyName = "AttendanceAttendanceTypeRef";
    private AttendanceType _attendanceAttendanceTypeRef;
    public AttendanceType AttendanceAttendanceTypeRef {
      get {
        return _attendanceAttendanceTypeRef;
      }
      set {
        if (_attendanceAttendanceTypeRef == value) {
          return;
        }

        _attendanceAttendanceTypeRef = value;
        RaisePropertyChanged(AttendanceAttendanceTypeRefPropertyName);
      }
    }
    
    #endregion

    #region -- AttendanceEventRef --

    public static string AttendanceEventRefPropertyName = "AttendanceEventRef";
    private Event _attendanceEventRef;
    public Event AttendanceEventRef {
      get {
        return _attendanceEventRef;
      }
      set {
        if (_attendanceEventRef == value) {
          return;
        }

        _attendanceEventRef = value;
        RaisePropertyChanged(AttendanceEventRefPropertyName);
      }
    }

    #endregion

    #region -- AttendanceUserRef --

    public static string AttendanceUserRefPropertyName = "AttendanceUserRef";
    private User _attendanceUserRef;
    public User AttendanceUserRef {
      get {
        return _attendanceUserRef;
      }
      set {
        if (_attendanceUserRef == value) {
          return;
        }

        _attendanceUserRef = value;
        RaisePropertyChanged(AttendanceUserRefPropertyName);
      }
    }

    #endregion

    #endregion

  }
}
