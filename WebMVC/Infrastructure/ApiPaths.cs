using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllEventItems(string baseUri,
                int page, int take, int category, int type, int location)
            {
                var filterQs = string.Empty;
                if (category != 0 || type != 0 || location != 0)
                {
                    var categoryQs = (category != 0) ? "eventCategoryId=" + category : "";
                    var typeQs = (type != 0) ? "eventTypeId=" + type : "";
                    var locationQs = (location != 0) ? "eventLocationId=" + location : "";
                    filterQs = $"{categoryQs}&{typeQs}&{locationQs}";
                }
                return $"{baseUri}items?{filterQs}&pageIndex={page}&pageSize={take}";
            }

            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}eventcategories";
            }

            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }
        }
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
    }
}
