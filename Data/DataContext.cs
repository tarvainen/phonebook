using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
