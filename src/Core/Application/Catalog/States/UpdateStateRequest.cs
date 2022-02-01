namespace FSH.WebApi.Application.Catalog.States;

public class UpdateStateRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid CountryId { get; set; }
    public bool IsActive { get; set; }

}

public class UpdateStateRequestValidator : CustomValidator<UpdateStateRequest>
{
    public UpdateStateRequestValidator(IRepository<State> repository, IStringLocalizer<UpdateStateRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (state, name, ct) =>
                    await repository.GetBySpecAsync(new StateByNameSpec(name), ct)
                        is not State existingState || existingState.Id == state.Id)
                .WithMessage((_, name) => string.Format(localizer["state.alreadyexists"], name));
}

public class UpdateStateRequestHandler : IRequestHandler<UpdateStateRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<State> _repository;
    private readonly IStringLocalizer<UpdateStateRequestHandler> _localizer;

    public UpdateStateRequestHandler(IRepositoryWithEvents<State> repository, IStringLocalizer<UpdateStateRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateStateRequest request, CancellationToken cancellationToken)
    {
        var state = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = state ?? throw new NotFoundException(string.Format(_localizer["state.notfound"], request.Id));

        state.Update(request.Name, request.CountryId, request.IsActive);

        await _repository.UpdateAsync(state, cancellationToken);

        return request.Id;
    }
}