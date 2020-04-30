using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly ICatalogService _service;
        public EventController(ICatalogService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Create([Bind(Prefix = "EventItem")] EventItem eventItem)
        //{
        //    if (ModelState.IsValid && eventItem.Title != null)
        //    {
        //        var result = await _service.PostCatalogItemAsync(eventItem);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        var vm = new CreateEventViewModel
        //        {
        //            Types = await _service.GetTypesAsync(),
        //            Categories = await _service.GetCategoriesAsync(),
        //            EventItem = eventItem
        //        };
        //        return View(vm);
        //    }
        //}
    }
}