﻿using NoobApp.ViewModel;
using System.Windows.Controls;

namespace NoobApp.View {
  /// <summary>
  /// Interaction logic for HomeView.xaml
  /// </summary>
  public partial class HomeView : UserControl {
    public HomeView(HomeViewModel viewModel) {
      InitializeComponent();
      DataContext = viewModel;
    }
  }
}
