using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pico_Backend.Interface;
using Pico_Backend.Models;

namespace Pico_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DieuHoaController : BaseController<DieuHoa>
    {
        private readonly IDieuHoaRepository _dieuhoaRepository;
        public DieuHoaController(IDieuHoaRepository dieuhoaRepository) : base(dieuhoaRepository)
        {
            _dieuhoaRepository = dieuhoaRepository;
        }
    }
}
