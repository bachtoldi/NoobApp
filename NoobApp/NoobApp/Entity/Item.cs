using GalaSoft.MvvmLight;

namespace NoobApp.Entity {
  public class Item : ViewModelBase  {

    #region - Constructor -

    public Item() {

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

    #region -- Image --

    

    #endregion

    #endregion

  }
}
