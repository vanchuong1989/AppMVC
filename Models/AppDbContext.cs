using Microsoft.EntityFrameworkCore;

namespace AppMVC.Models
{
    public class AppDbContext : DbContext
    {
        // razorweb.models.MyBlogContext
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
                //..
                // this.Roles
                // IdentityRole<string>
            }

            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
                base.OnConfiguring(builder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                //{
                //    var tableName = entityType.GetTableName();
                //    if (tableName.StartsWith("AspNet"))
                //    {
                //        entityType.SetTableName(tableName.Substring(6));
                //    }
                //}

            }       
        }
}
