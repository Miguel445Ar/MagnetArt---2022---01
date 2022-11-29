using MagnetArt.Authors.Domain.Models;
using MagnetArt.Providers.Domain.Models;
using MagnetArt.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MagnetArt.Shared.Persistance.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Provider> Providers { get; set; }
        //public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Providers
            builder.Entity<Provider>().ToTable("Providers");
            builder.Entity<Provider>().HasKey(p => p.Id);
            builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Provider>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Provider>().Property(p => p.LastName).IsRequired();
            builder.Entity<Provider>().Property(p => p.ApiUrl).HasDefaultValue("http://api-default/");
            builder.Entity<Provider>().Property(p => p.KeyRequired).HasDefaultValue(false);
            builder.Entity<Provider>().Property(p => p.ApiKey).HasDefaultValue("defaultApiKey");


            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
