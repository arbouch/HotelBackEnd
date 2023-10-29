using System.ComponentModel.DataAnnotations;

namespace HotelBackEnd.Models
{
    public class Client
    {
        [Key]
        public int IdClient{ get; set; } 
        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
    }
}
