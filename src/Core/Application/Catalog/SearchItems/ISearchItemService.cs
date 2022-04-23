using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.SearchItems;

public interface ISearchItemService : ITransientService
{
    Task<List<SearchItemDto>> GetProductBySearchItemAsync(string searchTerm);
}
