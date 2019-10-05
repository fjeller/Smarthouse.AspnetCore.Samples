using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSample.DataContext;

namespace RazorPagesSample.Pages
{
    public class Index2Model : PageModel
    {
		#region Fields

		private readonly DemoDataContext _dataContext;

		#endregion

		#region Properties

		[BindProperty]
		[Required]
		public string FirstName { get; set; }

		[BindProperty]
		[Required]
		public string LastName { get; set; }

		/// <summary>
		/// The people to display in the page
		/// </summary>
		[BindProperty]
		public List<PersonEntity> People { get; set; }

		#endregion

		#region Get

		/// =================================================================================================================
		/// <summary>
		/// Returns the page
		/// </summary>
		/// <returns>The Page</returns>
		/// =================================================================================================================
		public async Task<IActionResult> OnGetAsync()
		{
			if ( People == null )
			{
				await GetDataAsync();
			}

			return Page();
		}

		#endregion

		#region Post

		/// =================================================================================================================
		/// <summary>
		/// The post request
		/// </summary>
		/// <returns>The page if possible</returns>
		/// =================================================================================================================
		public async Task<IActionResult> OnPostAsync()
		{
			// Hack - get the id
			PersonEntity lastEntity = this._dataContext.PersonEntities.OrderByDescending( p => p.Id ).FirstOrDefault();
			int id = lastEntity?.Id + 1 ?? 100;

			PersonEntity entity = new PersonEntity() { FirstName = FirstName, LastName = LastName, Id = id };

			this._dataContext.PersonEntities.Add( entity );
			await this._dataContext.SaveChangesAsync();
			return RedirectToPage( "/Index" );
		}

		#endregion

		#region methods

		/// =================================================================================================================
		/// <summary>
		/// Gets the data for the page
		/// </summary>
		/// <returns>The data for the page</returns>
		/// =================================================================================================================
		private async Task GetDataAsync()
		{
			People = await this._dataContext.PersonEntities
				.OrderBy( p => p.LastName )
				.ThenBy( p => p.FirstName )
				.ToListAsync();
		}

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dataContext">The data context</param>
		/// =================================================================================================================
		public Index2Model( DemoDataContext dataContext )
		{
			_dataContext = dataContext;
			_dataContext.Database.EnsureCreated();
		}

		#endregion
	}
}