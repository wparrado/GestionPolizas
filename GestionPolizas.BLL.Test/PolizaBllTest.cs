using GestionPolizas.DAL;
using GestionPolizas.Entities.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionPolizas.BLL.Test
{
    [TestClass]
    public class PolizaBllTest

    {
        private static readonly Context context = new Context();

        private readonly PolizaBll poliza = new PolizaBll(context);

        [TestMethod]
        public void Get()
        {
            var policies = poliza.Get();
            Assert.IsNotNull(policies.ResultObject);
            var specificPolicy = poliza.Get(1);
            Assert.IsNotNull(specificPolicy.ResultObject);
        }

        [TestMethod]
        public void Post()
        {
            PolicyDto policy = new PolicyDto
            {
                Active = true,
                Coverage = 0.3,
                Description = "Poliza uno",
                Name = "Poliza 1",
                PolicyTypeId = 1,
                Price = 1500,
                RiskTypeId = 1
            };
            var specificPolicy = poliza.Post(policy);
            Assert.IsNotNull(specificPolicy.ResultObject);
        }

        [TestMethod]
        public void Patch()
        {
            PolicyDto policy = new PolicyDto
            {
                Id = 1,
                Active = true,
                Coverage = 0.3,
                Description = "Poliza uno actualizada",
                Name = "Poliza 1 update",
                PolicyTypeId = 1,
                Price = 2500,
                RiskTypeId = 1
            };
            var specificPolicy = poliza.Patch(policy);
            Assert.IsNotNull(specificPolicy.ResultObject);
        }

        [TestMethod]
        public void Delete()
        {
            var policy = poliza.Delete(1);
            Assert.IsFalse(policy.DataError);
        }
    }
}
