using HotelBackEnd.DTOS.Clients;
using HotelBackEnd.Models;

namespace HotelBackEnd.Mapper
{
    public class ClientMapper
    {
        public static List<ClientDto> ClientsListeMapper(List<Client> clients)
        {
            if (clients == null)
            {
                return null;
            }

            return clients.Select(client => new ClientDto
            {
                IdClient = client.IdClient,
                Nom = client.Nom,
                Prenom = client.Prenom,
                CIN = client.CIN,
                DateDeNaissance = client.DateDeNaissance,
            }).ToList();
        }
            public static Client NewClientToModel(NewClientDto newClient)
        {
            if (newClient == null)
            {
                return null;
            }

            return new Client
            {
                CIN = newClient.CIN,
                DateDeNaissance = newClient.DateDeNaissance,
                Nom = newClient.Nom,
                Prenom = newClient.Prenom,
             };
        }

        public static ClientDto ClienteByIdeMapper(Client client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientDto
            {
                IdClient = client.IdClient,
                CIN = client.CIN,
                Nom = client.Nom,
                Prenom = client.Prenom,
                DateDeNaissance = client.DateDeNaissance,
             };
        }
        public static Client UpdateVacheToModel(UpdateClientDto updateClientDto)
        {
            if (updateClientDto == null)
            {
                return null;
            }

            return new Client
            {
                IdClient = updateClientDto.IdClient,
                CIN = updateClientDto.CIN,
                Nom = updateClientDto.Nom,
                Prenom = updateClientDto.Prenom,
                DateDeNaissance = updateClientDto.DateDeNaissance,
            };
        }


    }
}
