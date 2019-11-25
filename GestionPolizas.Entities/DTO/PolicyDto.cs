using System;
using System.Collections.Generic;
using System.Text;

namespace GestionPolizas.Entities.DTO
{
    public class PolicyDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PolicyTypeId { get; set; }
        public string PolicyType { get; set; }
        public double Coverage { get; set; }
        public decimal Price { get; set; }
        public int RiskTypeId { get; set; }
        public string RiskType { get; set; }
        public bool Active { get; set; }
    }
}
