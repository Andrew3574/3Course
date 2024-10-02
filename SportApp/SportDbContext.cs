using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SportApp.Models;
using SportApp.Views;

namespace SportApp;

public partial class SportDbContext : DbContext
{
    public SportDbContext()
    {
    }

    public SportDbContext(DbContextOptions<SportDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Excercise> Excercises { get; set; }

    public virtual DbSet<ExcerciseView> ExcerciseViews { get; set; }

    public virtual DbSet<Muscle> Muscles { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<SetExcercise> SetExcercises { get; set; }

    public virtual DbSet<SetExcerciseView> SetExcerciseViews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ANDREW\\SQLEXPRESS;Initial Catalog=SportDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Excercise>(entity =>
        {
            entity.HasKey(e => e.ExcerciseId).HasName("PK__Excercis__62B6E49346D85F04");

            entity.HasIndex(e => e.Name, "UQ__Excercis__737584F60CB96E56").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.Muscle).WithMany(p => p.Excercises)
                .HasForeignKey(d => d.MuscleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Excercise__Muscl__5812160E");
        });

        modelBuilder.Entity<ExcerciseView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExcerciseView");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Excercise)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Muscle)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Muscle>(entity =>
        {
            entity.HasKey(e => e.MuscleId).HasName("PK__Muscles__A75D077E2C2B72EA");

            entity.HasIndex(e => e.Name, "UQ__Muscles__737584F605BEB7D5").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.SetId).HasName("PK__Sets__7E08471D914E0589");

            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Sets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Sets__UserId__5441852A");
        });

        modelBuilder.Entity<SetExcercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SetExcer__3214EC075EF733B1");

            entity.HasOne(d => d.Excercise).WithMany(p => p.SetExcercises)
                .HasForeignKey(d => d.ExcerciseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__SetExcerc__Excer__5AEE82B9");

            entity.HasOne(d => d.Set).WithMany(p => p.SetExcercises)
                .HasForeignKey(d => d.SetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__SetExcerc__SetId__5BE2A6F2");
        });

        modelBuilder.Entity<SetExcerciseView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SetExcerciseView");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Excercise)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Set)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C520F34E1");

            entity.HasIndex(e => e.Login, "UQ__Users__5E55825B1E71D77E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AF01AD97").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
