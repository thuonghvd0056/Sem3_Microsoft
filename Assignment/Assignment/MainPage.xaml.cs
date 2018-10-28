using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace Assignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            collection = new ObservableCollection<RootObject>();
            this.DataContext = this;
        }

        public ObservableCollection<RootObject> collection { get; set; }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                if (NetworkInterface.GetIsNetworkAvailable())
            {
                List<string> contentList = new List<string>();
                List<RootObject> data = await APIManager.GetNews();
                for (int i = 0; i < data.Count; i++)
                {
                    string deleteHtml = RemoveHtmlTag(data[i].content.rendered);
                    var splitContent = deleteHtml.Split('.');
                    var showConent = splitContent[0] + "." + splitContent[1] + "." + splitContent[2] + "." + splitContent[3];
                    data[i].content.rendered = showConent;
                    collection.Add(data[i]);
                }
                ForeCastGridView.ItemsSource = collection;
            }
        }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
        private static string RemoveHtmlTag(string value)
        {
            var regex1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var regex2 = Regex.Replace(regex1, @"\s{2,}", " ");
            return regex2;
        }
    }
}
