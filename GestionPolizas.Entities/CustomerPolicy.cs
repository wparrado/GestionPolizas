namespace GestionPolizas.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class CustomerPolicy
    {
        public long Id { get; set; }
        public long PolicyId { get; set; }
        public long CustomerId { get; set; }
        public DateTimeOffset BeginningValidity { get; set; }
        public DateTimeOffset CancellationDate { get; set; }
        public bool Active { get; set; }
        public Policy Policy { get; set; }
        public Customer Customer { get; set; }
    }
}
