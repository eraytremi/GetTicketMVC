using GetTicketMVC.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace GetTicketMVC.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options)
        {
        }

        public DbSet<CityModel> CityModels { get; set; }
    }
}
