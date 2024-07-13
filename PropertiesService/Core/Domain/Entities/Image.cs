using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Image
{
    public Guid Id { get; set; }
    public Property Property { get; set; }
    public Guid PropertyId { get; set; }
    public string Path { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
