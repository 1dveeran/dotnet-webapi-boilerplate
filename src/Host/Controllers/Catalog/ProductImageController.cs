using FSH.WebApi.Application.Catalog.ProductImages;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class ProductImageController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.ProductImage)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<ProductImageDto>> SearchAsync(SearchProductImagesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [OpenApiOperation("Get product details.", "")]
    public Task<ProductImageDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetProductImageRequest(id));
    }

    [HttpGet("product/{id:guid}")]
    [OpenApiOperation("Get details by product id.", "")]
    {
        return Mediator.Send(new GetProductImageByProductIdRequest(id));
    }

    [HttpPost]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateProductImageRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateProductImageRequest request, Guid id)
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
        return Mediator.Send(new DeleteProductImageRequest(id));
    }
}