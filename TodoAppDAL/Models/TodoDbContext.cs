using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoAppDAL.Models;

public partial class TodoDbContext : DbContext
{
    public TodoDbContext()
    {
    }

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Credential> Credentials { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CredentialsId).ValueGeneratedOnAdd();
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserPass)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Credentials_User");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__profile__3214EC07E32D862A");

            entity.ToTable("profile");

            entity.HasIndex(e => e.Email, "UQ__profile__A9D10534F65C0D78").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsUserActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.TodoId).HasName("PK__todos__9586255200E4DDA8");

            entity.ToTable("todos");

            entity.Property(e => e.CreatedData)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsCompleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsTodoActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Task).IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Todos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Todo_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
