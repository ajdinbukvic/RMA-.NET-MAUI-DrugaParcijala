using AjdinBukvic.Models;

namespace AjdinBukvic;

public partial class DetaljiHotela : ContentPage
{
    public string cijena2 { get; set; }
    public string udaljenost2 { get; set; }
	public DetaljiHotela(Hotel odabrani, User korisnik)
	{
		InitializeComponent();
		slika.Source = odabrani.Fotografija;
		cijena2 = odabrani.CijenaMin.ToString();
        cijena.Text = $"$ {odabrani.CijenaMin}";
        naziv.Text = odabrani.HotelNaziv;
		kratkiopis.Text = odabrani.KratkiOpis;
		adresa.Text = odabrani.Adresa;
		sobe.Text = $"{odabrani.DostupneSobe} Rooms";
		ponuda.Text = odabrani.PreporuceniAranzman;
		opis.Text = odabrani.Opis;

        Location Odredište = new Location(odabrani.Latitude, odabrani.Longitude);
		double _udaljenost = Location.CalculateDistance(korisnik.Latitude, korisnik.Longitude, Odredište, DistanceUnits.Kilometers);
        udaljenost2 = Math.Round(_udaljenost, 2).ToString();
        udaljenost.Text = Math.Round(_udaljenost, 2).ToString() + " km";

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		double cijenaCalc = double.Parse(udaljenost2) * 0.5;
        double cijenaTro = double.Parse(cijena2) + (double.Parse(cijena2) * 0.3);
        string poruka = "Udaljenost: " + udaljenost2 +
         "\nCijena: ".ToString() + cijenaCalc.ToString() +
         "\nCijena dvokrevetne: ".ToString() + cijena2 +
         "\nCijena trokrevetne: ".ToString() + cijenaTro.ToString();

        DisplayAlert("Kalkulacija", poruka, "OK");
    }
}