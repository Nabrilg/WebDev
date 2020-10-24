namespace WebDev.Api.Context
{
    using Microsoft.EntityFrameworkCore;
    using  Model; //Saves writing

    public class AppDbContext : DbContext
    {
        #region Initialization
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        #endregion Initialization

        #region Properties
        public DbSet<User> Users { get; set; }
        #endregion
    }
}