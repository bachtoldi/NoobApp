using NoobApp.Entity;
using NoobApp.Enum;
using System;

namespace NoobApp.Event {
  public class UserControlEventArgs : EventArgs {

    public UserControlEventArgs(Views view, bool cancel, User user) {
      Cancel = cancel;
      View = view;
      User = user;
    }

    private Views _view;
    public Views View {
      get {
        return _view;
      }
      set {
        _view = value;
      }
    }

    private bool _cancel;
    public bool Cancel {
      get {
        return _cancel;
      }
      set {
        _cancel = value;
      }
    }

    private User _user;
    public User User {
      get {
        return _user;
      }
      set {
        _user = value;
      }
    }

  }
}
