namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class UpdateProductRatingRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public decimal Rating { get; set; }
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateProductRatingRequestValidator : CustomValidator<UpdateProductRatingRequest>
{
    //public UpdateProductRatingRequestValidator(IRepository<ProductRating> repository, IStringLocalizer<UpdateProductRatingRequestValidator> localizer) =>
    //    RuleFor(p => p.Name)
    //        .NotEmpty()
    //        .MaximumLength(75)
    //        .MustAsync(async (productRating, name, ct) =>
    //                await repository.GetBySpecAsync(new ProductRatingByNameSpec(name), ct)
    //                    is not ProductRating existingProductRating || existingProductRating.Id == productRating.Id)
    //            .WithMessage((_, name) => string.Format(localizer["productRating.alreadyexists"], name));
}

public class UpdateProductRatingRequestHandler : IRequestHandler<UpdateProductRatingRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductRating> _repository;
    private readonly IStringLocalizer<UpdateProductRatingRequestHandler> _localizer;

    public UpdateProductRatingRequestHandler(IRepositoryWithEvents<ProductRating> repository, IStringLocalizer<UpdateProductRatingRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateProductRatingRequest request, CancellationToken cancellationToken)
    {
        var productRating = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = productRating ?? throw new NotFoundException(string.Format(_localizer["productRating.notfound"], request.Id));

        productRating.Update(request.Rating, request.ProductId, request.IsActive);

        await _repository.UpdateAsync(productRating, cancellationToken);

        return request.Id;
    }
}