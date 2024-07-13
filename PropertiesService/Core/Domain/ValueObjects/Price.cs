using Domain.DomainExceptions;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

public class Price
{
    private double _value;
    public double Value
    {
        get { return _value; }
        set
        {
            if (value < 1000)
                throw new PropertyPriceNotAllowedException("The value should not be lower than 1000");
            else
                _value = value;
        }
    }
    public int TypePropertyPayment { get; set; }
}
