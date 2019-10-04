using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MiddlewareSample.DataAccess.Entities;

namespace MiddlewareSample.DataAccess.Context
{
    public partial class MiddlewareDataContext : DbContext
    {
        public MiddlewareDataContext()
        {
        }

        public MiddlewareDataContext(DbContextOptions<MiddlewareDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PageImpression> PageImpressions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageImpression>(entity =>
            {
                entity.Property(e => e.IpAddress).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
