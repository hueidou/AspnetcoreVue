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
        /// <value></value>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}