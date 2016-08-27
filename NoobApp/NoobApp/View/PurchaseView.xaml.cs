using NoobApp.ViewModel;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for PurchaseView.xaml
  /// </summary>
  public partial class PurchaseView : UserControl {
    public PurchaseView(PurchaseViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
