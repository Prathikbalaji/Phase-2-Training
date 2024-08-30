using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCdbfirst.Models;

public partial class MvccodefirstContext : DbContext
{
    public MvccodefirstContext()
    {
    }

    public MvccodefirstContext(DbContextOptions<MvccodefirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=MVCcodefirst;integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid);

            entity.Property(e => e.EmpSalary).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.HasIndex(e => e.Eid, "IX_Projects_Eid");

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.Projects).HasForeignKey(d => d.Eid);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
