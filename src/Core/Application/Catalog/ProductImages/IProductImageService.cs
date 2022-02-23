namespace FSH.WebApi.Application.Catalog.ProductImages;

public interface IProductImageService : ITransientService
{
    Task<List<ProductImageDto>> GetProductImageByProductIdAsync(Guid? productId);
}

