using AutoService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Data;

public class AutoServiceDbContext : DbContext
{
    public DbSet<Car> Araclar { get; set; }
    public DbSet<User> Kullanicilar { get; set; }
    public DbSet<Brand> Markalar { get; set; }
    public DbSet<Customer> Musteriler { get; set; }
    public DbSet<Role> Roller { get; set; }
    public DbSet<Sales> Satislar { get; set; }
    public DbSet<Service> Servisler { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(@"server=OKAN\SQLEXPRESS; database=AutoService; integrated security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().Property(m => m.Name).IsRequired().HasColumnType("varchar(50)");
        modelBuilder.Entity<Role>().Property(m => m.Name).IsRequired().HasColumnType("varchar(50)");
        modelBuilder.Entity<Role>().HasData(new Role
        {
            Id = 1,
            Name = "Admin"
        });
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Name = "Admin",
            IsActive = true,
            UploadDate = DateTime.Now,
            Email = "admin@otoservissatis.tc",
            UserName = "admin",
            Password = "123456",
            RoleId = 1,
            Surname = "admin",
            Phone = "0850"
        });
        base.OnModelCreating(modelBuilder);
    }
}
