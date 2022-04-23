using FSH.WebApi.Application.Catalog.SearchItems;
using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class SearchItemController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Country)]
    [OpenApiOperation("Search Country using available Filters.", "")]
    public Task<List<SearchItemDto>> SearchAsync(GetSearchItemRequest request)
    {
        return Mediator.Send(request);
    }
}
