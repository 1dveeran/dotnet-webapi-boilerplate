using FSH.WebApi.Application.Catalog.Products;
using FSH.WebApi.Application.Catalog.ProductSpecifications;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class ProductSpecificationController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.ProductSpecification.Search)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<ProductSpecificationDto>> SearchAsync(SearchProductSpecificationsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.ProductSpecification.View)]
    [OpenApiOperation("Get product details.", "")]
    public Task<ProductSpecificationDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetProductSpecificationRequest(id));
    }

    [HttpGet("product/{productId:guid}")]
    [MustHavePermission(FSHPermissions.ProductSpecification.View)]
    [OpenApiOperation("Get product details.", "")]
    public Task<List<ProductSpecificationDto>> GetByProductIdAsync(Guid productId)
    {
        return Mediator.Send(new GetProductSpecificationByProductIdRequest(productId));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.ProductSpecification.Create)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateProductSpecificationRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.ProductSpecification.Update)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateProductSpecificationRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHPermissions.ProductSpecification.Delete)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteProductSpecificationRequest(id));
    }
}