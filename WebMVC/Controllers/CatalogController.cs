using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int categoriesFilterApplied,
            int typesFilterApplied,int locationsFilterApplied)
        {
            var itemsOnPage = 9;

            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemsOnPage,
                categoriesFilterApplied, typesFilterApplied,locationsFilterApplied);
            var vm = new CatalogIndexViewModel
            {
                CatalogItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    //ItemsPerPage = itemsOnPage,
                    ItemsPerPage = Math.Min(itemsOnPage, (int)catalog.Count),
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                    
                },
                Categories = await _service.GetCategoriesAsync(),
                Types = await _service.GetTypesAsync(),
                Locations = await _service.GetLocationsAsync(),
                CategoriesFilterApplied = categoriesFilterApplied,
                TypesFilterApplied = typesFilterApplied,
                LocationsFilterApplied = locationsFilterApplied
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}