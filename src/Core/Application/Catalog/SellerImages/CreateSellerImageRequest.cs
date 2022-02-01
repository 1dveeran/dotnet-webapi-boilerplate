namespace FSH.WebApi.Application.Catalog.SellerImages;

public class CreateSellerImageRequest : IRequest<Guid>
{
    public string ImagePath { get; set; } = default!;
    public Guid SellerId { get; set; }
    public bool IsActive { get; set; }
}

//public class CreateSellerImageRequestValidator : CustomValidator<CreateSellerImageRequest>
//{
//    public CreateSellerImageRequestValidator(IReadRepository<SellerImage> repository, IStringLocalizer<CreateSellerImageRequestValidator> localizer) =>
//        RuleFor(p => p.Name)
//            .NotEmpty()
//            .MaximumLength(75)
//            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new SellerImageByNameSpec(name), ct) is null)
//                .WithMessage((_, name) => string.Format(localizer["sellerImage.alreadyexists"], name));
//}

public class CreateSellerImageRequestHandler : IRequestHandler<CreateSellerImageRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SellerImage> _repository;

    public CreateSellerImageRequestHandler(IRepositoryWithEvents<SellerImage> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateSellerImageRequest request, CancellationToken cancellationToken)
    {
        var sellerImage = new SellerImage(request.ImagePath, request.SellerId, request.IsActive);

        await _repository.AddAsync(sellerImage, cancellationToken);

        return sellerImage.Id;
    }
}