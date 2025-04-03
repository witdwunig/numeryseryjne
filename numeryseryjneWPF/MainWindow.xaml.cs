using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                Items.Add(InputTextBox.Text);
                InputTextBox.Clear();
            }
        }
    }
}
