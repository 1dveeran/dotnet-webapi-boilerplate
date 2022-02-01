namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class CreateProductReviewRequest : IRequest<Guid>
{
    public Guid ProductId { get; set; }
    public string? Username { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
}

//public class CreateProductReviewRequestValidator : CustomValidator<CreateProductReviewRequest>
//{
//    public CreateProductReviewRequestValidator(IReadRepository<ProductReview> repository, IStringLocalizer<CreateProductReviewRequestValidator> localizer) =>
//        RuleFor(p => p.Name)
//            .NotEmpty()
//            .MaximumLength(75)
//            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new ProductReviewByNameSpec(name), ct) is null)
//                .WithMessage((_, name) => string.Format(localizer["productReview.alreadyexists"], name));
//}

public class CreateProductReviewRequestHandler : IRequestHandler<CreateProductReviewRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductReview> _repository;

    public CreateProductReviewRequestHandler(IRepositoryWithEvents<ProductReview> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateProductReviewRequest request, CancellationToken cancellationToken)
    {
        var productReview = new ProductReview(request.ProductId, request.Username, request.Comment, request.IsActive);

        await _repository.AddAsync(productReview, cancellationToken);

        return productReview.Id;
    }
}