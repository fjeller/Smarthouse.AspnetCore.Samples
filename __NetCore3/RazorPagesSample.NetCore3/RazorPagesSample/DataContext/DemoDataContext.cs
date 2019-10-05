using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RazorPagesSample.Helpers;

namespace RazorPagesSample.DataContext
{
	public class DemoDataContext : DbContext
	{

		#region The dbset

		/// =================================================================================================================
		/// <summary>
		/// The DbSet
		/// </summary>
		/// =================================================================================================================
		public DbSet<PersonEntity> PersonEntities { get; set; }

		#endregion

		#region Seeding the data

		/// =================================================================================================================
		/// <summary>
		/// In this method the data is seeded into the in-memory-database
		/// </summary>
		/// <param name="modelBuilder">The model builder defining the shape of the entities</param>
		/// =================================================================================================================
		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			List<PersonEntity> people = PersonCreator.CreatePeople( 10 );
			modelBuilder.Entity<PersonEntity>().HasData( people );
		}

		#endregion

		#region constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="options">The options</param>
		/// =================================================================================================================
		public DemoDataContext(DbContextOptions<DemoDataContext> options) : base(options)
		{

		}

		#endregion

	}

}
