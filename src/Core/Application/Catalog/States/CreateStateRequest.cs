namespace FSH.WebApi.Application.Catalog.States;

public class CreateStateRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public Guid CountryId { get; set; }
    public bool IsActive { get; set; }
}

public class CreateStateRequestValidator : CustomValidator<CreateStateRequest>
{
    public CreateStateRequestValidator(IReadRepository<State> repository, IStringLocalizer<CreateStateRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new StateByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["state.alreadyexists"], name));
}

public class CreateStateRequestHandler : IRequestHandler<CreateStateRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<State> _repository;

    public CreateStateRequestHandler(IRepositoryWithEvents<State> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateStateRequest request, CancellationToken cancellationToken)
    {
        var state = new State(request.Name, request.CountryId, request.IsActive);

        await _repository.AddAsync(state, cancellationToken);

        return state.Id;
    }
}