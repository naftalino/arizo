using bot.Database;
using bot.Database.Models;
using bot.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace bot.Operations
{
    public static class UserOperations
    {
        public static void Run()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlite("Data Source=database.db")
            .Options;

            using var context = new DatabaseContext(options);
            var repo = new UserRepository(context);

            // var newProduct = new User { Id = "2057492020", CardQuantity = 0, Coins = 0, Points = 1000 };
            // repo.Create(newProduct);

            var usuario = repo.Read(2057492020);
            if (usuario != null)
            {
                Console.WriteLine($"ID: {usuario.Id}\nCoins: {usuario.Coins}\nBio: {usuario.Bio}");
            }

            // Atualizar produto
            // product!.Price = 2300.00m;
            // repo.Update(product);
            // Console.WriteLine("Preço atualizado!");

            // // Listar produtos
            // var products = repo.GetAll();
            // Console.WriteLine("Produtos no estoque:");
            // foreach (var p in products)
            // {
            //     Console.WriteLine($"- {p.Name} ({p.Stock} unidades)");
            // }

            // // Deletar produto
            // repo.Delete(product.Id);
            // Console.WriteLine("Produto deletado!");
        }
    }
}
