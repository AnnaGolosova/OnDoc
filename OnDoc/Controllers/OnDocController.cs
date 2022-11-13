using Microsoft.AspNetCore.Mvc;
using OnDoc.Entities;
using OnDoc.Gateways;

namespace OnDoc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnDocController : ControllerBase
    {
        private readonly ILogger<OnDocController> _logger;

        public OnDocController(ILogger<OnDocController> logger)
        {
            _logger = logger;
        }

        [HttpPost(nameof(AddMachine))]
        public async Task<IActionResult> AddMachine(Machines newEntity)
        {
            var gateway = new MachinesGateway();

            return Ok(await gateway.AddMachine(newEntity));
        }

        [HttpPost(nameof(AddMRI))]
        public async Task<IActionResult> AddMRI(MRI newEntity)
        {
            var gateway = new MriGateway();

            return Ok(await gateway.AddMRI(newEntity));
        }

        [HttpPost(nameof(AddExecutor))]
        public async Task<IActionResult> AddExecutor(EXECUTOR newEntity)
        {
            var gateway = new PersonsGateway();

            return Ok(await gateway.AddExecutor(newEntity));
        }
    }
}