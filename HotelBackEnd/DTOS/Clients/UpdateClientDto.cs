namespace HotelBackEnd.DTOS.Clients
{
    public class UpdateClientDto
    {
        public int IdClient { get; set; }
        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }

    }
}
