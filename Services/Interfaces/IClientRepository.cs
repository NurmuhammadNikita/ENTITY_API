using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services.Interfaces
{
    public interface IClientRepository
    {
        public Task CreateClientAsync(ClientDto client);
        public Task<Client> GetClientByIdAsync(Guid clientId);
        public Task<List<Client>> GetAllAsync();
        public Task UpdateClientAsync(Guid clientId, ClientDto clientDto);
        public Task DeleteClientAsync(Guid clientId);
    }
}
