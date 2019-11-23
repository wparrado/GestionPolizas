using System;
using System.Collections.Generic;
namespace GestionPolizas.Controllers
{
    using GestionPolizas.BLL;
    using GestionPolizas.Entities;
    using GestionPolizas.Entities.DTO;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PolizaController : Controller
    {
        private readonly PolizaBll poliza;

        public PolizaController(PolizaBll poliza)
        {
            this.poliza = poliza;
        }

        // GET api/values
        [HttpGet]
        public APIResult<PolicyDto> Get()
        {
            return poliza.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public APIResult<PolicyDto> Get(long id)
        {
            return poliza.Get(id);
        }

        // POST api/values
        [HttpPost]
        public APIResult<PolicyDto> Post([FromBody] PolicyDto policyDto)
        {
            return poliza.Post(policyDto);
        }

        // PATCH api/values/5
        [HttpPatch]
        public APIResult<PolicyDto> Patch([FromBody] PolicyDto policyDto)
        {
            return poliza.Patch(policyDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public APIResult<PolicyDto> Delete(int id)
        {
            return poliza.Delete(id);
        }
    }
}