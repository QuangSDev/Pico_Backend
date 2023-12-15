using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pico_Backend.Interface;

namespace Pico_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field
        private readonly IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructor
        public BaseController(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var records = await _baseRepository.GetAll();
                if (records != null)
                {
                    return StatusCode(200, records);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var record = await _baseRepository.GetById(id);
                if (record != null)
                {
                    return StatusCode(200, record);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Lọc dữ liệu
        /// </summary>
        /// <param name="keyword">Từ khóa</param>
        /// <param name="pageSize">Số bản ghi trên trang</param>
        /// <param name="pageNumber">Trang</param>
        /// <returns>Danh sách bản ghi được lọc</returns>
        [HttpPost("Paging")]
        public async Task<IActionResult> Post(string? keyword, [FromBody] object? filterObject, int pageSize = 20, int pageNumber = 1)
        {
            try
            {

                var data = await _baseRepository.GetPaging(keyword, filterObject, pageSize, pageNumber);
                if (data != null)
                {
                    return StatusCode(200, data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="item">Dữ liệu</param>
        /// <returns>Trả về message</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T item)
        {
            try
            {
                await _baseRepository.Insert(item);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="item">Dữ liệu</param>
        /// <returns>Message</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, T item)
        {
            try
            {
                await _baseRepository.Update(id, item);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Message</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var rowsAffected = await _baseRepository.Delete(id, typeof(T).Name);
                if (rowsAffected != 0)
                {
                    return StatusCode(200, rowsAffected);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Xóa nhiều
        /// </summary>
        /// <param name="ids">Danh sách các id cần xóa</param>
        /// <returns>Số cột ảnh hưởng</returns>
        [HttpDelete("DeleteMany")]
        public async Task<IActionResult> DeleteMany([FromBody] int[] ids)
        {
            try
            {
                var rowsAffected = await _baseRepository.DeleteMany(ids, typeof(T).Name);
                if (rowsAffected != 0)
                {
                    return StatusCode(200, rowsAffected);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
