using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoSample.Core.DataTransferObjects;

namespace TodoSample.Core.Repositories.Interfaces
{
	public interface ITodoRepository
	{
		/// =================================================================================================================
		/// <summary>
		/// Gets all todos from the database including all tasks
		/// </summary>
		/// <returns>A <see cref="List{TodoItemData}"/> with all todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemData>> GetAllTodoItems();

		/// =================================================================================================================
		/// <summary>
		/// Gets the todos for a specific due date from the database
		/// </summary>
		/// <param name="dueDate">The due date to get the items for</param>
		/// <returns>A <see cref="List{TodoItemData}"/> with the todos</returns>
		/// =================================================================================================================
		Task<List<TodoItemData>> GetTodoItemsForDate( DateTime dueDate );

		/// =================================================================================================================
		/// <summary>
		/// Saves a todoitem in the database
		/// </summary>
		/// <param name="data">The todoitem data to save in the database</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task SaveTodoItem( TodoItemData data );

		/// =================================================================================================================
		/// <summary>
		/// Toggle the done flag for the todoitem with the provided id
		/// </summary>
		/// <param name="id">The id of the todoitem to toggle the flag for</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task ToggleDone( int id );

		/// =================================================================================================================
		/// <summary>
		/// Deletes the todoitem with the given id
		/// </summary>
		/// <param name="id">The id of the todoitem</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		Task DeleteTodoItem( int id );


	}
}
