using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogItemsAsync(int page, int size, int brand, int type);
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
        Task<HttpResponseMessage> PostCatalogItemAsync<T>(T item);
    }
}
