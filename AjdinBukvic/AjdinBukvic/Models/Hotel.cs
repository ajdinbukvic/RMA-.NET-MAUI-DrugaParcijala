using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjdinBukvic.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelNaziv { get; set; }
        public string Nivo { get; set; }
        public string KratkiOpis { get; set; }
        public string Adresa { get; set; }
        public string DostupneSobe { get; set; }
        public string PreporuceniAranzman { get; set; }
        public string Opis { get; set; }
        public string Fotografija { get; set; }
        public double CijenaMin { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}