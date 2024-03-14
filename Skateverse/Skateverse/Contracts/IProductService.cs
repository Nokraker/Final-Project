using Skateverse.Data.Models;
using Skateverse.Models;

namespace Skateverse.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
        bool Add(AddProductModel model);

        void AddCart(string UserId, Guid productId);
        List<CartViewModel> ViewShoppingCart(string UserId);

        Product FullProductPage(Guid productId);
    }
}
