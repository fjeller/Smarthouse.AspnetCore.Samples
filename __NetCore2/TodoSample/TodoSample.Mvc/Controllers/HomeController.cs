using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoSample.Core.Models;
using TodoSample.Core.Services.Interfaces;
using TodoSample.Mvc.Models;

namespace TodoSample.Mvc.Controllers
{
	public class HomeController : Controller
	{
		#region fields

		private readonly ITodoService _todoService;

		#endregion

		/// =================================================================================================================
		/// <summary>
		/// Returns the initial default view
		/// </summary>
		/// <returns>The initial default view</returns>
		/// =================================================================================================================
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache( Duration = 0, Location = ResponseCacheLocation.None, NoStore = true )]
		public IActionResult Error()
		{
			return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
		}

		#region Save a todo item

		/// =================================================================================================================
		/// <summary>
		/// Saves a todoitem
		/// </summary>
		/// <param name="model">The todoitemmodel to save</param>
		/// =================================================================================================================
		[HttpPost]
		public async Task<IActionResult> SaveTodoItem( NewTodoItemModel model )
		{
			await this._todoService.SaveTodoItem( model );
			return RedirectToAction( nameof( Index ) );
		}

		#endregion

		#region Toggles the state of a todoitem and returns the view component

		/// =================================================================================================================
		/// <summary>
		/// Toggles the state of a todoitem
		/// </summary>
		/// <param name="id">The id of the todoitem to toggle</param>
		/// <returns>The viewcomponent with the todoitems</returns>
		/// =================================================================================================================
		public async Task<IActionResult> ToggleState( int id )
		{
			await this._todoService.ToggleDone( id );
			return ViewComponent( "TodoItemList" );
		}

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="todoService">The todoservice</param>
		/// =================================================================================================================
		public HomeController( ITodoService todoService )
		{
			this._todoService = todoService;
		}

		#endregion
	}
}
