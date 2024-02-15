using Skateverse.Models;

namespace Skateverse.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllAsync();
    }
}
