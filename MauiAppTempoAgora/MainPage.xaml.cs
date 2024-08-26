using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Service;
using System.Diagnostics;


namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource _cancelTokenSource;
        bool _isCheckingLocation;

        string? cidade;

        public MainPage()
        {
            InitializeComponent();
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                _cancelTokenSource = new CancellationTokenSource();

                GeolocationRequest request =
                    new GeolocationRequest(GeolocationAccuracy.Medium,
                    TimeSpan.FromSeconds(10));

                Location? location = await Geolocation.Default.GetLocationAsync(
                    request, _cancelTokenSource.Token);

                if (location != null)
                {
                    lbl_latitude.Text = location.Latitude.ToString();
                    lbl_longitude.Text = location.Longitude.ToString();

                    Debug.WriteLine("_________________");
                    Debug.WriteLine(location);
                    Debug.WriteLine("_________________");

                }
            }

            catch (FeatureNotEnabledException fnsEx)
            {
                await DisplayAlert("Erro: Dispositivo não suporta", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Erro: Localização Desabilitada", fneEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Erro: Permissão", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro: ", ex.Message, "OK");
            }

        }
        
        private async 
        
    }
}
