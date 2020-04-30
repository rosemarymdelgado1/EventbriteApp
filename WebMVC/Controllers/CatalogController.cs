using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
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
            int typesFilterApplied)
        {
            var itemsOnPage = 10;

            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemsOnPage,
                categoriesFilterApplied, typesFilterApplied);
            var vm = new CatalogIndexViewModel
            {
                CatalogItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                Categories = await _service.GetCategoriesAsync(),
                Types = await _service.GetTypesAsync(),
                CategoriesFilterApplied = categoriesFilterApplied,
                TypesFilterApplied = typesFilterApplied
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }

        [Authorize]
        public async Task<IActionResult> Create([Bind(Prefix = "EventItem")] EventItem eventItem)
        {
            if (ModelState.IsValid && eventItem.Title != null)
            {
                var result = await _service.PostCatalogItemAsync(eventItem);
                return RedirectToAction("Index", new { categoriesFilterApplied=0, typesFilterApplied=0 });
            }
            else
            {
                var vm = new CreateEventViewModel
                {
                    Types = await _service.GetTypesAsync(),
                    Categories = await _service.GetCategoriesAsync(),
                    EventItem = eventItem
                };
                return View(vm);
            }
        }
    }
}