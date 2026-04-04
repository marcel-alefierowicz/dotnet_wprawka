using System.ComponentModel.DataAnnotations;

namespace wprawka_01.Models
{
    public class Klient : Osoba
    {
        [MaxLength(20)]
        public string? NumerTel { get; set; }

        public ICollection<Denat> Denaci { get; set; } = new List<Denat>();
    }
}