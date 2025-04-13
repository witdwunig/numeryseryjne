using numeryseryjneWPF.Services;
using numeryseryjneWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace SerialTrack
{
    public partial class MainWindow : Window
    {
        private ApiService _apiService;
        public ObservableCollection<SerialItem> SerialItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SerialItems = new ObservableCollection<SerialItem>();
            SerialDataGrid.ItemsSource = SerialItems;
            InitializeServerDiscovery();
        }

        private async void InitializeServerDiscovery()
        {
            Debug.WriteLine("test");
            var discoveryService = new ServerDiscoveryService();
            Debug.WriteLine("Before calling discovery");
            string? serverUrl = await discoveryService.DiscoverServerAsync();
            Debug.WriteLine("After");

            if (serverUrl != null) 
            {
                _apiService = new ApiService(serverUrl);
                FetchSerialNumbers();
            } else
            {
                Debug.WriteLine("Server was null");
            }
        }
        private async void FetchSerialNumbers()
        {
            try
            {
                var serialNumbers = await _apiService.GetSerialsAsync();
                SerialItems.Clear();
                foreach (var serial in serialNumbers)
                {
                    Debug.WriteLine(serial.CreatedAt);
                    SerialItems.Add(new SerialItem()
                    {
                        SerialNumber = serial.number,
                        ProductName = serial.name,
                        DateGenerated = serial.CreatedAt

                    });;
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error podczas zbierania numerow seryjnych: {ex.Message}");
            }
        }

        public void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var serialNumbers = _apiService.GenerateSerialNumberAsync(ProductNameTextBox.Text);
            Debug.WriteLine(serialNumbers);
            FetchSerialNumbers();
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeServerDiscovery();
        }
    }

    public class SerialItem
    {
        public string SerialNumber { get; set; }
        public string ProductName { get; set; }
        public DateTimeOffset DateGenerated { get; set; }
    }
}
