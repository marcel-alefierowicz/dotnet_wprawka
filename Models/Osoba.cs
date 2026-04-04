using System.ComponentModel.DataAnnotations;

namespace wprawka_01.Models
{
    public abstract class Osoba
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }
    }
}