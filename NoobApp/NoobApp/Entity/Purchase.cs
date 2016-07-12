using GalaSoft.MvvmLight;

namespace NoobApp.Entity {
  public class Purchase : ViewModelBase {

    #region - Constructor -

    public Purchase() {

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

    #region -- ItemRef --

    public static string ItemRefPropertyName = "ItemRef";
    private Item _itemRef;
    public Item ItemRef {
      get {
        return _itemRef;
      }
      set {
        if (_itemRef == value) {
          return;
        }

        _itemRef = value;
        RaisePropertyChanged(ItemRefPropertyName);
      }
    }

    #endregion

    #region -- UserRef --

    public static string UserRefPropertyName = "UserRef";
    private User _userRef;
    public User UserRef {
      get {
        return _userRef;
      }
      set {
        if (_userRef == value) {
          return;
        }

        _userRef = value;
        RaisePropertyChanged(UserRefPropertyName);
      }
    }

    #endregion

    #region -- Billed --

    public static string BilledPropertyName = "Billed";
    private bool _billed;
    public bool Billed {
      get {
        return _billed;
      }
      set {
        if (_billed == value) {
          return;
        }

        _billed = value;
        RaisePropertyChanged(BilledPropertyName);
      }
    }

    #endregion

    #endregion

  }
}
