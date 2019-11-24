namespace GestionPolizas.Filters
{
    using Microsoft.AspNetCore.Mvc;
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }
}
