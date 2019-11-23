namespace GestionPolizas.BLL
{
    using GestionPolizas.DAL;

    public class PolicyAssignationBll
    {
        private readonly Context context;
        private readonly IRepository repository;

        public PolicyAssignationBll(Context context, IRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }
    }
}
