using FSH.WebApi.Application.Catalog.ProductImages;
using FSH.WebApi.Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FSH.WebApi.Infrastructure.Catalog;

public class ProductImageByProductId : IProductImageService
{
    private readonly ApplicationDbContext _context;

    public ProductImageByProductId(ApplicationDbContext context) => _context = context;
    public async Task<List<ProductImageDto>> GetProductImageByProductIdAsync(Guid? productId)
    {
        var trails = await _context.ProductImages
            .Where(a => a.ProductId == productId)
            .ToListAsync();

        return trails.Adapt<List<ProductImageDto>>();
    }
}
