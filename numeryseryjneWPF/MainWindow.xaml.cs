﻿using numeryseryjneWPF.Services;
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
        public ObservableCollection<SerialItem> FilteredSerialItems { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SerialItems = new ObservableCollection<SerialItem>();
            FilteredSerialItems = new ObservableCollection<SerialItem>();
            SerialDataGrid.ItemsSource = SerialItems;
<<<<<<< HEAD
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
=======
            SerialDataGrid.ItemsSource = FilteredSerialItems;
>>>>>>> b6fe57609f037ff5c326d9ecfbdf5bbfbafba063
        }

        public void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            var serialNumbers = _apiService.GenerateSerialNumberAsync(ProductNameTextBox.Text);
            Debug.WriteLine(serialNumbers);
            FetchSerialNumbers();
=======
            if (string.IsNullOrEmpty(ProductNameTextBox.Text))
            {
                MessageBox.Show("Proszę podać nazwę produktu.", "Brak danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            SerialItems.Add(new SerialItem
            {
                SerialNumber = "ABC123456", // Możesz potem wygenerować losowy
                ProductName = ProductNameTextBox.Text,
                DateGenerated = DateTime.Now

            });
            ApplyFilters();

>>>>>>> b6fe57609f037ff5c326d9ecfbdf5bbfbafba063
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

<<<<<<< HEAD
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeServerDiscovery();
        }
=======
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SerialDataGrid.IsReadOnly = !SerialDataGrid.IsReadOnly;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var serialItem = button.DataContext as SerialItem;
            if (serialItem != null)
            {
                if (MessageBox.Show($"Usunąć {serialItem.SerialNumber}?", "Potwierdzenie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    SerialItems.Remove(serialItem);
                }
            }
            ApplyFilters();
        }


        private void MainWindow_MouseDown(object sender, RoutedEventArgs e)
        {
            if (SerialDataGrid.IsReadOnly == false)
            {
                SerialDataGrid.IsReadOnly = true;
            }
        }

        private void ApplyFilters()
        {
            var filtered = SerialItems.AsEnumerable();

            // Filtruj według numeru seryjnego
            if (!string.IsNullOrEmpty(SerialNumberFilterTextBox.Text))
            {
                filtered = filtered.Where(item => item.SerialNumber.Contains(SerialNumberFilterTextBox.Text));
            }

            // Filtruj według nazwy produktu
            if (!string.IsNullOrEmpty(ProductNameFilterTextBox.Text))
            {
                filtered = filtered.Where(item => item.ProductName.Contains(ProductNameFilterTextBox.Text));
            }

            // Filtruj według daty
            if (DateFilter.SelectedDate.HasValue)
            {
                filtered = filtered.Where(item => item.DateGenerated.Date == DateFilter.SelectedDate.Value.Date);
            }

            // Zaktualizuj filtrowaną kolekcję
            FilteredSerialItems.Clear();
            foreach (var item in filtered)
            {
                FilteredSerialItems.Add(item);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

>>>>>>> b6fe57609f037ff5c326d9ecfbdf5bbfbafba063
    }

    public class SerialItem
    {
        public string SerialNumber { get; set; }
        public string ProductName { get; set; }
        public DateTimeOffset DateGenerated { get; set; }
    }
}
