using Microsoft.AspNetCore.Mvc;
using Pico_Backend.Interface;
using Pico_Backend.Models;
namespace Pico_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WashingMachineController : BaseController<WashingMachine>
    {
        private readonly IWashingMachineRepository _washingmachineRepository;
        public WashingMachineController(IWashingMachineRepository washingmachineRepository) : base(washingmachineRepository)
        {
            _washingmachineRepository = washingmachineRepository;
        }
    }
}
