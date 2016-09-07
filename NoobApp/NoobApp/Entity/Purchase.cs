using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace NoobApp.Entity {
  public class Purchase : ViewModelBase {

    #region - Constructor -

    public Purchase() {

    }

    #endregion

    #region - Properties -

    #region -- PurchaseId --

    public static string PurchaseIdPropertyName = "PurchaseId";
    private int _purchaseId;
    [Key]
    public int PurchaseId {
      get {
        return _purchaseId;
      }
      set {
        if (_purchaseId == value) {
          return;
        }

        _purchaseId = value;
        RaisePropertyChanged(PurchaseIdPropertyName);
      }
    }

    #endregion

    #region -- PurchaseEventInventoryRef --

    public static string PurchaseEventInventoryRefPropertyName = "PurchaseEventInventoryRef";
    private EventInventory _purchaseEventInventoryRef;
    public EventInventory PurchaseEventInventoryRef {
      get {
        return _purchaseEventInventoryRef;
      }
      set {
        if (_purchaseEventInventoryRef == value) {
          return;
        }

        _purchaseEventInventoryRef = value;
        RaisePropertyChanged(PurchaseEventInventoryRefPropertyName);
      }
    }

    #endregion

    #region -- PurchaseUserRef --

    public static string PurchaseUserRefPropertyName = "PurchaseUserRef";
    private User _purchaseUserRef;
    public User PurchaseUserRef {
      get {
        return _purchaseUserRef;
      }
      set {
        if (_purchaseUserRef == value) {
          return;
        }

        _purchaseUserRef = value;
        RaisePropertyChanged(PurchaseUserRefPropertyName);
      }
    }

    #endregion

    #region -- PurchaseBilled --

    public static string PurchaseBilledPropertyName = "PurchaseBilled";
    private bool _purchaseBilled;
    public bool PurchaseBilled {
      get {
        return _purchaseBilled;
      }
      set {
        if (_purchaseBilled == value) {
          return;
        }

        _purchaseBilled = value;
        RaisePropertyChanged(PurchaseBilledPropertyName);
      }
    }

    #endregion

    #endregion

  }
}
