using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pico_Backend.Interface;
using Pico_Backend.Models;

namespace Pico_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiComController : BaseController<NoiComcs>
    {
        private readonly INoiComRepositoty _noicomRepository;
        public NoiComController(INoiComRepositoty noicomRepository) : base(noicomRepository)
        {
            _noicomRepository = noicomRepository;
        }
    }
}
