using FSH.WebApi.Application.Catalog.ProductRatings;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class ProductRatingController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.ProductRating)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<ProductRatingDto>> SearchAsync(SearchProductRatingsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.ProductRating)]
    [OpenApiOperation("Get product details.", "")]
    public Task<ProductRatingDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetProductRatingRequest(id));
    }

    [HttpGet("product/{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.ProductRating)]
    [OpenApiOperation("Get product details.", "")]
    public Task<ProductRatingDto> GetByProductIdAsync(Guid id)
    {
        return Mediator.Send(new GetProductRatingByProductIdRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.ProductRating)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateProductRatingRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.ProductRating)]
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
    [MustHavePermission(FSHAction.Delete, FSHResource.ProductRating)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteProductRatingRequest(id));
    }
}