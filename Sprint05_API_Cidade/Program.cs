using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using ViaCepConsumer;


namespace Sprint05_API_Cidade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            //var t = ViaCepConsumer
            //var a = RestService.For<>
            //SearchResult r = new SearchResult();

            ViaCepClient v = new ViaCepClient();
            var t = v.Search("01001-000");


            Console.WriteLine(t.Cidade);



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
