using HotelBackEnd.DTOS.Clients;
using HotelBackEnd.Results;

namespace HotelBackEnd.Interfaces
{
    public interface IClientsService
    {
        public OperationResult<List<ClientDto>> RechercheClients();
        public OperationResult<ClientDto> GetClientByCIN(int IdVache);
        public OperationResult<NewClientDto> AjoutClient(NewClientDto newClient);
        public OperationResult<UpdateClientDto> ModificationClient(UpdateClientDto updateClient);
        public OperationResult<int> SupprimerClient(int SupprimerVacheId);

    }
}
