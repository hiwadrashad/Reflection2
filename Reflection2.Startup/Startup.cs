using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Reflection2.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceTypes = new List<Type>();
            const string serviceNamespace = "Reflection2.LIB";
            const string interfacesNamespace = "Reflection2.Lib.Interfaces";

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                serviceTypes.AddRange(assembly.GetTypes().Where(a => a.Namespace != null && a.GetCustomAttributes(typeof(CompilerGeneratedAttribute), true)
                == null && a.Namespace == serviceNamespace || a.Namespace == interfacesNamespace).ToList());
            
            }

             foreach(var interfaceitem in serviceTypes)
             {
                if (interfaceitem.IsInterface)
                {
                    var service = serviceTypes.FirstOrDefault(a => a.IsClass && interfaceitem.Name.Substring(1) == a.Name);
                    if (service != null)
                    {
                        services.AddScoped(interfaceitem, service);
                    }
                }
             }

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reflection2.Startup", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reflection2.Startup v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
