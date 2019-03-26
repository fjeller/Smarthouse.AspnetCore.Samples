using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoSample.Core.DataTransferObjects;
using TodoSample.Core.Models;
using TodoSample.Core.Repositories.Interfaces;
using TodoSample.Core.Services.Interfaces;

namespace TodoSample.Core.Services
{
	/// =================================================================================================================
	/// <summary>
	/// The todoservice
	/// </summary>
	/// =================================================================================================================
	public class TodoService : ITodoService
	{
		#region fields

		private readonly ITodoRepository _todoRepository;

		#endregion

		#region public methods

		/// =================================================================================================================
		/// <summary>
		/// Gets all todos from the database including all tasks
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with all todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemModel>> GetAllTodoItems()
		{
			var items = await this._todoRepository.GetAllTodoItems();
			var result = items.Select( TodoItemModel.FromDataItem ).ToList();

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Gets the todos for a specific due date from the database
		/// </summary>
		/// <param name="dueDate">The due date to get the items for</param>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemModel>> GetTodoItemsForDate( DateTime dueDate )
		{
			var items = await this._todoRepository.GetTodoItemsForDate(dueDate);
			var result = items.Select( TodoItemModel.FromDataItem ).ToList();

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Gets all todod for today
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemModel>> GetTodoItemsForToday()
		{
			var items = await this._todoRepository.GetTodoItemsForDate( DateTime.Now.Date );
			var result = items.Select( TodoItemModel.FromDataItem ).ToList();

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Gets all todos for tomorrow
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemModel>> GetTodoItemsForTomorrow()
		{
			DateTime date = DateTime.Now.AddDays( 1 ).Date;
			var items = await this._todoRepository.GetTodoItemsForDate( date );
			var result = items.Select( TodoItemModel.FromDataItem ).ToList();

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Gets the todoitems that are overdue
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemModel>> GetOverdueTodoItems()
		{
			DateTime date = DateTime.Now.AddDays( -1 ).Date;
			var items = await this._todoRepository.GetTodoItemsForDate( date );
			var result = items.Select( TodoItemModel.FromDataItem ).ToList();

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Saves a todoitem in the database
		/// </summary>
		/// <param name="model">The todoitem data to save in the database</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		public async Task SaveTodoItem( TodoItemModel model )
		{
			TodoItemData data = model.ToDataItem();
			await this._todoRepository.SaveTodoItem( data );
		}

		/// =================================================================================================================
		/// <summary>
		/// Deletes the todoitem from the database
		/// </summary>
		/// <param name="id">the id of the todoitem</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		public async Task DeleteTodoItem( int id )
		{
			await this._todoRepository.DeleteTodoItem( id );
		}

		/// =================================================================================================================
		/// <summary>
		/// Toggles the done-bit for the todoitem with the given index
		/// </summary>
		/// <param name="id">The id of the todoitem to toggle</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		public async Task ToggleDone( int id )
		{
			await this._todoRepository.ToggleDone( id );
		}

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="todoRepository">The todorepository</param>
		/// =================================================================================================================
		public TodoService( ITodoRepository todoRepository )
		{
			_todoRepository = todoRepository;
		}

		#endregion
	}
}
