using FSH.WebApi.Application.Catalog.Sellers;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class SellersController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Seller)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<SellerDto>> SearchAsync(SearchSellersRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Seller)]
    [OpenApiOperation("Get product details.", "")]
    public Task<SellerDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSellerRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Seller)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateSellerRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Seller)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSellerRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Seller)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSellerRequest(id));
    }
}
