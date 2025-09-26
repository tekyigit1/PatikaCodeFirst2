using Microsoft.EntityFrameworkCore;
using PatikaCodeFirst2.Models;

namespace PatikaCodeFirst2.Context;

public class PatikaSecondDbContext : DbContext
{
    public PatikaSecondDbContext() { }
    public PatikaSecondDbContext(DbContextOptions<PatikaSecondDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Veritabanı adı: PatikaCodeFirstDb2
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=PatikaCodeFirstDb2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tablo adlarını net ver (Users, Posts)
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Post>().ToTable("Posts");

        // User kuralları
        modelBuilder.Entity<User>(b =>
        {
            b.Property(p => p.Username).HasMaxLength(50).IsRequired();
            b.Property(p => p.Email).HasMaxLength(100).IsRequired();
            // (Opsiyonel) b.HasIndex(p => p.Email).IsUnique();
        });

        // Post kuralları + ilişki
        modelBuilder.Entity<Post>(b =>
        {
            b.Property(p => p.Title).HasMaxLength(150).IsRequired();
            b.Property(p => p.Content).IsRequired();

            b.HasOne(p => p.User)
             .WithMany(u => u.Posts)
             .HasForeignKey(p => p.UserId)
             .OnDelete(DeleteBehavior.Cascade); // kullanıcı silinirse post'lar da silinsin (opsiyon)
        });
    }
}
