using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint05_API_Cidade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            //testando banco
            using(var contexto = new CidadeContexto())
            {
                Cidade c = new Cidade();
                c.Id = Guid.NewGuid();
                c.Nome = "ara";
                c.Estado = "ara";
                contexto.Cidades.Add(c);
                //contexto.SaveChanges();
                foreach (var item in contexto.Cidades)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
