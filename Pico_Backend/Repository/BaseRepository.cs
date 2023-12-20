using Dapper;
using MySqlConnector;
using Pico_Backend.Interface;
using Pico_Backend.Models.DTO;
using System.Data;
using System.Data.Common;
using System.Text.Json;

namespace Pico_Backend.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {

        private readonly DbConnection _connection;
        public BaseRepository()
        {
            _connection = new MySqlConnection("User Id=root;Host=localhost;Database=pico;Character Set=utf8;Password=;");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            //dùng query trực tiếp

            /*try
            {
                _connection.Open();

                // Thực hiện truy vấn SQL trực tiếp
                var query = "SELECT * FROM conditioner"; // Thay YourTableName bằng tên bảng cần truy vấn

                var result = await _connection.QueryAsync<T>(query);

                _connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi lấy dữ liệu: " + ex.Message);
                _connection.Close(); // Đảm bảo kết nối được đóng khi có lỗi
                throw; // Ném ngoại lệ để báo hiệu việc xảy ra lỗi
            }
            */
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetAll"; _connection.Open();
            var result = await _connection.QueryAsync<T>(storedProcedureName, commandType: CommandType.StoredProcedure);
            _connection.Close();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            string storedProcedureName = $"Proc_{typeof(T).Name}_GetByID";
            var parameters = new DynamicParameters();
            _connection.Open();
            parameters.Add($"m_{typeof(T).Name}ID", id);
            var record = await _connection.QueryFirstOrDefaultAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            _connection.Close();
            return record;
        }

        public async Task<PagingResponse<T>> GetPaging(string? keyword, object? filterObject, int pageSize = 20, int pageNumber = 1)
        {
            var parameters = new DynamicParameters();
            _connection.Open();
            parameters.Add("keyword", keyword);
            parameters.Add("filterObject", JsonSerializer.Serialize(filterObject));
            parameters.Add("pageSize", pageSize);
            parameters.Add("pageNumber", pageNumber - 1);
            var query = await _connection.QueryMultipleAsync($"Proc_{typeof(T).Name}_GetPaging", parameters, commandType: CommandType.StoredProcedure);
            var records = query.Read<T>().ToList();
            var totalRecord = query.Read<int>().First();
            _connection.Close();
            return new PagingResponse<T> { Data = records, TotalRecord = totalRecord };
        }

        public async Task<int> Insert(T item)
        {
            string storedProcedureName = $"Proc_{typeof(T).Name}_Insert";
            var parameters = new DynamicParameters();
            _connection.Open();
            parameters.Add("@data", JsonSerializer.Serialize(item));
            var rowsAffected = await _connection.ExecuteAsync(storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);
            _connection.Close();
            return rowsAffected;
        }

        public async Task<int> Update(int id, T item)
        {
            string storedProcedureName = $"Proc_{typeof(T).Name}_Update";
            var parameters = new DynamicParameters();
            _connection.Open();
            parameters.Add("@data", JsonSerializer.Serialize(item));
            var rowsAffected = await _connection.ExecuteAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            _connection.Close();
            return rowsAffected;
        }

        public async Task<int> Delete(int id, string tableName)
        {
            var procedureName = $"Proc_{tableName}_Delete";
            var dynamicParameters = new DynamicParameters();
            _connection.Open();
            dynamicParameters.Add("@id", id);
            var rowsAffected = await _connection.ExecuteAsync(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
            _connection.Close();
            return rowsAffected;
        }

        public async Task<int> DeleteMany(int[] ids, string tableName)
        {
            var procedureName = $"Proc_{tableName}_Delete";
            var dynamicParameters = new DynamicParameters();
            _connection.Open();
            dynamicParameters.Add("@ids", string.Join(",", ids));
            var rowsAffected = await _connection.ExecuteAsync(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
            _connection.Close();
            return rowsAffected;

        }

    }
}
