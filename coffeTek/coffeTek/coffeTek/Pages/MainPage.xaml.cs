using coffeTek.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;

namespace coffeTek.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient()
            { BaseAddress = new Uri("https://desafio-mobility.herokuapp.com/") };
        public ObservableCollection<ProductViewModel> Productions { get; set; }
        private JsonSerializer _serializer = new JsonSerializer();

        public MainPage()
        {
            InitializeComponent();

            

            Productions = GetProducts();
            lstView.ItemsSource = Productions;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ProductViewModel;
            // Your code here
        }

        private ObservableCollection<ProductViewModel> GetProducts()
        {
            try
            {
                var response = _httpClient.GetAsync("products.json").Result;
                response.EnsureSuccessStatusCode();

                using (var stream = response.Content.ReadAsStreamAsync().Result)
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    return _serializer.Deserialize<ResultProducts>(json).Products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
