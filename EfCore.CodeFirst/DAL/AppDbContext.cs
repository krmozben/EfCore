using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        //public DbSet<ProductEssential> ProductEssentials { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<ProductFull> ProductFulls { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to one
            //modelBuilder.Entity<Category>().HasMany(x=>x.Products).WithOne(x=>x.Category).HasForeignKey(x=>x.Category_Id);

            // one to many
            //modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id).OnDelete(DeleteBehavior.Cascade);

            // many to many
            //modelBuilder
            //    .Entity<Student>()
            //    .HasMany(x => x.Teachers)
            //    .WithMany(x => x.Students)
            //    .UsingEntity<Dictionary<string, object>>(
            //    "ST",
            //    x=>x.HasOne<Teacher>().WithMany().HasForeignKey("T_Id").HasConstraintName("fk_tid"),
            //    x=>x.HasOne<Student>().WithMany().HasForeignKey("S_Id").HasConstraintName("fk_sid")
            //    );

            // owned
            //modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p =>
            //{
            //    p.Property(x => x.FirstName).HasColumnName("FirstName");
            //    p.Property(x => x.LastName).HasColumnName("LastName");
            //    p.Property(x => x.Age).HasColumnName("Age");
            //});

            //modelBuilder.Entity<Manager>().OwnsOne(x => x.Person);

            //keyless
            //modelBuilder.Entity<ProductFull>().HasNoKey();

            // notmaped
            //modelBuilder.Entity<Product>().Ignore(x=>x.Barcode);

            //IsUnicode
            //modelBuilder.Entity<Product>().Property(x=>x.Name).IsUnicode(false);

            //ColumnType
            //modelBuilder.Entity<Product>().Property(x=>x.Name).HasColumnType("varchar(50)");

            //Index
            //modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => new { x.Stock, x.Price });
            //modelBuilder.Entity<Product>() .HasIndex(x => new { x.Name, x.Price });

            //modelBuilder.Entity<ProductEssential>().HasNoKey().ToSqlQuery("select Name,Price from products");
            //modelBuilder.Entity<ProductFull>().HasNoKey().ToView("ProductFull");
            //modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
            //modelBuilder.Entity<ProductFull>().ToFunction("fc_product_full");

            //modelBuilder.Entity<ProductFull>().Metadata.SetIsTableExcludedFromMigrations(true);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(x =>
            {
                if (x.State == EntityState.Added)
                {

                }

            });

            return base.SaveChanges();
        }
    }
}
