using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports;

public interface IPropertyRepository
{
    public Task<Property> CreateAsync(Property property);
    public Task<List<Property>> GetAllAsync(int perPage, int page, string orderBy, string order);
}
