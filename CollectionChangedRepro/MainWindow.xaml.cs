﻿namespace CollectionChangedRepro
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Vm _vm= new Vm();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            _vm.Add();
        }
    }
}
