namespace GestionPolizas.BLL
{
    using GestionPolizas.DAL;

    public class PolicyAssignationBll
    {
        private readonly Context context;

        public PolicyAssignationBll(Context context)
        {
            this.context = context;
        }
    }
}
