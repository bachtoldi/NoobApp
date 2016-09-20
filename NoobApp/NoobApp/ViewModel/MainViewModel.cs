using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using NoobApp.View;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace NoobApp.ViewModel {
  public class MainViewModel : ViewModelBase {

    #region - Instance Variables -

    Entity.Event _event;

    #endregion

    #region - Constructor -

    public MainViewModel() {

      SelectEventViewModel viewModel = new SelectEventViewModel();
      SelectEventView view = new SelectEventView(viewModel);

      if (view.ShowDialog() == true) {
        _event = viewModel.EventSelected;
      }

      InitializeData();
      InitializeCommands();
    }

    #endregion

    #region - Properties -

    #region -- ContentControlView --

    public static string ContentControlViewPropertyName = "ContentControlView";
    private FrameworkElement _contentControlView;
    public FrameworkElement ContentControlView {
      get {
        return _contentControlView;
      }
      set {
        if (_contentControlView == value) {
          return;
        }

        _contentControlView = value;
        RaisePropertyChanged(ContentControlViewPropertyName);
      }
    }

    #endregion

    #endregion

    #region - Commands -

    #region -- HomeCmd --

    private RelayCommand _homeCmd;

    public RelayCommand HomeCmd {
      get {
        return _homeCmd;
      }
    }

    #endregion

    #region -- PopulateDatabaseCmd --

    private RelayCommand _populateDatabaseCmd;

    public RelayCommand PopulateDatabaseCmd {
      get {
        return _populateDatabaseCmd;
      }
    }

    #endregion

    #region -- AdminCmd --

    private RelayCommand _adminCmd;

    public RelayCommand AdminCmd {
      get {
        return _adminCmd;
      }
    }

    #endregion

    #endregion

    #region - Private Methods -

    #region -- InitializeData --

    private void InitializeData() {
      //using (var dataService = new DataService()) {
      //  dataService.Events.Load();
      //  _event = dataService.Events.Find(11);
      //}

      ExecuteHomeCmd();
    }

    #endregion

    #region -- InitializeCommands --

    private void InitializeCommands() {
      _homeCmd = new RelayCommand(ExecuteHomeCmd, CanExecuteHomeCmd);
      _populateDatabaseCmd = new RelayCommand(ExecutePopulateDatabaseCmd, CanExecutePopulateDatabaseCmd);
      _adminCmd = new RelayCommand(ExecuteAdminCmd, CanExecuteAdminCmd);
    }

    #endregion

    #region -- HomeCmd --

    private void ExecuteHomeCmd() {
      HomeViewModel viewModel = new HomeViewModel();
      HomeView view = new HomeView(viewModel);

      ContentControlView = view;

      viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);
    }

    private bool CanExecuteHomeCmd() {
      return true;
    }

    #endregion

    //TODO Entfernen
    #region -- PopulateDatabaseCmd --

    private void ExecutePopulateDatabaseCmd() {
      DummyDataConnector.PopulateDatabase();
    }

    private bool CanExecutePopulateDatabaseCmd() {
      return true;
    }

    #endregion

    #region -- AdminCmd --

    private void ExecuteAdminCmd() {

    }

    private bool CanExecuteAdminCmd() {
      return true;
    }

    #endregion

    #region -- ChangeWindow --

    private void ChangeWindow(object sender, UserControlEventArgs e) {

      if (e.View == Views.USER) {

        UserViewModel viewModel = new UserViewModel(e.User);
        UserView view = new UserView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.PURCHASE) {

        PurchaseViewModel viewModel = new PurchaseViewModel(e.User, _event);
        PurchaseView view = new PurchaseView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.ATTENDANCE) {

        AttendanceViewModel viewModel = new AttendanceViewModel(e.User, _event);
        AttendanceView view = new AttendanceView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.PURCHASED) {

        PurchasedViewModel viewModel = new PurchasedViewModel(e.User, _event);
        PurchasedView view = new PurchasedView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.NEWUSER) {

        NewUserViewModel viewModel = new NewUserViewModel();
        NewUserView view = new NewUserView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.HOME) {

        HomeViewModel viewModel = new HomeViewModel();
        HomeView view = new HomeView(viewModel);

        ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      }

    }

    #endregion

    #endregion

  }

}