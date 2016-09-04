using GalaSoft.MvvmLight;
using NoobApp.Entity;

namespace NoobApp.ViewModel {
  public class DisplayItem : ViewModelBase {

    #region - InstanceVariables -

    private readonly EventInventory _eventInventory;

    #endregion

    #region - Constructor -

    public DisplayItem(EventInventory eventInventory) {
      _eventInventory = eventInventory;

      InitializeData();
    }

    #endregion

    #region - Properties -

    #region -- DisplayItemImage --

    public static string DisplayItemImagePropertyName = "DisplayItemImage";
    //todo

    #endregion

    #region -- DisplayItemName --

    public static string DisplayItemNamePropertyName = "DisplayItemName";
    private string _displayItemName;
    public string DisplayItemName {
      get {
        return _displayItemName;
      }
      set {
        if (_displayItemName == value) {
          return;
        }

        _displayItemName = value;
        RaisePropertyChanged(DisplayItemNamePropertyName);
      }
    }

    #endregion

    #region -- DisplayItemAmount --

    public static string DisplayItemAmountPropertyName = "DisplayItemAmount";
    private int _displayItemAmount;
    public int DisplayItemAmount {
      get {
        return _displayItemAmount;
      }
      set {
        if (_displayItemAmount == value) {
          return;
        }

        if(value < 0) {
          return;
        }

        _displayItemAmount = value;
        UpdateTotal();
        RaisePropertyChanged(DisplayItemAmountPropertyName);
      }
    }

    #endregion

    #region -- DisplayItemPrice --

    public static string DisplayItemPricePropertyName = "DisplayItemPrice";
    private float _displayItemPrice;
    public float DisplayItemPrice {
      get {
        return _displayItemPrice;
      }
      set {
        if (_displayItemPrice == value) {
          return;
        }

        _displayItemPrice = value;
        RaisePropertyChanged(DisplayItemPricePropertyName);
      }
    }

    #endregion

    #region -- DisplayItemTotal --

    public static string DisplayItemTotalPropertyName = "DisplayItemTotal";
    private float _displayItemTotal;
    public float DisplayItemTotal {
      get {
        return _displayItemTotal;
      }
      set {
        if (_displayItemTotal == value) {
          return;
        }

        _displayItemTotal = value;
        RaisePropertyChanged(DisplayItemTotalPropertyName);
      }
    }

    #endregion

    #endregion

    #region - Public Methods -

    #region -- GetEventInventory --

    public EventInventory GetEventInventory() {
      return _eventInventory;
    }

    #endregion

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      //DisplayItemImage = _eventInventory.EventInventoryItemRef.ItemImage;
      DisplayItemName = _eventInventory.EventIntenvotryItemRef.ItemName;
      DisplayItemPrice = _eventInventory.EventInventoryPrice;
    }

    #endregion

    #region -- UpdateTotal --

    private void UpdateTotal() {
      DisplayItemTotal = DisplayItemAmount * DisplayItemPrice;
    }

    #endregion

    #endregion

  }
}
