using NoobApp.ViewModel;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for PurchasedView.xaml
  /// </summary>
  public partial class PurchasedView : UserControl {
    public PurchasedView(PurchasedViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {

    }
  }
}
