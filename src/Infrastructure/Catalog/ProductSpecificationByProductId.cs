using FSH.WebApi.Application.Catalog.ProductSpecifications;
using FSH.WebApi.Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FSH.WebApi.Infrastructure.Catalog;

public class ProductSpecificationByProductId : IProductSpecificationService
{
    private readonly ApplicationDbContext _context;

    public ProductSpecificationByProductId(ApplicationDbContext context) => _context = context;
    public async Task<List<ProductSpecificationDto>> GetProductSpecificationByProductIdAsync(Guid? productId)
    {
        var trails = await _context.ProductSpecifications
            .Where(a => a.ProductId == productId)
            .ToListAsync();

        return trails.Adapt<List<ProductSpecificationDto>>();
    }
}
