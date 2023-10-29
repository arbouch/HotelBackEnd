using HotelBackEnd.Context;
using HotelBackEnd.DTOS.Clients;
using HotelBackEnd.Interfaces;
using HotelBackEnd.Mapper;
using HotelBackEnd.Models;
using HotelBackEnd.Results;
using Microsoft.EntityFrameworkCore;

namespace HotelBackEnd.Services
{
    public class ClientsService : IClientsService
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public ClientsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public OperationResult<NewClientDto> AjoutClient(NewClientDto newClient)
        {
            if (newClient == null)
            {
                return new OperationResult<NewClientDto>
                {
                    ErrorMessage = "Données Invalides",
                    Success = false,

                };
            }

            var AddClient = ClientMapper.NewClientToModel(newClient);
            _applicationDbContext.clients.Add(AddClient);
            _applicationDbContext.SaveChanges();
            return new OperationResult<NewClientDto>(newClient);

        }

        public OperationResult<ClientDto> GetClientByCIN(int CinClient)
        {
            if (CinClient < 1)
            {
                return new OperationResult<ClientDto>
                {
                    Success = false,
                    ErrorMessage = "Verifier l'ID en parametre."
                };
            }

            var client = _applicationDbContext.clients.Where(i => i.CIN == CinClient).FirstOrDefault();
            if (client == null)
            {
                return new OperationResult<ClientDto>
                {
                    Success = false,
                    ErrorMessage = "Aucun Client est trouvée avec l'ID en parametre."
                };
            }

            var ClietDto = ClientMapper.ClienteByIdeMapper(client);
            var result = new OperationResult<ClientDto>(ClietDto);
            return result;

        }

        public OperationResult<UpdateClientDto> ModificationClient(UpdateClientDto updateClient)
        {
            if (updateClient == null)
            {
                return new OperationResult<UpdateClientDto>
                {
                    Success = false,
                    ErrorMessage = "Verifier les données en parametre."
                };

            }
            var VacheToUpdate = _applicationDbContext.clients.AsNoTracking().Where(i => i.IdClient == updateClient.IdClient).FirstOrDefault();
            if (VacheToUpdate == null)
            {
                return new OperationResult<UpdateClientDto>
                {
                    Success = false,
                    ErrorMessage = "Aucune Vache est trouvée avec l'ID en parametre."
                };

            }
            var ClientUpdated = ClientMapper.UpdateVacheToModel(updateClient);
            _applicationDbContext.clients.Update(ClientUpdated);
            _applicationDbContext.SaveChanges();
            return new OperationResult<UpdateClientDto>(updateClient);

        }

        public OperationResult<List<ClientDto>> RechercheClients()
        {
            try
            {
                List<Client> ClientsList = _applicationDbContext.clients.ToList();

                List<ClientDto> ClientDTOList = ClientMapper.ClientsListeMapper(ClientsList);

                var result = new OperationResult<List<ClientDto>>(ClientDTOList);

                return result;
            }
            catch (Exception ex)
            {
                return new OperationResult<List<ClientDto>>(ex.Message);
            }
        }

        public OperationResult<int> SupprimerClient(int SupprimerClientId)
        {
            if (SupprimerClientId < 1)
            {
                return new OperationResult<int>()
                {
                    Success = false,
                    ErrorMessage = "Verifier l'ID en parametre"
                };
            }
            var ClientAsupprimer = _applicationDbContext.clients.Where(i => i.IdClient == SupprimerClientId).FirstOrDefault();
            if (ClientAsupprimer == null)
            {
                return new OperationResult<int>
                {
                    Success = false,
                    ErrorMessage = "Aucun Client est trouvée avec l'ID en parametre."
                };
            }
            _applicationDbContext.clients.Remove(ClientAsupprimer);
            int affectedRows = _applicationDbContext.SaveChanges();
            if (affectedRows > 0)
            {
                return new OperationResult<int> { Success = true };
            }
            return new OperationResult<int> { Success = false };

        }

    }
}
