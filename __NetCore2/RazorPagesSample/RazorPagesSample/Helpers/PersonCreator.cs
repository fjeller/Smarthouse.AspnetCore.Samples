using System;
using System.Collections.Generic;
using RazorPagesSample.DataContext;

namespace RazorPagesSample.Helpers
{
	public static class PersonCreator
	{
		#region Definitions

		private static List<string> _maleFirstNames = new List<string>()
		{
			"Jonas",
			"Luca",
			"Leon",
			"Finn",
			"Ben",
			"Elias",
			"Noah",
			"Liam",
			"Paul",
			"Milan",
			"Julian",
			"Louis",
			"Felix",
			"Maximilian",
			"Lukas",
			"Emil",
			"Levi",
			"Henry",
			"David",
			"Max"
		};

		private static List<string> _femaleFirstNames = new List<string>()
		{
			"Mia",
			"Emma",
			"Sophie",
			"Leonie",
			"Emilia",
			"Marie",
			"Mila",
			"Lina",
			"Lena",
			"Emily",
			"Lea",
			"Ella",
			"Amelie",
			"Lara",
			"Sophia",
			"Anna",
			"Luna",
			"Hannah",
			"Lia",
			"Leni"
		};

		private static List<string> _lastNames = new List<string>()
		{
			"Müller",
			"Schmidt",
			"Schneider",
			"Fischer",
			"Meyer",
			"Weber",
			"Hofmann",
			"Wagner",
			"Becker",
			"Schulz",
			"Schäfer",
			"Koch",
			"Bauer",
			"Richter",
			"Klein",
			"Schröder",
			"Wolf",
			"Neumann",
			"Schwarz",
			"Schmitz"
		};

		private static List<string> _streetNames = new List<string>()
		{
			"Alte Straße",
			"Neue Straße",
			"Goethestraße",
			"Schillerstraße",
			"Langer Weg",
			"Frankfurter Straße",
			"Berliner Straße",
			"Untere Flur",
			"Obere Flur",
			"Akazienweg",
			"Tulpenweg",
			"Akademiestraße",
			"Adenauerallee",
			"Eckstraße",
			"Hauptstraße",
			"Frühlingsstraße",
			"Hirrschstraße",
			"Douglasstraße",
			"Karlstraße",
			"Kriegstraße"
		};

		private static List<string> _cities = new List<string>()
		{
			"Karlsruhe",
			"Düsseldorf",
			"Berlin",
			"Hamburg",
			"Köln",
			"Essen",
			"Dortmund",
			"Stuttgart",
			"München",
			"Aachen",
			"Saarbrücken",
			"Hannover",
			"Rosenheim",
			"Duisburg",
			"Freiburg",
			"Mainz",
			"Wiesbaden",
			"Mannheim",
			"Ludwigshafen",
			"Heidelberg"
		};

		#endregion

		#region Random Number Generator

		private static readonly Random _rng = new Random( 5000 );

		#endregion

		/// <summary>
		/// Creates a single person including the address
		/// </summary>
		/// <param name="isFemale">if true, the first name is a female name, if false a male one</param>
		/// <param name="id">The id for the person. Not needed if not used in a database</param>
		/// <returns>A Person including address</returns>
		public static PersonEntity CreateSinglePerson( bool isFemale, int id=0 )
		{
			int index = _rng.Next( 20 );
			string firstName = isFemale ? _femaleFirstNames[index] : _maleFirstNames[index];

			int zipCode = _rng.Next( 10000, 99999 );

			PersonEntity result = new PersonEntity
			{
				Id=id,
				FirstName = firstName,
				City = _cities[_rng.Next( 20 )],
				LastName = _lastNames[_rng.Next( 20 )],
				Street = _streetNames[_rng.Next( 20 )],
				ZipCode = zipCode.ToString()
			};

			return result;
		}

		/// <summary>
		/// Creates the specified number of people
		/// </summary>
		/// <param name="count">The number of people to create</param>
		/// <returns>A List with the number of people in it</returns>
		public static List<PersonEntity> CreatePeople( int count )
		{
			List<PersonEntity> result = new List<PersonEntity>();
			for ( int i = 0; i < count; i++ )
			{
				bool isFemale = _rng.Next( 100 ) < 50;  // 50% boys and girls
				result.Add( CreateSinglePerson( isFemale, i+1 ) );
			}

			return result;
		}

	}
}
