using NoobApp.Entity;
using System;

namespace NoobApp.Event {
  public class UserControlEventArgs : EventArgs {

    public UserControlEventArgs(Views view, bool cancel) {
      Cancel = cancel;
      View = view;
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

  }
}
