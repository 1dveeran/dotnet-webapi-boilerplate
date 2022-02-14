namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class GetProductRatingByProductIdRequest : IRequest<ProductRatingDto>
{
    public Guid Id { get; set; }

    public GetProductRatingByProductIdRequest(Guid id) => Id = id;
}

public class ProductRatingByProductIdSpec : Specification<ProductRating, ProductRatingDto>, ISingleResultSpecification
{
    public ProductRatingByProductIdSpec(Guid id) =>
        Query.Where(p => p.ProductId == id);
}

public class GetProductRatingByProductIdRequestHandler : IRequestHandler<GetProductRatingByProductIdRequest, ProductRatingDto>
{
    private readonly IRepository<ProductRating> _repository;
    private readonly IStringLocalizer<GetProductRatingByProductIdRequestHandler> _localizer;

    public GetProductRatingByProductIdRequestHandler(IRepository<ProductRating> repository, IStringLocalizer<GetProductRatingByProductIdRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductRatingDto> Handle(GetProductRatingByProductIdRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductRating, ProductRatingDto>)new ProductRatingByProductIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productRating.notfound"], request.Id));
}