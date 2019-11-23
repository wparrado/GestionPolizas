namespace GestionPolizas.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class CustomerPolicy
    {
        public CustomerPolicy()
        {
            Policies = new HashSet<Policy>();
            Customers = new HashSet<Customer>();
        }

        public long Id { get; set; }
        public long PolicyId { get; set; }
        public long CustomerId { get; set; }
        public DateTimeOffset BeginningValidity { get; set; }
        public DateTimeOffset CancellationDate { get; set; }
        public bool Active { get; set; }

        public ICollection<Policy> Policies { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
