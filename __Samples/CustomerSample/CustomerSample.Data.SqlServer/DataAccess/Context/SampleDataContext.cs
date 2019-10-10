using System;
using CustomerSample.Data.SqlServer.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerSample.Data.SqlServer.DataAccess.Context
{
    public partial class SampleDataContext : DbContext
    {
        public SampleDataContext()
        {
        }

        public SampleDataContext(DbContextOptions<SampleDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TagsToCustomers> TagsToCustomers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TagsToCustomers>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.TagId });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
