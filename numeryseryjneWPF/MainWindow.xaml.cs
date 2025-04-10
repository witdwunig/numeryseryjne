using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SerialTrack
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<SerialItem> SerialItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SerialItems = new ObservableCollection<SerialItem>();
            SerialDataGrid.ItemsSource = SerialItems;
        }

        public void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            SerialItems.Add(new SerialItem
            {
                SerialNumber = "ABC123456", // Możesz potem wygenerować losowy
                ProductName = ProductNameTextBox.Text,
                DateGenerated = DateTime.Now
            });
        }

        private void ToggleFiltersVisibility(object sender, RoutedEventArgs e)
        {
            if (FiltersPanel.Visibility == Visibility.Collapsed)
            {
                FiltersPanel.Visibility = Visibility.Visible;
                (sender as Button).Content = "Ukryj filtry";
            }
            else
            {
                FiltersPanel.Visibility = Visibility.Collapsed;
                (sender as Button).Content = "Pokaż filtry";
            }
        }
    }

    public class SerialItem
    {
        public string SerialNumber { get; set; }
        public string ProductName { get; set; }
        public DateTime DateGenerated { get; set; }
    }
}
