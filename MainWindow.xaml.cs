using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_CoffeeMachine
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoffeeMachineViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CoffeeMachineViewModel();
            DataContext = viewModel;
        }

        private void OnClick_BrewCoffee(object sender, RoutedEventArgs e) => viewModel.BrewCoffee(sender, e);

        private void OnClick_FillWater(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(FillAmount.Text, out int value))
            {
                viewModel.FillWater(sender, e, value);
            }
        }

        private void OnClick_FillCoffee(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(FillAmount.Text, out int value))
            {
                viewModel.FillCoffee(sender, e, value);
            }
        }

        private void OnClick_Clean(object sender, RoutedEventArgs e) => viewModel.Clean(sender, e);

        private void OnClick_Exit(object sender, RoutedEventArgs e) => viewModel.Exit(sender, e);
    }
}