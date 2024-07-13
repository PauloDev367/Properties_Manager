using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainExceptions;

public class PropertyPriceNotAllowedException : Exception
{
    public PropertyPriceNotAllowedException(string? message) : base(message)
    {
    }
}
