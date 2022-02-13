using FSH.WebApi.Application.Catalog.Sellers;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class SellersController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.Seller.Search)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<SellerDto>> SearchAsync(SearchSellersRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.Seller.View)]
    [OpenApiOperation("Get product details.", "")]
    public Task<SellerDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSellerRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.Seller.Create)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateSellerRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.Seller.Update)]
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
    [MustHavePermission(FSHPermissions.Seller.Delete)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSellerRequest(id));
    }
}
