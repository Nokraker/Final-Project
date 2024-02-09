using Skateverse.Models;

namespace Skateverse.Contracts
{
    public interface IProdcutService
    {
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
    }
}
