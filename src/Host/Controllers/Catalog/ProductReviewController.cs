using FSH.WebApi.Application.Catalog.ProductReviews;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class ProductReviewController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.ProductReview)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<ProductReviewDto>> SearchAsync(SearchProductReviewsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [OpenApiOperation("Get product details.", "")]
    public Task<ProductReviewDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetProductReviewRequest(id));
    }

    [HttpGet("product/{id:guid}")]
    [OpenApiOperation("Get product details.", "")]
    {
        return Mediator.Send(new GetProductReviewByProductIdRequest(id));
    }

    [HttpPost]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateProductReviewRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateProductReviewRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteProductReviewRequest(id));
    }
}