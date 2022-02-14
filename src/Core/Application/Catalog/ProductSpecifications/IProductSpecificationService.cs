namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public interface IProductSpecificationService : ITransientService
{
    Task<List<ProductSpecificationDto>> GetProductSpecificationByProductIdAsync(Guid? productId);
}
