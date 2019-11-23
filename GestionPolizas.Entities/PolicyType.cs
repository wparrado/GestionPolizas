namespace GestionPolizas.Entities
{
    public partial class PolicyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}
