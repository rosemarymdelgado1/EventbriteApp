using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceCatalogApi.Data;
using ServiceCatalogApi.Domain;
using ServiceCatalogApi.ViewModel;

namespace ServiceCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;

        public CatalogController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> Items([FromQuery] int pageindex = 0, [FromQuery]int pagesize = 6)
        {
            var itemcount = await _context.eventitem.LongCountAsync(); //eventitem name comes from CatalogContext
            var items = await _context.eventitem.Skip(pageindex * pagesize).Take(pagesize).ToListAsync();
            items = ChangePictureUrl(items); // as in postman we are not able to see actual pictures

            var model = new PaginatedItemViewModel<EventItem>
            {
                PageIndex = pageindex,
                PageSize = pagesize,
                Count = itemcount,
                Data = items
            };
            //return Ok(items)
            return Ok(model);

        }

        [HttpPost]
        public async Task<ActionResult<EventItem>> PostEvent(EventItem eventItem)
        {
            _context.eventitem.Add(eventItem);
            var result = await _context.SaveChangesAsync();

            return Ok(eventItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EventItem>> UpdateEvent(int id, EventItem eventItem)
        {
            if(id != eventItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventItem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EventItem>> DeleteEvent(int id)
        {
            var eventItem = _context.eventitem.Find(id);
            if(eventItem == null)
            {
                return NotFound();
            }
            _context.eventitem.Remove(eventItem);
            _context.SaveChanges();
            return eventItem;
        }
        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            //since strings are immutable so after replacing we are putting replaced url in same variable ie PictureUrl
            items.ForEach(c => c.PictureUrl = c.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogBaseUrl"]));
            return (items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.eventtype.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var items = await _context.eventcategory.ToListAsync();
            return Ok(items);
        }
    }
}