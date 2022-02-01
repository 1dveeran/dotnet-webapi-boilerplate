namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class CreateProductRatingRequest : IRequest<Guid>
{
    public decimal Rating { get; set; }
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}

//public class CreateProductRatingRequestValidator : CustomValidator<CreateProductRatingRequest>
//{
//    public CreateProductRatingRequestValidator(IReadRepository<ProductRating> repository, IStringLocalizer<CreateProductRatingRequestValidator> localizer) =>
//        RuleFor(p => p.Name)
//            .NotEmpty()
//            .MaximumLength(75)
//            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new ProductRatingByNameSpec(name), ct) is null)
//                .WithMessage((_, name) => string.Format(localizer["productRating.alreadyexists"], name));
//}

public class CreateProductRatingRequestHandler : IRequestHandler<CreateProductRatingRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductRating> _repository;

    public CreateProductRatingRequestHandler(IRepositoryWithEvents<ProductRating> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateProductRatingRequest request, CancellationToken cancellationToken)
    {
        var productRating = new ProductRating(request.Rating, request.ProductId, request.IsActive);

        await _repository.AddAsync(productRating, cancellationToken);

        return productRating.Id;
    }
}