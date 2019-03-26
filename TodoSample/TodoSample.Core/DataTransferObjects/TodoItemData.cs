using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoSample.Core.DataAccess;

namespace TodoSample.Core.DataTransferObjects
{
	/// =================================================================================================================
	/// <summary>
	/// The data object for a todoitem
	/// </summary>
	/// =================================================================================================================
	public class TodoItemData
	{
		#region properties

		/// =================================================================================================================
		/// <summary>
		/// The id of the item
		/// </summary>
		/// =================================================================================================================
		public int Id { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The name of the item
		/// </summary>
		/// =================================================================================================================
		public string Name { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The description of the item
		/// </summary>
		/// =================================================================================================================
		public string Description { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// if true the item is done, otherwise it's not done
		/// </summary>
		/// =================================================================================================================
		public bool IsDone { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The date the item was created
		/// </summary>
		/// =================================================================================================================
		public DateTime DateCreated { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The due date of the item
		/// </summary>
		/// =================================================================================================================
		public DateTime DueDate { get; set; }

		#endregion

		#region internal methods

		/// =================================================================================================================
		/// <summary>
		/// Creates a TodoItemData from a TodoItemEntity
		/// </summary>
		/// <param name="entity">The entity with the data from the database</param>
		/// <returns>a <see cref="TodoItemData"/> object with the data from the database</returns>
		/// =================================================================================================================
		internal static TodoItemData FromEntity( TodoItem entity )
		{
			TodoItemData result = new TodoItemData()
			{
				Id = entity.Id,
				DueDate = entity.DueDate,
				IsDone = entity.IsDone,
				Name = entity.Name,
			};

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Creates or updates an entity from the data provided in the data object
		/// </summary>
		/// <param name="entity">The entity to update, will be created new if null</param>
		/// <returns>An entity that can be saved in the database</returns>
		/// =================================================================================================================
		internal TodoItem ToEntity(TodoItem entity = null)
		{
			if ( entity == null )
			{
				entity = new TodoItem()
				{
					Id = this.Id,
				};
			}

			entity.IsDone = this.IsDone;
			entity.Name = this.Name;
			entity.DueDate = this.DueDate;

			return entity;
		}

		#endregion

	}
}
