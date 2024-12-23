using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface IWishlistInterface
    {
        Task<List<Wishlists>> GetWishlists();
        Task<Wishlists> GetWishlist(int Id);
        Task<Wishlists> CreateWishlist(Wishlists wishlist);
        Task<Wishlists> UpdateWishlist(int Id, Wishlists wishlist);
        Task<Wishlists> DeleteWishlist(int Id);
    }
}