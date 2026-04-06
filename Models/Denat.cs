using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace wprawka_01.Models
{
    public class Denat : Osoba
    {
        [Required]
        public DateTime DataZgonu { get; set; }

        [Required]
        public int KlientId { get; set; }

        [ValidateNever]
        public Klient Klient { get; set; }

        [Required]
        public int PlacowkaId { get; set; }

        [ValidateNever]
        public Placowka AktualnaPlacowka { get; set; }
    }
}