using FSH.WebApi.Application.Catalog.SellerImages;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class SellerImagesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.SellerImage)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<SellerImageDto>> SearchAsync(SearchSellerImagesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [OpenApiOperation("Get product details.", "")]
    public Task<SellerImageDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSellerImageRequest(id));
    }

    [HttpPost]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateSellerImageRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSellerImageRequest request, Guid id)
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
        return Mediator.Send(new DeleteSellerImageRequest(id));
    }
}