using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class CreateEventViewModel
    {
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public EventItem EventItem { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? TypeFilterApplied { get; set; }
    }
}
