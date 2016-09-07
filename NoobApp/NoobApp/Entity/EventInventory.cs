using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace NoobApp.Entity {
  public class EventInventory : ViewModelBase {

    #region - Constructor -

    public EventInventory() {

    }

    #endregion

    #region - Properties -

    #region -- EventInventoryId --

    public static string EventInventoryIdPropertyName = "EventInventoryId";
    private int _eventInventoryId;
    [Key]
    public int EventInventoryId {
      get {
        return _eventInventoryId;
      }
      set {
        if(_eventInventoryId == value) {
          return;
        }

        _eventInventoryId = value;
        RaisePropertyChanged(EventInventoryIdPropertyName);
      }
    }

    #endregion

    #region -- EventInventoryItemRef --

    public static string EventInventoryItemRefPropertyName = "EventInventoryItemRef";
    private Item _eventInventoryItemRef;
    public Item EventIntenvotryItemRef {
      get {
        return _eventInventoryItemRef;
      }
      set {
        if(_eventInventoryItemRef == value) {
          return;
        }

        _eventInventoryItemRef = value;
        RaisePropertyChanged(EventInventoryItemRefPropertyName);
      }
    }

    #endregion

    #region -- EventInventoryEventRef --

    public static string EventInventoryEventRefPropertyName = "EventInventoryEventRef";
    private Event _eventInventoryEventRef;
    public Event EventInventoryEventRef {
      get {
        return _eventInventoryEventRef;
      }
      set {
        if(_eventInventoryEventRef == value) {
          return;
        }

        _eventInventoryEventRef = value;
        RaisePropertyChanged(EventInventoryEventRefPropertyName);
      }
    }

    #endregion

    #region -- EventInventoryPrice --

    public static string EventInventoryPricePropertyName = "EventInventoryPrice";
    private float _eventInventoryPrice;
    public float EventInventoryPrice {
      get {
        return _eventInventoryPrice;
      }
      set {
        if(_eventInventoryPrice == value) {
          return;
        }

        _eventInventoryPrice = value;
        RaisePropertyChanged(EventInventoryPricePropertyName);
      }
    }

    #endregion

    #endregion

  }
}
