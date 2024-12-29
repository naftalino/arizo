using Microsoft.EntityFrameworkCore;
using bot.Database.Models;

namespace bot.Database
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // try
            // {
            //     this.Database.Migrate();
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine("Erro ao migrar o db: " + e);
            // }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<RankingCaptivity> RankingCaptivities { get; set; }
        public DbSet<Rewards> Rewards { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Subserie> Subserie { get; set; }
        public DbSet<Wishlists> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>()
            .HasKey(c => new { c.UserId, c.CardId });

            modelBuilder.Entity<Collection>()
            .HasOne(c => c.Card)
            .WithMany()
            .HasForeignKey(c => c.CardId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Serie)
                .WithMany(s => s.Cards)
                .HasForeignKey(c => c.SerieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Serie>()
                .HasMany(s => s.Cards)
                .WithOne(c => c.Serie)
                .HasForeignKey(c => c.SerieId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}