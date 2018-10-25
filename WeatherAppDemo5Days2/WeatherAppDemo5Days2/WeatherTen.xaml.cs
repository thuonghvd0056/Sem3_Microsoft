﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherAppDemo5Days2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeatherTen : Page
    {
        public WeatherTen()
        {
            this.InitializeComponent();
            collection = new ObservableCollection<List>();
            this.DataContext = this;
        }

        public ObservableCollection<List> collection { get; set; }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var postion = await LocationData.getPosition();

            var lat = postion.Coordinate.Latitude;
            var lon = postion.Coordinate.Longitude;

            RootObject forecast = await APIManager.GetWeather(lat, lon);
            CityTextBlock.Text = forecast.city.name + " City";
            for (int i = 0; i < 5; i++)
            {
                collection.Add(forecast.list[i]);
            }
            ForeCastGridView.ItemsSource = collection;
        }
    }
}
