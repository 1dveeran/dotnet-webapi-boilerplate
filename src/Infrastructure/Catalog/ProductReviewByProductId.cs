using FSH.WebApi.Application.Catalog.ProductReviews;
using FSH.WebApi.Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FSH.WebApi.Infrastructure.Catalog;

public class ProductReviewByProductId : IProductReviewService
{
    private readonly ApplicationDbContext _context;

    public ProductReviewByProductId(ApplicationDbContext context) => _context = context;
    public async Task<List<ProductReviewDto>> GetProductReviewByProductIdAsync(Guid? productId)
    {
        var trails = await _context.ProductReviews
            .Where(a => a.ProductId == productId)
            .ToListAsync();

        return trails.Adapt<List<ProductReviewDto>>();
    }
}
