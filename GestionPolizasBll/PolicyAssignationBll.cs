namespace GestionPolizas.BLL
{
    using GestionPolizas.Common;
    using GestionPolizas.DAL;
    using GestionPolizas.Entities;
    using GestionPolizas.Entities.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PolicyAssignationBll
    {
        private readonly Context context;
        private readonly IRepository repository;

        public PolicyAssignationBll(Context context, IRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public APIResult<CustomerPolicyDto> SavePolicyChanges(List<CustomerPolicyDto> customerPoliciesToCreate)
        {
            APIResult<CustomerPolicyDto> result = new APIResult<CustomerPolicyDto>();
            List<CustomerPolicy> newCustomerPolicies = customerPoliciesToCreate.Where(c => c.Id == null)
                                                                               .Select(p => new CustomerPolicy
                                                                               {
                                                                                   Active = p.Active,
                                                                                   BeginningValidity = DateTimeOffset.Now,
                                                                                   CustomerId = p.CustomerId,
                                                                                   PolicyId = p.PolicyId,
                                                                               }).ToList();
            List<CustomerPolicy> customerPolicies = repository.FindAll<CustomerPolicy>().Result;
            
            customerPoliciesToCreate.Where(c => c.Id != null && c.Id > 0).ToList().ForEach(c =>
            {
                CustomerPolicy customerPolicy = customerPolicies.FirstOrDefault(p => p.Id == c.Id);
                customerPolicy.Active = c.Active;
                customerPolicy.CancellationDate = !c.Active ? DateTimeOffset.Now : customerPolicy.CancellationDate;
            });

            repository.CreateAsync(newCustomerPolicies);
            repository.UpdateAsync(customerPolicies);

            result.ResultObject = customerPoliciesToCreate;
            result.ResultMessage = Constants.savedChanges;
            return result;
        }
    }
}
