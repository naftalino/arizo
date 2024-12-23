using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bot.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            // Configuração do banco de dados
            optionsBuilder.UseSqlite("Data Source=database.db");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
