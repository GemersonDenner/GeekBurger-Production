using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GeekBurger.Production.Repository;
using Microsoft.EntityFrameworkCore;
using GeekBurger.Production.Extension;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using GeekBurger.Production.Service;
using Microsoft.Extensions.Configuration;

namespace GeekBurger.Production
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var mvcCoreBuilder = services.AddMvcCore().AddApiExplorer();

            mvcCoreBuilder
                .AddFormatterMappings()
                .AddJsonFormatters()
                .AddCors();


            /*
            services.AddMvc()
                        .AddJsonOptions(o =>
                                            {
                                                o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                                                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                                            }
                                        );
            */


            services.AddAutoMapper();


            services.AddDbContext<ProductionContext>(o => o.UseInMemoryDatabase("geekburger-production"));
            services.AddScoped<IProductionAreaRepository, ProductionAreaRepository>();
            services.AddScoped<IProductionAreaChangedService, ProductionAreaChangedService>();


            services.AddSwaggerGen(c => {
                                            c.SwaggerDoc("v1", new Info { Title = "Production Area API", Version = "v1" });
                                        }
                                  );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductionContext productionContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvc();


            productionContext.Seed();


            app.UseSwagger();
            app.UseSwaggerUI(c =>   {
                                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Production Area API v1");
                                    }

                            );


            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
        }
    }
}
