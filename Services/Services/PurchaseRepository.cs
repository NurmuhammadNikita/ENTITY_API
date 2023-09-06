using Domain.Models;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PurchaseRepository : IpurchaseRepository
    {
        private readonly MarketDB marketDB;

        public PurchaseRepository(MarketDB marketDB)
        {
            this.marketDB = marketDB;
        }


        public async Task CreatePurchaseAsync(PurchaseDto Purchase)
        {
            var purchase = new Purchase
            {
                Id =  Guid.NewGuid(),
                ClientId = Purchase.ClientId,
                ProductId = Purchase.ProductId,
                PurchaseDate = DateTime.Now,
            };

            await marketDB.Purchases.AddAsync(purchase);
            await marketDB.SaveChangesAsync();

        }

        public async Task DeletePurchaseAsync(Guid PurchaseId)
        {
            var Purchase = await marketDB.Purchases.FirstOrDefaultAsync(c => c.Id == PurchaseId);

            marketDB.Purchases.Remove(Purchase);
            await marketDB.SaveChangesAsync();
        }

        public async Task<List<Purchase>> GetAllAsync()
        {
            var Purchase = await marketDB.Purchases.ToListAsync();
            return Purchase;
        }

        public async Task<Purchase> GetPurchaseByIdAsync(Guid PurchaseId)
        {
            var Purchase = await marketDB.Purchases.FirstOrDefaultAsync(c => c.Id == PurchaseId);

            return Purchase;
        }

        public async Task UpdatePurchaseAsync(Guid PurchaseId, PurchaseDto PurchaseDto)
        {
            var purchase = marketDB.Purchases.FirstOrDefault(c => c.Id == PurchaseId);
            purchase.ClientId = PurchaseDto.ClientId;
            purchase.ProductId  = PurchaseDto.ProductId;

            marketDB.Purchases.Update(purchase);
            await marketDB.SaveChangesAsync();
        }
    }
}
