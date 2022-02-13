using FSH.WebApi.Application.Catalog.ProductRatings;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class ProductRatingController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.ProductRating.Search)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<ProductRatingDto>> SearchAsync(SearchProductRatingsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.ProductRating.View)]
    [OpenApiOperation("Get product details.", "")]
    public Task<ProductRatingDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetProductRatingRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.ProductRating.Create)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateProductRatingRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.ProductRating.Update)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateProductRatingRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHPermissions.ProductRating.Delete)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteProductRatingRequest(id));
    }
}