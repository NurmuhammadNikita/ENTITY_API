using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IpurchaseRepository
    {
        public Task CreatePurchaseAsync(PurchaseDto purchase);
        public Task<Purchase> GetPurchaseByIdAsync(Guid purchaseId);
        public Task<List<Purchase>> GetAllAsync();
        public Task UpdatePurchaseAsync(Guid purchaseId, PurchaseDto purchaseDto);
        public Task DeletePurchaseAsync(Guid purchaseId);
    }
}
