using System.ComponentModel.DataAnnotations;

namespace wprawka_01.Models
{
    public class Placowka
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Ulica { get; set; }

        [Required]
        [MaxLength(100)]
        public string Miasto { get; set; }

        [Required]
        [MaxLength(6)]
        public string KodPocztowy { get; set; }

        [MaxLength(20)]
        public string? NumerTelefonu { get; set; }

        public ICollection<Denat> Denaci { get; set; } = new List<Denat>();
    }
}