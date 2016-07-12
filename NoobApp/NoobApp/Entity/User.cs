using GalaSoft.MvvmLight;

namespace NoobApp.Entity {
  public class User : ViewModelBase {

    #region - Constructor -

    public User() {

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
        if(_id == value) {
          return;
        }

        _id = value;
        RaisePropertyChanged(IdPropertyName);
      }
    }

    #endregion

    #region -- FirstName --

    public static string FirstNamePropertyName = "FirstName";
    private string _firstName;
    public string FirstName {
      get {
        return _firstName;
      }
      set {
        if(_firstName == value) {
          return;
        }

        _firstName = value;
        RaisePropertyChanged(FirstNamePropertyName);
      }
    }

    #endregion

    #region -- LastName --

    private static string LastNamePropertyName = "LastName";
    private string _lastName;
    public string LastName {
      get {
        return _lastName;
      }
      set {
        if(_lastName == value) {
          return;
        }

        _lastName = value;
        RaisePropertyChanged(LastNamePropertyName);
      }
    }

    #endregion

    #region -- DisplayName --

    public static string DisplayNamePropertyName = "DisplayName";
    private string _displayName;
    public string DisplayName {
      get {
        return _displayName;
      }
      set {
        if(_displayName == value) {
          return;
        }

        _displayName = value;
        RaisePropertyChanged(DisplayNamePropertyName);
      }
    }

    #endregion

    #endregion

  }
}
