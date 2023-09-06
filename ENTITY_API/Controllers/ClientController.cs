using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;
using Services.Services;

namespace ENTITY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpPost]
        //Create uchun

        public async Task<IActionResult> CreateClient([FromForm] ClientDto clientDto)
        {
            await clientRepository.CreateClientAsync(clientDto);

            return Ok("Created");
        }




        [HttpGet("clientid")]
        public async Task<IActionResult> GetClientId(Guid clientId)
        {
            var client = await clientRepository.GetClientByIdAsync(clientId);
            return Ok(client);
        }




        [HttpGet]

        public async Task<IActionResult> GetAllClents()
        {
            var clients = await clientRepository.GetAllAsync();

            return Ok(clients);
        }




        [HttpPut("clientId")]
        public async Task<IActionResult> GetClientId(Guid clientId, [FromForm] ClientDto clientDto)
        {
            await clientRepository.UpdateClientAsync(clientId, clientDto);
            return Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            await clientRepository.DeleteClientAsync(clientId);

            return Ok("Deleted");
        }
    }
}
