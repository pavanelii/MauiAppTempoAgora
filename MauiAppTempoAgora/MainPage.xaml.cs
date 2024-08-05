using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Service;
using System.Diagnostics;


namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        CancellationTokenSource _cancellationTokenSource;
        bool _isCheckingLocation;

        string? cidade;

        public MainPage()
        {
            InitializeComponent();
        }

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
        catch (FeatureNotEnabledException fnsEx)
        {
            await DisplayAlert("Erro: Localização Desabilitada", fnsEx.Message, "OK");
        }
    }
}
