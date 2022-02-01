namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class UpdateProductReviewRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? Username { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateProductReviewRequestValidator : CustomValidator<UpdateProductReviewRequest>
{
    public UpdateProductReviewRequestValidator(IRepository<ProductReview> repository, IStringLocalizer<UpdateProductReviewRequestValidator> localizer) =>
        RuleFor(p => p.Username)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (productReview, name, ct) =>
                    await repository.GetBySpecAsync(new ProductReviewByNameSpec(name), ct)
                        is not ProductReview existingProductReview || existingProductReview.Id == productReview.Id)
                .WithMessage((_, name) => string.Format(localizer["productReview.alreadyexists"], name));
}

public class UpdateProductReviewRequestHandler : IRequestHandler<UpdateProductReviewRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductReview> _repository;
    private readonly IStringLocalizer<UpdateProductReviewRequestHandler> _localizer;

    public UpdateProductReviewRequestHandler(IRepositoryWithEvents<ProductReview> repository, IStringLocalizer<UpdateProductReviewRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateProductReviewRequest request, CancellationToken cancellationToken)
    {
        var productReview = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = productReview ?? throw new NotFoundException(string.Format(_localizer["productReview.notfound"], request.Id));

        productReview.Update(request.ProductId, request.Username, request.Comment, request.IsActive);

        await _repository.UpdateAsync(productReview, cancellationToken);

        return request.Id;
    }
}