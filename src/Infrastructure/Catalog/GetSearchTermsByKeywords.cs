using FSH.WebApi.Application.Catalog.SearchItems;
using FSH.WebApi.Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FSH.WebApi.Infrastructure.Catalog;

public class GetSearchTermsByKeywords : ISearchItemService
{
    private readonly ApplicationDbContext _context;

    public GetSearchTermsByKeywords(ApplicationDbContext context) => _context = context;

    public async Task<List<SearchItemDto>> GetProductBySearchItemAsync(string searchTerm)
    {
        var trails = await _context.SearchItems
            .Where(a => a.Name.Contains(searchTerm))
            .ToListAsync();
        return trails.Adapt<List<SearchItemDto>>();
    }
}
