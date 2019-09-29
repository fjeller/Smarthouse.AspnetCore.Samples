using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TodoSample.Core.DataAccess;
using TodoSample.Core.Models;
using TodoSample.Core.Services.Interfaces;

namespace TodoSample.RazorPages.Pages
{
	public class IndexModel : PageModel
	{
		#region Fields

		private readonly ITodoService _todoService;

		#endregion

		#region Properties

		/// =================================================================================================================
		/// <summary>
		/// The new name for a todoitem
		/// </summary>
		/// =================================================================================================================
		[BindProperty]
		[Required]
		[DisplayName("Name")]
		public string NewName { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The new duedate for a todoitem
		/// </summary>
		/// =================================================================================================================
		[BindProperty]
		[Required]
		[DisplayName("Due Date")]
		[DataType(DataType.Date)]
		public DateTime DueDate { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The current todoitems
		/// </summary>
		/// =================================================================================================================
		public List<TodoItemModel> TodoItems { get; set; }

		#endregion

		#region OnGetAsync()

		public async Task OnGetAsync()
		{
			DueDate = DateTime.Now;
			TodoItems = await this._todoService.GetTodoItemsForToday();
		}

		#endregion

		#region OnPostAsync()

		public async Task<IActionResult> OnPostAsync()
		{
			TodoItemModel model = new TodoItemModel()
			{
				DueDate = DueDate,
				Name = NewName,
				IsDone = false
			};
			await this._todoService.SaveTodoItem( model );
			return RedirectToPage( "/index" );
		}

		public async Task<PartialViewResult> OnGetToggle( [FromQuery]int id )
		{
			/* CAREFUL */
			// This is a handler method returning a partial view. However, it seems that the only model
			// you can use inside the IndexModel is ... the indexmodel. You cannot change the model due to
			// an error occuring:
			// System.InvalidOperationException: The model item passed into the ViewDataDictionary is of type 'System.Collections.Generic.List`1[TodoSample.Core.Models.TodoItemModel]', but this ViewDataDictionary instance requires a model item of type 'System.Collections.Generic.List`1[TodoSample.Core.DataAccess.TodoItem]'.


			await this._todoService.ToggleDone( id );
			this.TodoItems = await this._todoService.GetTodoItemsForToday();

			var result = Partial( "_TodoItems", this );

			return result;
		}

		#endregion

		#region constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="todoService">The todoservice</param>
		/// =================================================================================================================
		public IndexModel( ITodoService todoService )
		{
			_todoService = todoService;
		}

		#endregion
	}
}
