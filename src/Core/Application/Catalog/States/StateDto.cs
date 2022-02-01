using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.States;

public class StateDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid CountryId { get; set; }
    public bool IsActive { get; set; }
}
