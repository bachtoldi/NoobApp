using NoobApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for PasswordView.xaml
  /// </summary>
  public partial class PasswordView : Window {
    public PasswordView(PasswordViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) {
      if (this.DataContext != null) {
        ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
      }
    }
  }
}
