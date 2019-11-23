namespace GestionPolizas.Entities
{
    using System.Collections.Generic;

    public partial class Policy
    {
        public Policy()
        {
            PolicyTypes = new HashSet<PolicyType>();
            RiskTypes = new HashSet<RiskType>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Coverage { get; set; }
        public decimal Price { get; set; }
        public int RiskType { get; set; }


        public virtual ICollection<PolicyType> PolicyTypes { get; set; }
        public virtual ICollection<RiskType> RiskTypes { get; set; }
    }
}
