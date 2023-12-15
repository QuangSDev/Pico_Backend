using Microsoft.AspNetCore.Mvc;
using Pico_Backend.Models.DTO;

namespace Pico_Backend.Interface
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        public Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Task<T> GetById(int id);

        /// <summary>
        /// Lọc dữ liệu
        /// </summary>
        /// <param name="keyword">Từ khóa</param>
        /// <param name="pageSize">Số bản ghi trên trang</param>
        /// <param name="pageNumber">Trang</param>
        /// <returns>Danh sách bản ghi được lọc</returns>
        public Task<PagingResponse<T>> GetPaging(string? keyword, object? filterObject, int pageSize = 20, int pageNumber = 1);

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="item">Dữ liệu</param>
        public Task<int> Insert(T item);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="item">Dữ liệu</param>
        public Task<int> Update(int id, T item);

        /// <summary>
        /// Xóa bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        public Task<int> Delete(int id, string tableName);

        /// <summary>
        /// Xóa nhiều
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="tableName"></param>
        public Task<int> DeleteMany(int[] ids, string tableName);

    }
}
