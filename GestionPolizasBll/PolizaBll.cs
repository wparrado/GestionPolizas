namespace GestionPolizas.BLL
{
    using GestionPolizas.Common;
    using GestionPolizas.DAL;
    using GestionPolizas.Entities;
    using GestionPolizas.Entities.DTO;
    using System.Linq;

    public class PolizaBll
    {
        private readonly Context context;

        public PolizaBll(Context context)
        {
            this.context = context;
        }

        public APIResult<PolicyDto> Get()
        {
            var policies = context.Policy.Select(p => new PolicyDto
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
            var policies = context.Policy.Where(p => p.Id == id).Select(p => new PolicyDto
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

                context.Add(policy);
                context.SaveChanges();
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
                policy = new Policy
                {
                    Name = policyDto.Name,
                    Description = policyDto.Description,
                    Price = policyDto.Price,
                    Coverage = policyDto.Coverage,
                    PolicyTypeId = policyDto.PolicyTypeId,
                    RiskTypeId = policyDto.RiskTypeId,
                    Active = policyDto.Active
                };

                context.Update(policy);
                context.SaveChanges();
            }
            else
            {
                result.DataError = true;
                result.ResultMessage = Constants.coveragePercentageError;
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
    }
}
