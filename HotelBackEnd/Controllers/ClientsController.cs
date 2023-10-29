using HotelBackEnd.DTOS.Clients;
using HotelBackEnd.Interfaces;
using HotelBackEnd.Results;
using Microsoft.AspNetCore.Mvc;

namespace HotelBackEnd.Controllers
{
    public class ClientsController : Controller
    {
         private readonly IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;

        }
        [HttpPost("api/Client/AjoutClient")]
        public OperationResult<NewClientDto> AddClient([FromBody] NewClientDto newClientDto)
        {
            return _clientsService.AjoutClient(newClientDto);
        }
        [HttpPost("api/Client/GetByCIN")]
        public OperationResult<ClientDto> GetClientByCIN([FromBody] int CinClient)
        {
            return _clientsService.GetClientByCIN(CinClient);
        }
        [HttpPut("api/Client/ModificationClient")]
        public OperationResult<UpdateClientDto> UpdateClient([FromBody] UpdateClientDto updateClientDto)
        {
            return _clientsService.ModificationClient(updateClientDto);
        }
        [HttpGet("api/Client/RechercheClients")]
        public OperationResult<List<ClientDto>> RechercheClients()
        {
            return _clientsService.RechercheClients();
        }
        [HttpDelete("api/Client/SupprimerClient")]
        public OperationResult<int> SupprimerClient(int SupprimerClientId)
        {
            return _clientsService.SupprimerClient(SupprimerClientId);
        }

    }
}
