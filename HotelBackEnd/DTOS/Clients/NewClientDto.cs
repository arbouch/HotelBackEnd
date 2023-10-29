namespace HotelBackEnd.DTOS.Clients
{
    public class NewClientDto
    {
        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }

    }
}
