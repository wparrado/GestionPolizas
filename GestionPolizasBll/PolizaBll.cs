namespace GestionPolizas.BLL
{
    using GestionPolizas.Common;
    using GestionPolizas.DAL;
    using GestionPolizas.Entities;
    using GestionPolizas.Entities.DTO;
    using System.Collections.Generic;
    using System.Linq;

    public class PolizaBll
    {
        private readonly Context context;
        private readonly IRepository repository;

        public PolizaBll(Context context, IRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public APIResult<PolicyDto> Get()
        {
            var policies = repository.FindAll<Policy>().Result.Select(p => new PolicyDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Coverage = p.Coverage,
                Active = p.Active
            }).ToList();

            return new APIResult<PolicyDto> { ResultObject = policies };
        }

        public APIResult<PolicyDto> Get(long id)
        {
            var dbPolicy = repository.FindById<Policy>(id).Result;
            var policy = new PolicyDto
            {
                Active = dbPolicy.Active,
                Coverage = dbPolicy.Coverage,
                Description = dbPolicy.Description,
                Id = dbPolicy.Id,
                Name = dbPolicy.Name,
                PolicyTypeId = dbPolicy.PolicyTypeId,
                Price = dbPolicy.Price,
                RiskTypeId = dbPolicy.RiskTypeId
            };

            return new APIResult<PolicyDto> { ResultObject = new List<PolicyDto> { policy } };
        }

        public APIResult<PolicyDto> Post(PolicyDto policyDto)
        {
            APIResult<PolicyDto> result = new APIResult<PolicyDto>();
            if (ValidateCoveragePercentage(policyDto.RiskTypeId, policyDto.Coverage))
            {
                Policy policy = new Policy
                {
                    Name = policyDto.Name,
                    Description = policyDto.Description,
                    Price = policyDto.Price,
                    Coverage = policyDto.Coverage,
                    PolicyTypeId = policyDto.PolicyTypeId,
                    RiskTypeId = policyDto.RiskTypeId,
                    Active = policyDto.Active
                };

                repository.CreateAsync(policy);
                policyDto.Id = policy.Id;
                result.ResultObject = new List<PolicyDto> { policyDto };
                result.ResultMessage = Constants.policyCreated;
            }
            else
            {
                result.DataError = true;
                result.ResultMessage = Constants.coveragePercentageError;
            }

            return result;
        }

        public APIResult<PolicyDto> Patch(PolicyDto policyDto)
        {
            APIResult<PolicyDto> result = new APIResult<PolicyDto>();
            if (ValidateCoveragePercentage(policyDto.RiskTypeId, policyDto.Coverage))
            {
                Policy policy = context.Policy.FirstOrDefault(p => p.Id == policyDto.Id);
                policy.Name = policyDto.Name;
                policy.Description = policyDto.Description;
                policy.Price = policyDto.Price;
                policy.Coverage = policyDto.Coverage;
                policy.PolicyTypeId = policyDto.PolicyTypeId;
                policy.RiskTypeId = policyDto.RiskTypeId;
                policy.Active = policyDto.Active;

                repository.UpdateAsync(policy);
                result.ResultObject = new List<PolicyDto> { policyDto };
                result.ResultMessage = Constants.policyUpdated;
            }
            else
            {
                result.DataError = true;
                result.ResultMessage = Constants.coveragePercentageError;
            }

            return result;
        }

        public APIResult<PolicyDto> Delete(long id)
        {
            APIResult<PolicyDto> result = new APIResult<PolicyDto>();
            if (ValidatePolicyRelation(id))
            {
                Policy policy = context.Policy.FirstOrDefault(p => p.Id == id);
                repository.DeleteAsync(policy);
                result.ResultMessage = Constants.policyDeleted;
            }
            else
            {
                result.DataError = true;
                result.ResultMessage = Constants.policyRelationError;
            }

            return result;
        }

        public bool ValidateCoveragePercentage(int riskTypeId, double coverage)
        {
            if (riskTypeId == (int)RiskTypes.ALTO)
            {
                return coverage < 0.5;
            }

            return true;
        }

        public bool ValidatePolicyRelation(long id)
        {
            var customerPolicies = context.CustomerPolicy.FirstOrDefault(c => c.PolicyId == id);
            return customerPolicies == null;
        }
    }
}
