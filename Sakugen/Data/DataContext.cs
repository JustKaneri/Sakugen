using Microsoft.EntityFrameworkCore;
using Sakugen.Models;

namespace Sakugen.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
        }

        public DbSet<Record> Records { get; set; }
    }
}
