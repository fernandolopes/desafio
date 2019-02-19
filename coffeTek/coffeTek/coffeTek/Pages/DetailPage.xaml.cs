using coffeTek.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace coffeTek.Pages
{
	public partial class DetailPage : ContentPage
	{
        private readonly ProductViewModel _model;
        private int Total = 0;

        public DetailPage (ProductViewModel model)
		{
            InitializeComponent();

            _model = model;
            imagen.Source = model.Image;
            product_name.Text = model.Title;
            SetCup(model.Size);
            SetAddons(model.Additional);
            SetSugar(model.Sugar);
		}

        #region - Comandos
        private void SetSugar(int sugar)
        {
            switch (sugar)
            {
                case 0:
                    no_sugar.Opacity = 100;
                    sugar1.Opacity = 0.3;
                    sugar2.Opacity = 0.3;
                    sugar3.Opacity = 0.3;
                    break;
                case 1:
                    no_sugar.Opacity = 0.3;
                    sugar1.Opacity = 100;
                    sugar2.Opacity = 0.3;
                    sugar3.Opacity = 0.3;
                    break;
                case 2:
                    no_sugar.Opacity = 0.3;
                    sugar1.Opacity = 0.3;
                    sugar2.Opacity = 100;
                    sugar3.Opacity = 0.3;
                    break;
                default:
                    no_sugar.Opacity = 0.3;
                    sugar1.Opacity = 0.3;
                    sugar2.Opacity = 0.3;
                    sugar3.Opacity = 100;
                    break;
            }
        }

        private void SetAddons(string[] adds)
        {
            if (adds != null && adds.Count() > 0) {
                foreach (var img in adds)
                {
                    var Imagem = new Image
                    {
                        Source = $"{img}.png",
                        MinimumHeightRequest = 20,
                        MinimumWidthRequest = 20,
                        HeightRequest = 20,
                        WidthRequest = 20,
                        Aspect = Aspect.AspectFill,
                        VerticalOptions = LayoutOptions.Center
                    };
                    adicionais.Children.Add(Imagem);

                }
            }
        }

        private void SetCup(int tamanho)
        {
            switch (tamanho)
            {
                case 1:
                    tamanho150.Opacity = 100;
                    tamanho200.Opacity = .30;
                    tamanho250.Opacity = .30;
                    medida.Text = "150ML";
                    break;
                case 2:
                    tamanho150.Opacity = .30;
                    tamanho200.Opacity = 100;
                    tamanho250.Opacity = .30;
                    medida.Text = "200ML";
                    break;
                default:
                    tamanho150.Opacity = .30;
                    tamanho200.Opacity = .30;
                    tamanho250.Opacity = 100;
                    medida.Text = "250ML";
                    break;
            }
        }

        private void OnHandleLess(object sender, EventArgs e)
        {
            Total -= 1;
            ChangeValue();

            if (Total <= 0)
            {
                less.IsEnabled = false;
                less.Opacity = .30;
            }
        }

        private void OnHandlePlus(object sender, EventArgs e)
        {
            Total += 1;
            ChangeValue();

            if (Total > 0)
            {
                less.IsEnabled = true;
                less.Opacity = 100;
            }
        }

        private void ChangeValue()
        {
            quantidade.Text = $"{Total}";
        }

        private void OnHandleAddCart(object sender, EventArgs e)
        {
            //salvar
        }
        #endregion
    }
}