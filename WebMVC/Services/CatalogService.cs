using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUri;
        private readonly IHttpClient _client;
        public CatalogService(IConfiguration config,
            IHttpClient client)
        {
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
            _client = client;
        }

        public async Task<Catalog> GetCatalogItemsAsync(int page, int size,
            int category, int type)
        {
            var catalogItemsUri = ApiPaths.Catalog.GetAllEventItems(_baseUri,
                                    page, size, category, type);
            var dataString = await _client.GetStringAsync(catalogItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    }
                );
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var brandUri = ApiPaths.Catalog.GetAllCategories(_baseUri);
            var dataString = await _client.GetStringAsync(brandUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("category")
                    }
                );
            }

            return items;
        }

        public async Task<HttpResponseMessage> PostCatalogItemAsync<EventItem>(EventItem newEventItem)
        {
                var postUri = _baseUri;
                var message = await _client.PostAsync(postUri, newEventItem);
                return message;
        }
    }
}
