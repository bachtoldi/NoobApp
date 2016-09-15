using NoobApp.ViewModel;
using System.Windows;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for SelectEventView.xaml
  /// </summary>
  public partial class SelectEventView : Window {
    public SelectEventView(SelectEventViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
