using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class SearchItem : AuditableEntity, IAggregateRoot
{
    public string? Name { get; private set; }
    public bool IsActive { get; set; }
}
