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
            CreateHostBuilder(args).Build().Run();

            //testando banco
            //using (var contexto = new CidadeContexto())
            //{
            //    Cliente c = new Cliente();
            //    c.Id = Guid.NewGuid();
            //    c.Nome = "ara";
            //    c.DataNascimento = DateTime.Now;
            //    c.CidadeId = Guid.Parse("d7f96995-6dfc-4a98-9c48-0495393cd092");
            //    c.Cep = "a";
            //    c.Logradouro = "a";
            //    c.Bairro = "a";
            //    contexto.Clientes.Add(c);
            //    contexto.SaveChanges();
            //    foreach (var item in contexto.Clientes)
            //    {
            //        Console.WriteLine(item.Id);
            //    }
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
