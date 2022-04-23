using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.SearchItems;

public class SearchItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; }
}
