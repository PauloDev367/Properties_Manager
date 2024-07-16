using Domain.DomainExceptions;
using Domain.Entities;
using Domain.Enums;

namespace DomainTests;

public class PropertyTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShoulNotCreateNewPropertyIfPriceValueIsLowestThen1000()
    {
        var exception = Assert.Throws<PropertyPriceNotAllowedException>(() =>
        {
            var property = new Property
            {
                Price = new Domain.ValueObjects.Price
                {
                    TypePropertyPayment = (int)TypePropertyPayment.Buy,
                    Value = 10
                }
            };

        });

        Assert.Pass("The value should not be lower than 1000", exception.Message);
    }
    [Test]
    public void ShoulCreateNewPropertyWithPriceValueIsBiggerThen1000()
    {
        Assert.DoesNotThrow(() =>
        {
            var property = new Property
            {
                Price = new Domain.ValueObjects.Price
                {
                    TypePropertyPayment = (int)TypePropertyPayment.Buy,
                    Value = 1000
                }
            };

        });
    }
}