using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCatalogApi.ViewModel
{
    public class PaginatedItemViewModel<T>    //making it generic so that it can be used for class and orders as well
         where T : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
