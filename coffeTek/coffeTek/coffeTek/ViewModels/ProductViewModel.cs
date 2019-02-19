using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace coffeTek.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public int Size { get; set; }
        public int Sugar { get; set; }
        public string[] Additional { get; set; }
        private string imageBase64;

        [JsonProperty("image")]
        public string ImageBase64
        {
            get { return imageBase64; }
            set
            {
                imageBase64 = value.Replace("data:image/png;base64,", "");
                OnPropertyChanged("imageBase64");
                OnPropertyChanged("Image");
            }
        }

        private Xamarin.Forms.ImageSource image;
        public Xamarin.Forms.ImageSource Image
        {
            get
            {
                return Xamarin.Forms.ImageSource.FromStream(
                    () => new MemoryStream(Convert.FromBase64String(imageBase64)));
            }
        }
    }

    public class ResultProducts
    {
        public ObservableCollection<ProductViewModel> Products { get; set; }
    }
}
