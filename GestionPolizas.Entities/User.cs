using System;
using System.Collections.Generic;
using System.Text;

namespace GestionPolizas.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string HaveAccess { get; set; }
    }
}
