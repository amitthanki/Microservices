﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Database;

namespace Person.api
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
           // var appSettings = new AppSettings();
          //  services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //ConfigurationBinder.Bind(Configuration.GetSection("AppSettings"),appSettings);
          //  services.AddSingleton<IAppSettings>(appSettings);
            services.AddTransient<IPerson,Persons>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           // services.AddMvc().AddJsonOptions(options =>
          //  {
              //options.SerializerSettings.Formatting = Formatting.Indented;
         //  })
           // services.AddMvc().AddXmlSerializerFormatters();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseApiResponseAndExceptionWrapper();
         //   app.UseMiddleware<RequestResponseLoggingMiddleware>();
          //  app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
