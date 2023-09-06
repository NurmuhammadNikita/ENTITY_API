using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services.Services
{
    public class ClientRepository : IClientRepository
    {
        private readonly MarketDB marketDB;

        public ClientRepository(MarketDB marketDB)
        {
            this.marketDB = marketDB;
        }

        public async Task CreateClientAsync(ClientDto client)
        {
            var createClient = new Client()
            {
                Id = Guid.NewGuid(),
                FirsName = client.FirsName,
                LastName = client.LastName,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,

            };

            await marketDB.Clients.AddAsync(createClient);
            await marketDB.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            var deleteClient = await marketDB.Clients.FirstOrDefaultAsync(c => c.Id == clientId); 
            
            marketDB.Clients.Remove(deleteClient);
            marketDB.SaveChanges();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var clients = await marketDB.Clients.ToListAsync();
            return clients;
        }

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            var client = await marketDB.Clients.FirstOrDefaultAsync(c => c.Id == clientId);

            return client;
        }

        public async Task UpdateClientAsync(Guid clientId, ClientDto clientDto)
        {
            var client = await marketDB.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
            client.FirsName  = clientDto.FirsName;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.PhoneNumber = clientDto.PhoneNumber;

            
            marketDB.Clients.Update(client);

            marketDB.SaveChanges();

            
        }
    }
}
