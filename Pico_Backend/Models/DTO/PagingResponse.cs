namespace Pico_Backend.Models.DTO
{
    public class PagingResponse<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public int TotalRecord { get; set; }
    }
}
