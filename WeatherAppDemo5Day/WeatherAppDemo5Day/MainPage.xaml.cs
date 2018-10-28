using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherAppDemo5Day
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            collection = new ObservableCollection<List>();
            this.DataContext = this;
        }

        public ObservableCollection<List> collection { get; set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var postion = await LocationData.getPosition();

            var lat = postion.Coordinate.Latitude;
            var lon = postion.Coordinate.Longitude;

            RootObject forecast = await APIManager.GetWeather(lat, lon);
            CityTextBlock.Text = forecast.city.name + " City";
            for (int i = 0; i < forecast.list.Count; i++)
            {
                //collection.Add(forecast.list[i]);
                for (int j = 0; j < forecast.list[i].weather.Count; j++)
                {
                    string icon = string.Format("ms-appx:///Assets/Weather/{0}.png", forecast.list[i].weather[j].icon);
                    var listReplace = forecast.list[i].weather[j];
                    listReplace.icon = icon;
                }

                collection.Add(forecast.list[i]);
            }
            ForeCastGridView.ItemsSource = collection;
        }
    }
}
