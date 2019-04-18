using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataSample.DataAccess
{
    public partial class TodoDataContext : DbContext
    {
        public TodoDataContext()
        {
        }

        public TodoDataContext(DbContextOptions<TodoDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriesToTodoItem> CategoriesToTodoItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<TodoItem> TodoItems { get; set; }

        public virtual DbSet<PageImpression> PageImpressions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<CategoriesToTodoItem>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.TodoItemId });

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoriesToTodoItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriesToTodoItems_Categories");

                entity.HasOne(d => d.TodoItem)
                    .WithMany(p => p.CategoriesToTodoItems)
                    .HasForeignKey(d => d.TodoItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriesToTodoItems_TodoItems");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.DueDate)
                    .IsRequired();
            });

            modelBuilder.Entity<PageImpression>(entity => { entity.Property(e => e.IpAddress).HasMaxLength(20); });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}