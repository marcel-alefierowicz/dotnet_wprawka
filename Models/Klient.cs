using System.ComponentModel.DataAnnotations;

namespace wprawka_01.Models
{
    public class Klient : Osoba
    {
        [MaxLength(12)]
        [RegularExpression("^\\d{3}-\\d{3}-\\d{3}$", ErrorMessage = "Numer telefonu musi byc w formacie XXX-XXX-XXX.")]
        public string? NumerTel { get; set; }

        public ICollection<Denat> Denaci { get; set; } = new List<Denat>();
    }
}