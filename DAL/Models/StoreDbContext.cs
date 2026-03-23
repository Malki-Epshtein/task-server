using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class StoreDbContext : DbContext
{
    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KindTask> KindTasks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StoreDb;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<KindTask>(entity =>
        {
            entity.HasKey(e => e.PasswordKind).HasName("PK__tmp_ms_x__DD3F3FADC352DE6C");

            entity.ToTable("kindTask");

            entity.Property(e => e.PasswordKind).HasColumnName("passwordKind");
            entity.Property(e => e.KindNameTask)
                .HasMaxLength(20)
                .HasColumnName("kindNameTask");
            entity.Property(e => e.Tcolor)
                .HasMaxLength(20)
                .HasColumnName("tcolor");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PK__task__C3E0F4DAC7C552A9");

            entity.ToTable("task");

            entity.Property(e => e.IdTask).HasColumnName("idTask");
            entity.Property(e => e.DataTask).HasColumnName("dataTask");
            entity.Property(e => e.Discreption)
                .HasMaxLength(20)
                .HasColumnName("discreption");
            entity.Property(e => e.PasswordKind).HasColumnName("passwordKind");
            entity.Property(e => e.TColort)
                .HasMaxLength(20)
                .HasColumnName("tColort");
            entity.Property(e => e.TzUser)
                .HasMaxLength(20)
                .HasColumnName("tzUser");

            entity.HasOne(d => d.PasswordKindNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PasswordKind)
                .HasConstraintName("FK_task_kindTask");

            entity.HasOne(d => d.TzUserNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TzUser)
                .HasConstraintName("FK_task_userTask");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.TzUser).HasName("PK__userTask__B8F6DCF561D3BD55");

            entity.ToTable("userTask");

            entity.Property(e => e.TzUser)
                .HasMaxLength(20)
                .HasColumnName("tzUser");
            entity.Property(e => e.NameUser)
                .HasMaxLength(20)
                .HasColumnName("nameUser");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(20)
                .HasColumnName("passwordUser");
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
