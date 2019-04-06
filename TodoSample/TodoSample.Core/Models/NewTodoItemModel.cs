using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TodoSample.Core.DataTransferObjects;

namespace TodoSample.Core.Models
{
	public class NewTodoItemModel
	{
		/// =================================================================================================================
		/// <summary>
		/// The new name for a todoitem
		/// </summary>
		/// =================================================================================================================
		[BindProperty]
		[Required]
		[DisplayName( "Name" )]
		public string NewName { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// The new duedate for a todoitem
		/// </summary>
		/// =================================================================================================================
		[BindProperty]
		[Required]
		[DisplayName( "Due Date" )]
		[DataType( DataType.Date )]
		public DateTime DueDate { get; set; }

		/// =================================================================================================================
		/// <summary>
		/// Creates a <see cref="TodoItemData"/> object from the data provided
		/// </summary>
		/// <returns>a <see cref="TodoItemData"/> object</returns>
		/// =================================================================================================================
		public TodoItemData ToDataItem()
		{
			TodoItemData result = new TodoItemData()
			{
				IsDone = false,
				DateCreated = DateTime.Now,
				Name = NewName,
				DueDate = this.DueDate,
				Id = 0
			};

			return result;
		}
	}
}
