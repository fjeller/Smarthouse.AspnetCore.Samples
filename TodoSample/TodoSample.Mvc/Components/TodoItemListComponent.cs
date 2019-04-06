using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoSample.Core.Models;
using TodoSample.Core.Repositories.Interfaces;
using TodoSample.Core.Services.Interfaces;

namespace TodoSample.Mvc.Components
{
	/// =================================================================================================================
	/// <summary>
	/// The ViewComponent to display the todoitems. Basically a controller class that returns a 
	/// single view.
	/// </summary>
	/// =================================================================================================================
	[ViewComponent(Name ="TodoItemList")]
	public class TodoItemListComponent : ViewComponent
	{
		#region Fields

		private readonly ITodoService _todoService;

		#endregion

		#region Invoke 

		/// =================================================================================================================
		/// <summary>
		/// The Invoke Command using the default view which must be called "Default", and must be
		/// under the folder with the name of the view component or the name of the viewcomponent
		/// without the suffix "ViewComponent" if that suffic exists
		/// </summary>
		/// <returns>A <see cref="IViewComponentResult"/> containing the view for the component</returns>
		/// =================================================================================================================
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<TodoItemModel> items = await this._todoService.GetAllTodoItems();
			return View( items );
		}

		#endregion 


		#region constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="todoService">The todoservice</param>
		/// =================================================================================================================
		public TodoItemListComponent( ITodoService todoService )
		{
			this._todoService = todoService;
		}

		#endregion

	}
}
