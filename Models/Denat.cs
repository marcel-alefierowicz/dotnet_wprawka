using System.ComponentModel.DataAnnotations;

namespace wprawka_01.Models
{
    public class Denat : Osoba
    {
        [Required]
        public DateTime DataZgonu { get; set; }

        public int KlientId { get; set; }
        public Klient Klient { get; set; } = null!;

        public int? PlacowkaId { get; set; }
        public Placowka? AktualnaPlacowka { get; set; }
    }
}