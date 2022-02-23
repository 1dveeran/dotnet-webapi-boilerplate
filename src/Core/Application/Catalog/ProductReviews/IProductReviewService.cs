using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.ProductReviews;

public interface IProductReviewService : ITransientService
{
    Task<List<ProductReviewDto>> GetProductReviewByProductIdAsync(Guid? productId);
}

