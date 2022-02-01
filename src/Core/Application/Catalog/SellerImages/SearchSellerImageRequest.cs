namespace FSH.WebApi.Application.Catalog.SellerImages;

public class SearchSellerImagesRequest : PaginationFilter, IRequest<PaginationResponse<SellerImageDto>>
{
}

public class SellerImagesBySearchRequestSpec : EntitiesByPaginationFilterSpec<SellerImage, SellerImageDto>
{
    public SellerImagesBySearchRequestSpec(SearchSellerImagesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.ImagePath, !request.HasOrderBy());
}

public class SearchSellerImagesRequestHandler : IRequestHandler<SearchSellerImagesRequest, PaginationResponse<SellerImageDto>>
{
    private readonly IReadRepository<SellerImage> _repository;

    public SearchSellerImagesRequestHandler(IReadRepository<SellerImage> repository) => _repository = repository;

    public async Task<PaginationResponse<SellerImageDto>> Handle(SearchSellerImagesRequest request, CancellationToken cancellationToken)
    {
        var spec = new SellerImagesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<SellerImageDto>(list, count, request.PageNumber, request.PageSize);
    }
}