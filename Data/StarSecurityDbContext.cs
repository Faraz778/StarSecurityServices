using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;

namespace StarSecurityServices.Data;

public partial class StarSecurityDbContext : DbContext
{
    public StarSecurityDbContext()
    {
    }

    public StarSecurityDbContext(DbContextOptions<StarSecurityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StarSecurityDB;User Id=admin;Password=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Branches__3214EC07DDD59562");

            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.Cities).HasMaxLength(200);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Region).HasMaxLength(50);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC076D18EFBF");

            entity.Property(e => e.ClientName).HasMaxLength(100);
            entity.Property(e => e.IconClass).HasMaxLength(50);
            entity.Property(e => e.ServicesAvailed).HasMaxLength(200);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0721A3A679");

            entity.HasIndex(e => e.EmployeeCode, "UQ__Employee__1F64254852CD3CCD").IsUnique();

            entity.Property(e => e.Achievements).HasMaxLength(500);
            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.EmployeeCode).HasMaxLength(20);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Grade).HasMaxLength(50);
            entity.Property(e => e.Qualification).HasMaxLength(100);

            entity.HasOne(d => d.Client).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Employees__Clien__5165187F");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC07DFBABAB9");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IconClass).HasMaxLength(50);
            entity.Property(e => e.ServiceName).HasMaxLength(100);
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Testimon__3214EC07B93596AB");

            entity.Property(e => e.ClientName).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(800);
            entity.Property(e => e.Role).HasMaxLength(150);
            entity.Property(e => e.Stars).HasDefaultValue(5);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC079417B20C");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4A2304EE1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105343EDA7B43").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("Employee");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Users__EmployeeI__5DCAEF64");
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vacancie__3214EC07C92EE7B1");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.JobType).HasMaxLength(50);
            entity.Property(e => e.PostedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
