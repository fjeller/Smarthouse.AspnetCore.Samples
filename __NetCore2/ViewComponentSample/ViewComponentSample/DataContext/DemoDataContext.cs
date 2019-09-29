using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Helpers;

namespace ViewComponentSample.DataContext
{
	public class DemoDataContext : DbContext
	{
		#region The dbset

		public DbSet<PersonEntity> PersonEntities { get; set; }

		#endregion

		#region Seeding the data

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			List<PersonEntity> people = PersonCreator.CreatePeople( 10 );
			modelBuilder.Entity<PersonEntity>().HasData( people );
		}

		#endregion

		#region constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="options">The options</param>
		public DemoDataContext(DbContextOptions<DemoDataContext> options) : base(options)
		{

		}

		#endregion
	}

}
