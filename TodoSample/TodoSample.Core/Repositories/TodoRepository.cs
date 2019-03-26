using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TodoSample.Core.DataAccess;
using TodoSample.Core.DataTransferObjects;
using TodoSample.Core.Repositories.Interfaces;

namespace TodoSample.Core.Repositories
{
	public class TodoRepository : ITodoRepository
	{
		#region fields

		private readonly TodoDbContext _dataContext;

		#endregion

		#region private methods

		/// =================================================================================================================
		/// <summary>
		/// Inserts a TodoItem into the database
		/// </summary>
		/// <param name="data">The todoitem data</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		private async Task InsertTodoItem( TodoItemData data )
		{
			var entity = data.ToEntity();
			await this._dataContext.TodoItems.AddAsync( entity );
			await this._dataContext.SaveChangesAsync();
		}

		/// =================================================================================================================
		/// <summary>
		/// Updates a todoitem in the database
		/// </summary>
		/// <param name="data">the todoitem data</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		private async Task UpdateTodoItem( TodoItemData data )
		{
			var entity = await this._dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == data.Id );
			data.ToEntity( entity );
			await this._dataContext.SaveChangesAsync();
		}

		#endregion

		#region methods

		/// =================================================================================================================
		/// <summary>
		/// Gets all todos from the database including all tasks
		/// </summary>
		/// <returns>A <see cref="List{TodoItemData}"/> with all todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemData>> GetAllTodoItems()
		{
			List<TodoItem> entities = await this._dataContext.TodoItems.OrderBy( i => i.DueDate ).ToListAsync();
			List<TodoItemData> result = entities.Select( TodoItemData.FromEntity ).ToList();

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Gets the todos for a specific due date from the database
		/// </summary>
		/// <param name="dueDate">The due date to get the items for</param>
		/// <returns>A <see cref="List{TodoItemData}"/> with the todos</returns>
		/// =================================================================================================================
		public async Task<List<TodoItemData>> GetTodoItemsForDate( DateTime dueDate )
		{
			List<TodoItem> entities = await this._dataContext.TodoItems.Where( i => i.DueDate.Date == dueDate.Date ).ToListAsync();
			List<TodoItemData> result = entities.Select( TodoItemData.FromEntity ).ToList();

			return result;
		}


		/// =================================================================================================================
		/// <summary>
		/// Saves a todoitem in the database
		/// </summary>
		/// <param name="data">The todoitem data to save in the database</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		public async Task SaveTodoItem( TodoItemData data )
		{
			if ( data == null )
			{
				return;
			}

			if ( data.Id == 0 )
			{
				await InsertTodoItem( data );
			}
			else
			{
				await UpdateTodoItem( data );
			}
		}

		/// =================================================================================================================
		/// <summary>
		/// Toggle the done flag for the todoitem with the provided id
		/// </summary>
		/// <param name="id">The id of the todoitem to toggle the flag for</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		public async Task ToggleDone( int id )
		{
			TodoItem item = await this._dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == id );
			if ( item == null )
			{
				return;
			}

			item.IsDone = !item.IsDone;
			await this._dataContext.SaveChangesAsync();
		}

		/// =================================================================================================================
		/// <summary>
		/// Deletes the todoitem with the given id
		/// </summary>
		/// <param name="id">The id of the todoitem</param>
		/// <returns>void</returns>
		/// =================================================================================================================
		public async Task DeleteTodoItem( int id )
		{
			TodoItem item = await this._dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == id );
			if ( item == null )
			{
				return;
			}

			this._dataContext.TodoItems.Remove( item );
			await this._dataContext.SaveChangesAsync();
		}

		#endregion

		#region Constructor

		/// =================================================================================================================
		/// <summary>
		/// The constructor
		/// </summary>
		/// <param name="dataContext">The datacontext</param>
		/// =================================================================================================================
		public TodoRepository( TodoDbContext dataContext )
		{
			_dataContext = dataContext;
		}

		#endregion
	}
}
