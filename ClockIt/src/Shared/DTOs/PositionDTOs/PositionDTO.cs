using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.PositionDTOs
{
    public class PositionDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EnterpriseId { get; set; }

        public PositionDTO(string name, string description, int enterpriseId)
        {
            Name = name;
            Description = description;
            EnterpriseId = enterpriseId;
        }
    }
}
