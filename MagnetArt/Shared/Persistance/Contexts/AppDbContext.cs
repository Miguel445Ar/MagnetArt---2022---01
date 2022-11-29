using MagnetArt.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace MagnetArt.Shared.Persistance.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
