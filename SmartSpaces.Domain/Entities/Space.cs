using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSpaces.Domain.Entities
{
    public class Space
    {
        public Guid Id { get; set; }
        public required String Name { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
