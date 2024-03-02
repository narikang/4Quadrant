using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _4Quantrant.Models;

public partial class TodoqContext : DbContext
{
    public TodoqContext()
    {
    }

    public TodoqContext(DbContextOptions<TodoqContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("data source=todoq.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.DueDate)
                .HasColumnType("NUMERIC")
                .HasColumnName("due_date");
            entity.Property(e => e.ItemName)
                .HasColumnType("NUMERIC")
                .HasColumnName("item_name");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Completed)
               .HasColumnType("NUMERIC")
               .HasColumnName("completed");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
