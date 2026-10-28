using System.Data.Entity;

namespace RoleAuthorizationLab3.Data
{
    public class User_DataEntities : DbContext
    {
        public User_DataEntities() : base("name=User_DataEntities")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
            modelBuilder.Entity<Role>().ToTable("Roles", "dbo");
            modelBuilder.Entity<User>()
                .HasOptional(user => user.Role)
                .WithMany()
                .HasForeignKey(user => user.RoleID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
