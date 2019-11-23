namespace GestionPolizas.Entities
{
    using System.Collections.Generic;

    public partial class RiskType
    {
        public RiskType()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
