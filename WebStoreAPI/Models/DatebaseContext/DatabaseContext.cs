using Microsoft.EntityFrameworkCore;
namespace WebStoreAPI.Models.DatebaseContext
{
    public partial class DatabaseContext : DbContext
    {
       // public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<UserInfo>? UserInfos { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>( entity =>
            {
               // entity.HasNoKey();
                entity.ToTable("Products").HasKey( e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ProductId");
                entity.Property(e => e.Name).HasColumnType("nvarchar(100)");
                entity.Property(e => e.Category).HasColumnType("nvarchar(100)");
                entity.Property(e => e.Color).HasColumnType("nvarchar(50)");
                entity.Property(e => e.UnitPrice).HasColumnType("nvarchar(50)");
                entity.Property(e => e.AvailableQuantity);
            });
            modelBuilder.Entity<UserInfo>(entity =>
            {
                //entity.HasNoKey();
                entity.ToTable("UserInfo").HasKey(e => e.UserId); ;
                entity.Property(e => e.UserId);
                entity.Property(e => e.FistName).HasColumnName("FirstName").HasColumnType("nvarchar(50)");
                entity.Property(e => e.LastName).HasColumnType("nvarchar(50)");
                entity.Property(e => e.UserName).HasColumnType("nvarchar(50)");
                entity.Property(e => e.Email).HasColumnType("nvarchar(50)");
                entity.Property(e => e.Password).HasColumnType("nvarchar(50)");
                entity.Property(e => e.CreateDate).HasColumnName("CreatedDate").HasColumnType("datetime");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
