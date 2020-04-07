using System;

using coluwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace coluwp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_LoadedAsync;
        }



        private async void MainPage_LoadedAsync(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           // await ViewModel.LoadStudentsAsync();
        }
    }
}
