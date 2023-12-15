using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Pico_Backend.Interface;
using Pico_Backend.Models;
using Pico_Backend.Repository;

namespace Pico_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GroupConfigController : Controller
    {
        [HttpGet("{groupConfigID}")]
        public async Task<IActionResult> GetGroupConfig(int groupConfigID)
        {
            try
            {
                var repo = new GroupConfigRepository("User Id=root;Host=localhost;Database=pico;Character Set=utf8;Password=orion66;");
                var result = await repo.GetGroupConfig(groupConfigID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
