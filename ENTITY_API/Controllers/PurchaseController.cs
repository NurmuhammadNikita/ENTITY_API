using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace ENTITY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IpurchaseRepository purchaseRepository;

        public PurchaseController(IpurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        [HttpPost]
        //Create uchun

        public async Task<IActionResult> CreatePurchase([FromForm] PurchaseDto PurchaseDto)
        {
            await purchaseRepository.CreatePurchaseAsync(PurchaseDto);

            return Ok("Created");
        }




        [HttpGet("companyid")]
        public async Task<IActionResult> GetPurchaseTypeId(Guid purchaseId)
        {
            var purchase = await purchaseRepository.GetPurchaseByIdAsync(purchaseId);
            return Ok(purchase);
        }




        [HttpGet]

        public async Task<IActionResult> GetAllPrurchses()
        {
            var purchases = await purchaseRepository.GetAllAsync();

            return Ok(purchases);
        }




        [HttpPut("PurchaseId ")]
        public async Task<IActionResult> GetPurchaseId(Guid purchaseId, [FromForm] PurchaseDto purchaseDto)
        {
            await purchaseRepository.UpdatePurchaseAsync(purchaseId, purchaseDto);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePurchase(Guid purchaseId)
        {
            await purchaseRepository.DeletePurchaseAsync(purchaseId);

            return Ok("Deleted");
        }
    }
}
