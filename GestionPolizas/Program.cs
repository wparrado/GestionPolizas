namespace GestionPolizas
{
    using GestionPolizas.DAL;
    using GestionPolizas.Entities;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            using (var context = new Context())
            {
                context.Database.Migrate();
                List<RiskType> riskTypes = new List<RiskType>
                {
                    new RiskType { Id = 1, Name = "bajo", Description = "riesgo bajo", Active = true },
                    new RiskType { Id = 2, Name = "medio", Description = "riesgo medio", Active = true },
                    new RiskType { Id = 3, Name = "medio-alto", Description = "riesgo medio alto", Active = true },
                    new RiskType { Id = 4, Name = "alto", Description = "riesgo alto", Active = true }
                };
                context.RiskType.AddRange(riskTypes);

                List<PolicyType> policiTypes = new List<PolicyType>
                {
                    new PolicyType {Id = 1, Name = "Terremoto", Description = "Poliza que cubre terremoto", Active = true },
                    new PolicyType {Id = 2, Name = "Incendio", Description = "Poliza que cubre incendio", Active = true },
                    new PolicyType {Id = 3, Name = "Robo", Description = "Poliza que cubre robo", Active = true },
                    new PolicyType {Id = 4, Name = "Perdida", Description = "Poliza que cubre perdida", Active = true }
                };

                context.PolicyType.AddRange(policiTypes);
                context.SaveChanges();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
