namespace GestionPolizas.Entities
{
    using System.Collections.Generic;

    public partial class Customer
    {
        public Customer()
        {
            IdentificationTypes = new HashSet<IdentificationType>();
        }

        public long Id { get; set; }
        public int IdentificationType { get; set; }
        public long IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<IdentificationType> IdentificationTypes { get; set; }
    }
}
