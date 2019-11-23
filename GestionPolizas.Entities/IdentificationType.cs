namespace GestionPolizas.Entities
{
    using System.Collections.Generic;

    public partial class IdentificationType
    {
        public IdentificationType()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
