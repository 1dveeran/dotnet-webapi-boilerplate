namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class GetProductRatingRequest : IRequest<ProductRatingDto>
{
    public Guid Id { get; set; }

    public GetProductRatingRequest(Guid id) => Id = id;
}

public class ProductRatingByIdSpec : Specification<ProductRating, ProductRatingDto>, ISingleResultSpecification
{
    public ProductRatingByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetProductRatingRequestHandler : IRequestHandler<GetProductRatingRequest, ProductRatingDto>
{
    private readonly IRepository<ProductRating> _repository;
    private readonly IStringLocalizer<GetProductRatingRequestHandler> _localizer;

    public GetProductRatingRequestHandler(IRepository<ProductRating> repository, IStringLocalizer<GetProductRatingRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductRatingDto> Handle(GetProductRatingRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductRating, ProductRatingDto>)new ProductRatingByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productRating.notfound"], request.Id));
}