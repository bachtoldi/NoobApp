using GalaSoft.MvvmLight;

namespace NoobApp.Entity {
  public class Item : ViewModelBase  {

    #region - Constructor -

    public Item() {

    }

    #endregion

    #region - Properties -

    #region -- ItemId --

    public static string ItemIdPropertyName = "ItemId";
    private int _itemId;
    public int ItemId {
      get {
        return _itemId;
      }
      set {
        if (_itemId == value) {
          return;
        }

        _itemId = value;
        RaisePropertyChanged(ItemIdPropertyName);
      }
    }

    #endregion

    #region -- ItemName --

    public static string ItemNamePropertyName = "ItemName";
    private string _itemName;
    public string ItemName {
      get {
        return _itemName;
      }
      set {
        if (_itemName == value) {
          return;
        }

        _itemName = value;
        RaisePropertyChanged(ItemNamePropertyName);
      }
    }

    #endregion

    #region -- Image --

    // bin noni sicher was gschiter isch - db oder filesyschtem - und isch ja au nonig würklich relevant oder so :D

    #endregion

    #endregion

  }
}
