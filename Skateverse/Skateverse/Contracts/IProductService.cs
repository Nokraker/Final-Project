using Skateverse.Data.Models;
using Skateverse.Models;

namespace Skateverse.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
        Task Add(AddProductModel model);

        Task AddCart(string UserId, Guid productId);
        Task<List<CartViewModel>> ViewShoppingCart(string UserId);

        Task<Product> FullProductPage(Guid productId);

        Task UpTheCountOfAProductInACart(Guid cartId);
        Task LowerTheCountOfAProductInACart(Guid cartId);

        Task AddToFavourites(Guid productId, string userId);
        Task<List<Favourite>> ViewFavourites(string userId);
        Task RemoveFromFavourites(Guid productId,string userId);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Product>> GetAllFilteredProductsAsync(Guid categoryId);
    }
}
