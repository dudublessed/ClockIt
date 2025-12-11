using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.Entities
{
    public class PositionsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int EnterpriseId { get; set; }

        public PositionsModel(int id, string name, string description, int enterpriseId)
        {
            Id = id;
            Name = name;
            Description = description;
            EnterpriseId = enterpriseId;
        }
    }
}
