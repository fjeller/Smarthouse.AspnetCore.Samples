using System;
using System.Collections.Generic;
using System.Text;
using TodoSample.Core.DataTransferObjects;

namespace TodoSample.Core.Models
{
	/// =================================================================================================================
	/// <summary>
	/// The model for a single todoitem
	/// </summary>
	/// =================================================================================================================
	public class TodoItemModel
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
		/// if true the item is done, otherwise it's not done
		/// </summary>
		/// =================================================================================================================
		public bool IsDone { get; set; }

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
		/// <param name="dataItem">The entity with the data from the database</param>
		/// <returns>a <see cref="TodoItemData"/> object with the data from the database</returns>
		/// =================================================================================================================
		internal static TodoItemModel FromDataItem( TodoItemData dataItem )
		{
			TodoItemModel result = new TodoItemModel()
			{
				Id = dataItem.Id,
				DueDate = dataItem.DueDate,
				IsDone = dataItem.IsDone,
				Name = dataItem.Name,
			};

			return result;
		}

		/// =================================================================================================================
		/// <summary>
		/// Creates or updates an entity from the data provided in the data object
		/// </summary>
		/// <returns>An entity that can be saved in the database</returns>
		/// =================================================================================================================
		internal TodoItemData ToDataItem()
		{
			TodoItemData result = new TodoItemData
			{
				Id = this.Id,
				IsDone = this.IsDone,
				Name = this.Name,
				DueDate = this.DueDate,
			};

			return result;
		}

		#endregion

	}
}
