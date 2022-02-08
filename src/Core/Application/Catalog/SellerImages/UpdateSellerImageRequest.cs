namespace FSH.WebApi.Application.Catalog.SellerImages;

public class UpdateSellerImageRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; } = default!;
    public Guid SellerId { get; set; }
    public bool IsActive { get; set; }
}

// public class UpdateSellerImageRequestValidator : CustomValidator<UpdateSellerImageRequest>
// {
//    public UpdateSellerImageRequestValidator(IRepository<SellerImage> repository, IStringLocalizer<UpdateSellerImageRequestValidator> localizer) =>
//        RuleFor(p => p.Name)
//            .NotEmpty()
//            .MaximumLength(75)
//            .MustAsync(async (sellerImage, name, ct) =>
//                    await repository.GetBySpecAsync(new SellerImageByNameSpec(name), ct)
//                        is not SellerImage existingSellerImage || existingSellerImage.Id == sellerImage.Id)
//                .WithMessage((_, name) => string.Format(localizer["sellerImage.alreadyexists"], name));
// }

public class UpdateSellerImageRequestHandler : IRequestHandler<UpdateSellerImageRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SellerImage> _repository;
    private readonly IStringLocalizer<UpdateSellerImageRequestHandler> _localizer;

    public UpdateSellerImageRequestHandler(IRepositoryWithEvents<SellerImage> repository, IStringLocalizer<UpdateSellerImageRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateSellerImageRequest request, CancellationToken cancellationToken)
    {
        var sellerImage = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = sellerImage ?? throw new NotFoundException(string.Format(_localizer["sellerImage.notfound"], request.Id));

        sellerImage.Update(request.ImagePath, request.SellerId, request.IsActive);

        await _repository.UpdateAsync(sellerImage, cancellationToken);

        return request.Id;
    }
}