namespace FSH.WebApi.Application.Catalog.SellerImages;

public class GetSellerImageRequest : IRequest<SellerImageDto>
{
    public Guid Id { get; set; }

    public GetSellerImageRequest(Guid id) => Id = id;
}

public class SellerImageByIdSpec : Specification<SellerImage, SellerImageDto>, ISingleResultSpecification
{
    public SellerImageByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSellerImageRequestHandler : IRequestHandler<GetSellerImageRequest, SellerImageDto>
{
    private readonly IRepository<SellerImage> _repository;
    private readonly IStringLocalizer<GetSellerImageRequestHandler> _localizer;

    public GetSellerImageRequestHandler(IRepository<SellerImage> repository, IStringLocalizer<GetSellerImageRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<SellerImageDto> Handle(GetSellerImageRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<SellerImage, SellerImageDto>)new SellerImageByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["sellerImage.notfound"], request.Id));
}