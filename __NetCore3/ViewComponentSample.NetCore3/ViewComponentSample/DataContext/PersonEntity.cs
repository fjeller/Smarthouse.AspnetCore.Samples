﻿namespace ViewComponentSample.DataContext
{
	public class PersonEntity
	{

		/// =================================================================================================================
		/// <summary>
		/// The id of the person entity
		/// </summary>
		/// =================================================================================================================
		public int Id { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The first name of the person
		/// </summary>
		/// =================================================================================================================
		public string FirstName { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The last name of the person
		/// </summary>
		/// =================================================================================================================
		public string LastName { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The street the person lives in
		/// </summary>
		/// =================================================================================================================
		public string Street { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The zip code of the city the person lives in
		/// </summary>
		/// =================================================================================================================
		public string ZipCode { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The city the person lives in
		/// </summary>
		/// =================================================================================================================
		public string City { get; set; }

	}
}
