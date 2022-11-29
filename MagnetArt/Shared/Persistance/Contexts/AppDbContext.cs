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
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Providers
            builder.Entity<Provider>().ToTable("Providers");
            builder.Entity<Provider>().HasKey(p => p.Id);
            builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Provider>().Property(p => p.Name).IsRequired();
            builder.Entity<Provider>().Property(p => p.ApiUrl).HasDefaultValue("http://api-default/");
            builder.Entity<Provider>().Property(p => p.KeyRequired).HasDefaultValue(false);
            builder.Entity<Provider>().Property(p => p.ApiKey).HasDefaultValue("defaultApiKey");

            // Authors
            builder.Entity<Author>().ToTable("Authors");
            builder.Entity<Author>().HasKey(a => a.Id);
            builder.Entity<Author>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Author>().Property(a => a.FirstName).IsRequired();
            builder.Entity<Author>().Property(a => a.LastName).IsRequired();
            builder.Entity<Author>().Property(a => a.NickName).IsRequired();
            builder.Entity<Author>().Property(a => a.PhotoUrl).HasDefaultValue("www.algo.com");


            // Providers <>-> Authors
            builder.Entity<Provider>()
                .HasMany(p => p.Authors)
                .WithOne(a => a.Provider)
                .HasForeignKey(a => a.ProvidersId);

            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
