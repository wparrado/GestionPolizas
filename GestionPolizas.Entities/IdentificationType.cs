using System;
using System.Collections.Generic;
using System.Text;

namespace GestionPolizas.Entities
{
    public partial class IdentificationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
    }
}
