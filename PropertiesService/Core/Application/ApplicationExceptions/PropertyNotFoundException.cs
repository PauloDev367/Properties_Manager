using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationExceptions;

public class PropertyNotFoundException : Exception
{
    public PropertyNotFoundException(string? message) : base(message)
    {
    }
}
