namespace GestionPolizas.Entities
{
    using System.Collections.Generic;

    public partial class Policy
    {
        public Policy()
        {
            CustomerPolicies = new HashSet<CustomerPolicy>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PolicyTypeId { get; set; }
        public double Coverage { get; set; }
        public decimal Price { get; set; }
        public int RiskTypeId { get; set; }
        public bool Active { get; set; }

        public virtual PolicyType PolicyType { get; set; }
        public virtual RiskType RiskType { get; set; }
        public virtual ICollection<CustomerPolicy> CustomerPolicies { get; set; }
    }
}
