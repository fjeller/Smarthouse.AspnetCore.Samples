using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiddlewareSample.DataAccess.DataAccess
{
	public partial class MiddlewareSampleContext : DbContext
	{
		public MiddlewareSampleContext()
		{
		}

		public MiddlewareSampleContext( DbContextOptions<MiddlewareSampleContext> options )
			: base( options )
		{
		}

		public virtual DbSet<PageImpression> PageImpressions { get; set; }


		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			modelBuilder.HasAnnotation( "ProductVersion", "2.2.0-rtm-35687" );

			modelBuilder.Entity<PageImpression>( entity =>
			 {
				 entity.Property( e => e.IpAddress ).HasMaxLength( 20 );
			 } );

			OnModelCreatingPartial( modelBuilder );
		}

		partial void OnModelCreatingPartial( ModelBuilder modelBuilder );
	}
}