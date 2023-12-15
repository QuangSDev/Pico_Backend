using Pico_Backend.Models;

namespace Pico_Backend.Interface
{
    public interface IGroupConfigRepository
    {
        Task<IEnumerable<GroupConfig>> GetGroupConfig(int groupConfigID);
    }
}
