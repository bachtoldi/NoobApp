using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Model;
using System.ComponentModel;
using System.Data.Entity;

namespace NoobApp.ViewModel {
  public class SelectEventViewModel : ViewModelBase {

    #region - Instance Variables -

    #endregion

    #region - Constructor -

    public SelectEventViewModel(Entity.Event eventEntity = null) {
      EventSelected = eventEntity;

      InitializeData();
    }

    #endregion

    #region - Properties -

    #region -- EventList --

    public static string EventListPropertyName = "EventList";
    private BindingList<Entity.Event> _eventList;
    public BindingList<Entity.Event> EventList {
      get {
        return _eventList;
      }
      set {
        if (_eventList == value) {
          return;
        }

        _eventList = value;
        RaisePropertyChanged(EventListPropertyName);
      }
    }

    #endregion

    #region -- EventSelected --

    public static string EventSelectedPropertyName = "EventSelected";
    private Entity.Event _eventSelected;
    public Entity.Event EventSelected {
      get {
        return _eventSelected;
      }
      set {
        if (_eventSelected == value) {
          return;
        }

        _eventSelected = value;
        RaisePropertyChanged(EventSelectedPropertyName);
      }
    }

    #endregion

    #region -- DialogResult --

    public static string DialogResultPropertyName = "DialogResult";
    private bool? _dialogResult;
    public bool? DialogResult {
      get {
        return _dialogResult;
      }
      set {
        if (_dialogResult == value) {
          return;
        }

        _dialogResult = value;
        RaisePropertyChanged(DialogResultPropertyName);
      }
    }

    #endregion

    #endregion

    #region - Commands -

    #region -- SelectCmd --

    private RelayCommand _selectCmd;

    public RelayCommand SelectCmd {
      get {
        return _selectCmd;
      }
    }

    #endregion

    #region -- CancelCmd --

    private RelayCommand _cancelCmd;

    public RelayCommand CancelCmd {
      get {
        return _cancelCmd;
      }
    }

    #endregion

    #endregion

    #region - Public Methods -

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      using (var dataService = new DataService()) {
        dataService.Events.Load();
        EventList = dataService.Events.Local.ToBindingList();
      }

      InitializeCommands();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _selectCmd = new RelayCommand(ExecuteSelectCmd, CanExecuteSelectCmd);
      _cancelCmd = new RelayCommand(ExecuteCancelCmd, CanExecuteCancelCmd);
    }

    #endregion

    #region -- ExecuteSelectCmd --

    private void ExecuteSelectCmd() {
      DialogResult = true;
    }

    private bool CanExecuteSelectCmd() {
      return (EventSelected != null);
    }

    #endregion

    #region -- ExecuteCancelCmd --

    private void ExecuteCancelCmd() {
      DialogResult = false;
    }

    private bool CanExecuteCancelCmd() {
      return (EventSelected != null);
    }

    #endregion

    #endregion

  }
}
