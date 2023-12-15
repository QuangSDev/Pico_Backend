using Microsoft.AspNetCore.Mvc;
using Pico_Backend.Interface;
using Pico_Backend.Models;

namespace Pico_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TelevisonController : BaseController<Televison>
    {
        private readonly ITelevisonRepository _televisonRepository;
        public TelevisonController(ITelevisonRepository televisonRepository) : base(televisonRepository)
        {
            _televisonRepository = televisonRepository;
        }
    }
}
