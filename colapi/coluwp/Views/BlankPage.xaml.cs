using System;

using coluwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace coluwp.Views
{
    public sealed partial class BlankPage : Page
    {
        public BlankViewModel ViewModel { get; } = new BlankViewModel();

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
