using AjdinBukvic.Models;
using System.Linq.Expressions;

namespace AjdinBukvic;

public partial class MainPage : ContentPage
{
    public IList<Hotel> HotelList { get; set; }
    public User korisnik { get; set; }
    public MainPage()
	{
		InitializeComponent();
        korisnik = new User();
        HotelList = new List<Hotel>
        {
            new Hotel
            {
                Id = 1, HotelNaziv = "Hotel Tarcin", Nivo="5", KratkiOpis="Tarcin Forest Resort & Spa Sarajevo", Adresa="Vilovac B B, Sarajevo 7124", DostupneSobe="3", PreporuceniAranzman="Brekfast", Opis = "Duis vestibulum elit vel neque pharetra vulputate. Quisque scelerisque nisi urna. Duis rutrum non risus in imperdiet.", Fotografija = "tarcin.jpg", CijenaMin = 250.0, Longitude = 17.27059, Latitude = 44.34203
            },

            new Hotel
            {
               Id = 2, HotelNaziv = "Hotel Blanca", Nivo="5", KratkiOpis="Hotel Blanca Resort & Spa", Adresa="Babanovac Bb Vlašić, 72286", DostupneSobe="5", PreporuceniAranzman="All Inclusice", Opis = "Duis vestibulum elit vel neque pharetra vulputate. Quisque scelerisque nisi urna. Duis rutrum non risus in imperdiet.", Fotografija = "blanca.jpg", CijenaMin = 350.0, Longitude = 17.191000, Latitude = 44.772182
            },

            new Hotel
            {
                Id = 3, HotelNaziv = "Hotel Europe", Nivo="5", KratkiOpis="Stay in the heart of Sarajevo", Adresa="Vladislava Skarica 5, Sarajevo 71000", DostupneSobe="7", PreporuceniAranzman="All Inclusive", Opis = "Duis vestibulum elit vel neque pharetra vulputate. Quisque scelerisque nisi urna. Duis rutrum non risus in imperdiet.", Fotografija = "europa.jpg", CijenaMin = 450.0, Longitude = 17.66583, Latitude = 44.22637
            },

            new Hotel
            {
                Id = 4, HotelNaziv = "Hotel Swissotel", Nivo="5", KratkiOpis="Get the celebrity treatment with world-class service", Adresa="Vrbanja 1, Sarajevo 71000", DostupneSobe="3", PreporuceniAranzman="Brekfast", Opis = "Duis vestibulum elit vel neque pharetra vulputate. Quisque scelerisque nisi urna. Duis rutrum non risus in imperdiet.", Fotografija = "swiss.jpg", CijenaMin =  550.0, Longitude = 18.413029, Latitude = 43.856430
            },

            new Hotel
            {
                Id = 5, HotelNaziv = "Hotel Malak", Nivo="5", KratkiOpis="Malak Regency Hotel", Adresa="Ilidža bb, Sarajevo 71000", DostupneSobe="8", PreporuceniAranzman="Brekfast", Opis = "Duis vestibulum elit vel neque pharetra vulputate. Quisque scelerisque nisi urna. Duis rutrum non risus in imperdiet.", Fotografija = "malak.jpg", CijenaMin = 650.0, Longitude = 15.868565, Latitude = 44.811962
            },
        };
        BindingContext = this;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var myListView = (ListView)sender;
        var odabrano = (Hotel)listview.SelectedItem;
        await Navigation.PushAsync(new DetaljiHotela(odabrano, korisnik));
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(20)));
            }

            korisnik.Latitude = location.Latitude;
            korisnik.Longitude = location.Longitude;
        }
        catch(Exception ex) {
            await DisplayAlert("Greska", ex.Message, "OK");
            return;
        }
    }
}

