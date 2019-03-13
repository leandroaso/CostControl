using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostControl.Application.Services;
using CostControl.Domain.Interfaces.Services;
using CostControl.Infra.DataContext;
using CostControl.Infra.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CostControl.Api
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
            services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<CostControlContext, CostControlContext>();
            services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IDepartamentService, DepartamentService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IMovementService, MovementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
