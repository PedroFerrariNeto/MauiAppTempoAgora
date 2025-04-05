using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.sunrise} \n" +
                                         $"Por do Sol: {t.sunset} \n" +
                                         $"Temp Máx: {t.temp_max} \n" +
                                         $"Temp Min: {t.temp_min} \n" +
                                         $"Previsão do tempo: {t.description} \n" +
                                         $"Velocidade do vento: {t.speed} \n" +
                                         $"Visibiliadade: {t.visibility} \n";


                        lbl_res.Text = dados_previsao;
                    }
                    else
                    {
                        lbl_res.Text = "Nome da Cidade não encontrada, por favor digite novamente";
                    }

                }
                else
                {
                    lbl_res.Text = "Nome da Cidade não encontrada, por favor digite novamente!";
                }

            }
            catch
            {
                
               await DisplayAlert("Ops", "Verique sua conexão com internet", "OK");
                
            }
        }

    }
}
