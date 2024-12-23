using bot.Database.Models;

namespace bot.Database.Interfaces
{
    public interface IShopInterface
    {
        Task<List<Shop>> GetShopItems();
        Task<Shop> CreateShopItem(Shop shop);
        Task<Shop> UpdateShopItem(int Id, Shop shop);
        Task<Shop> DeleteShopItem(int Id);
    }
}