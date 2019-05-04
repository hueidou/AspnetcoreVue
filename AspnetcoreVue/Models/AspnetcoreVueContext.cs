using Microsoft.EntityFrameworkCore;

namespace AspnetcoreVue.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AspnetcoreVueContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AspnetcoreVueContext(DbContextOptions<AspnetcoreVueContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        }

        /// <summary>
        /// Users
        /// </summary>
        /// <value></value>
        public DbSet<User> Users {get;set;}

        /// <summary>
        /// TodoItems
        /// </summary>
        /// <value></value>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}