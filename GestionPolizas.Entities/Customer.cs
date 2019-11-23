namespace GestionPolizas.Entities
{
    using System.Collections.Generic;

    public partial class Customer
    {
        public Customer()
        {
            CustomersPolicies = new HashSet<CustomerPolicy>();
        }

        public long Id { get; set; }
        public int IdentificationType { get; set; }
        public long IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public virtual IdentificationType Identification { get; set; }
        public virtual ICollection<CustomerPolicy> CustomersPolicies { get; set; }
    }
}
