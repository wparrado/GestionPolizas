namespace GestionPolizas.Entities.DTO
{
    using System;
    public class CustomerPolicyDto
    {
        public long? Id { get; set; }
        public long PolicyId { get; set; }
        public long CustomerId { get; set; }
        public DateTimeOffset BeginningValidity { get; set; }
        public DateTimeOffset CancellationDate { get; set; }
        public bool Active { get; set; }
    }
}
