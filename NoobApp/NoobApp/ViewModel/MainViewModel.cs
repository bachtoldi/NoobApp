using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NoobApp.Connector;
using NoobApp.Enum;
using NoobApp.Event;
using NoobApp.Model;
using NoobApp.View;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace NoobApp.ViewModel {
  public class MainViewModel : ViewModelBase {

    #region - Instance Variables -

    private HomeViewModel _viewModel;
    private Entity.Event _event;

    #endregion

    #region - Constructor -

    public MainViewModel() {

      SelectEventViewModel viewModel = new SelectEventViewModel();
      SelectEventView view = new SelectEventView(viewModel);

      if (view.ShowDialog() == true) {
        _event = viewModel.EventSelected;
      }

      InitializeData();
    }

    #endregion

    #region - Properties -

    #region -- ContentControlView --

    public static string ContentControlViewPropertyName = "UserListControlView";
    private FrameworkElement _userListControlView;
    public FrameworkElement UserListControlView {
      get {
        return _userListControlView;
      }
      set {
        if (_userListControlView == value) {
          return;
        }

        _userListControlView = value;
        RaisePropertyChanged(ContentControlViewPropertyName);
      }
    }

    public static string UserDetailControlViewPropertyName = "UserDetailControlView";
    private FrameworkElement _userDetailControlView;
    public FrameworkElement UserDetailControlView {
      get {
        return _userDetailControlView;
      }
      set {
        if (_userDetailControlView == value) {
          return;
        }

        _userDetailControlView = value;
        RaisePropertyChanged(UserDetailControlViewPropertyName);
      }
    }

    public static string UserPurchaseButtonsControlViewPropertyName = "UserPurchaseButtonsControlView";
    private FrameworkElement _userPurchaseButtonsControlView;
    public FrameworkElement UserPurchaseButtonsControlView {
      get {
        return _userPurchaseButtonsControlView;
      }
      set {
        if (_userPurchaseButtonsControlView == value) {
          return;
        }

        _userPurchaseButtonsControlView = value;
        RaisePropertyChanged(UserPurchaseButtonsControlViewPropertyName);
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
      InitializeCommands();
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
      _viewModel = new HomeViewModel();
      HomeView view = new HomeView(_viewModel);

      UserListControlView = view;

      _viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);
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
      var viewModel = new PasswordViewModel();
      var view = new PasswordView(viewModel);

      if (view.ShowDialog() == true) {
        var adminViewModel = new AdminViewModel();
        var adminView = new AdminView(adminViewModel);

        adminView.ShowDialog();
      }

    }

    private bool CanExecuteAdminCmd() {
      return true;
    }

    #endregion

    #region -- ChangeWindow --

    private void ChangeWindow(object sender, UserControlEventArgs e) {
      if (e.View == Views.USER) {
        UserViewModel viewModel = new UserViewModel(e.User, _event);
        UserView view = new UserView(viewModel);

        UserDetailControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

        PurchaseViewModel purchaseViewModel = new PurchaseViewModel(e.User, _event) {
          UserViewSumRefresh = viewModel.CalcSum,
        };
        PurchaseView purchaseView = new PurchaseView(purchaseViewModel);

        UserPurchaseButtonsControlView = purchaseView;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.PURCHASED) {

        PurchasedViewModel viewModel = new PurchasedViewModel(e.User, _event) {
          UserViewSumRefresh = ((UserViewModel)sender).CalcSum,
        };
        PurchasedView view = new PurchasedView(viewModel);

        UserPurchaseButtonsControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);

      } else if (e.View == Views.NEWUSER) {
        NewUserViewModel viewModel = new NewUserViewModel(e.User);
        NewUserView view = new NewUserView(viewModel);

        if (view.ShowDialog() == true) {
          _viewModel.NewUserCallback();
        }

        //ContentControlView = view;

        viewModel.OnChangeWindow += new ChangeWindowEventHandler(ChangeWindow);
      }
    }

    #endregion

    #endregion

  }

}