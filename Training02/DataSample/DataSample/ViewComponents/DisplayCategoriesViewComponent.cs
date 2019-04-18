using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSample.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataSample.ViewComponents
{
    public class DisplayCategoriesViewComponent : ViewComponent
    {
        private readonly TodoDataContext _dataContext;

        public DisplayCategoriesViewComponent(TodoDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await GetDataAsync();
            return View(categories);
        }

        private async Task<List<Category>> GetDataAsync()
        {
            List<Category> items = await this._dataContext.Categories.OrderBy(c => c.Name).ToListAsync();
            return items;
        }

    }
}
