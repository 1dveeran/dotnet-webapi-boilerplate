namespace FSH.WebApi.Application.Catalog.SearchItems;

public class GetSearchItemRequest : IRequest<List<SearchItemDto>>
{
    public string Name { get; set; } = default!;

    public GetSearchItemRequest(string name) => Name = name;
}

public class GetSearchItemRequestHandler : IRequestHandler<GetSearchItemRequest, List<SearchItemDto>>
{
    private readonly ISearchItemService _service;
    private readonly IStringLocalizer<GetSearchItemRequestHandler> _localizer;

    public GetSearchItemRequestHandler(ISearchItemService service, IStringLocalizer<GetSearchItemRequestHandler> localizer) => (_service, _localizer) = (service, localizer);

    public async Task<List<SearchItemDto>> Handle(GetSearchItemRequest request, CancellationToken cancellationToken) =>
        await _service.GetProductBySearchItemAsync(request.Name);
}