using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoSample.Core.Models;

namespace TodoSample.Core.Services.Interfaces
{
	public interface ITodoService
	{

		/// =================================================================================================================
		/// <summary>
		/// Gets all todos from the database including all tasks
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with all todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemModel>> GetAllTodoItems();

		/// =================================================================================================================
		/// <summary>
		/// Gets the todos for a specific due date from the database
		/// </summary>
		/// <param name="dueDate">The due date to get the items for</param>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemModel>> GetTodoItemsForDate( DateTime dueDate );

		/// =================================================================================================================
		/// <summary>
		/// Gets all todod for today
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemModel>> GetTodoItemsForToday();

		/// =================================================================================================================
		/// <summary>
		/// Gets all todos for tomorrow
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemModel>> GetTodoItemsForTomorrow();

		/// =================================================================================================================
		/// <summary>
		/// Gets the todoitems that are overdue
		/// </summary>
		/// <returns>A <see cref="List{TodoItemModel}"/> with the todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemModel>> GetOverdueTodoItems();

		/// =================================================================================================================
		/// <summary>
		/// Saves a todoitem in the database
		/// </summary>
		/// <param name="model">The todoitem data to save in the database</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task SaveTodoItem( TodoItemModel model );

		/// =================================================================================================================
		/// <summary>
		/// Saves a todoitem in the database
		/// </summary>
		/// <param name="model">The todoitem data to save in the database</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task SaveTodoItem( NewTodoItemModel model );

		/// =================================================================================================================
		/// <summary>
		/// Deletes the todoitem from the database
		/// </summary>
		/// <param name="id">the id of the todoitem</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task DeleteTodoItem( int id );

		/// =================================================================================================================
		/// <summary>
		/// Toggles the done-bit for the todoitem with the given index
		/// </summary>
		/// <param name="id">The id of the todoitem to toggle</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task ToggleDone( int id );

	}
}
