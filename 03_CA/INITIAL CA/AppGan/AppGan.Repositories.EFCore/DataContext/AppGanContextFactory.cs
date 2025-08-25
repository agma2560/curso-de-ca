using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AppGan.Repositories.EFCore.DataContext
{
    class AppGanContextFactory : IDesignTimeDbContextFactory<AppGanContext>
    {
        public AppGanContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<AppGanContext>();

            OptionBuilder.UseSqlServer("Server=DESKTOP-S3TGDJ8;Database=SoftGanDb;User ID=sa;Password=12345;TrustServerCertificate=True");

            return new AppGanContext(OptionBuilder.Options);
        }
    }
}
