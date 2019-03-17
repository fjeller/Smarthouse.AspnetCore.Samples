using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.DataContext;

namespace ViewComponentSample.ViewComponents
{
	public class CustomerListViewComponent : ViewComponent
	{
		#region Fields

		private DemoDataContext _dataContext;

		#endregion

		#region Get the data

		private async Task<List<PersonEntity>> GetData()
		{
			List<PersonEntity> result = await this._dataContext.PersonEntities
				.OrderBy( p => p.LastName )
				.ThenBy( p => p.FirstName )
				.ToListAsync();

			return result;
		}

		#endregion

		#region Handle the view component

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<PersonEntity> model = await GetData();

			return View( model );
		}

		#endregion

		#region Constructor

		public CustomerListViewComponent( DemoDataContext dataContext )
		{
			_dataContext = dataContext;
		}

		#endregion
	}
}
