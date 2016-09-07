using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace NoobApp.Entity {
  public class User : ViewModelBase {

    #region - Constructor -

    public User() {

    }

    #endregion

    #region - Properties -

    #region -- UserId --

    public static string UserIdPropertyName = "UserId";
    private int _userId;
    [Key]
    public int UserId {
      get {
        return _userId;
      }
      set {
        if(_userId == value) {
          return;
        }

        _userId = value;
        RaisePropertyChanged(UserIdPropertyName);
      }
    }

    #endregion

    #region -- UserFirstName --

    public static string UserFirstNamePropertyName = "UserFirstName";
    private string _userFirstName;
    public string UserFirstName {
      get {
        return _userFirstName;
      }
      set {
        if(_userFirstName == value) {
          return;
        }

        _userFirstName = value;
        RaisePropertyChanged(UserFirstNamePropertyName);
      }
    }

    #endregion

    #region -- UserLastName --

    private static string UserLastNamePropertyName = "UserLastName";
    private string _userLastName;
    public string UserLastName {
      get {
        return _userLastName;
      }
      set {
        if(_userLastName == value) {
          return;
        }

        _userLastName = value;
        RaisePropertyChanged(UserLastNamePropertyName);
      }
    }

    #endregion

    #region -- UserDisplayName --

    public static string UserDisplayNamePropertyName = "UserDisplayName";
    private string _userDisplayName;
    public string UserDisplayName {
      get {
        return _userDisplayName;
      }
      set {
        if(_userDisplayName == value) {
          return;
        }

        _userDisplayName = value;
        RaisePropertyChanged(UserDisplayNamePropertyName);
      }
    }

    #endregion

    #endregion

  }
}
