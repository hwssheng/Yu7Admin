using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Yu7Admin.Domain.IRepository;
using Yu7Admin.Domain.IRepository.Repository.Yu7;
using Yu7Admin.Domain.Repository.Repository.Yu7;
using Yu7Admin.Framework.Cache;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Reflection;
using Yu7Admin.Core;
using Yu7Admin.Core.Models;

namespace Yu7Admin
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
            services.AddSession().AddMvc().AddControllersAsServices();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        { 
            //使用dll注册
            builder.RegisterAssemblyTypes(GetAssembly("Yu7Admin.Domain.Repository")) 
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            //单个类型注册
            //builder.RegisterType<Y7AdminRepository>().As<IY7AdminRepository>().PropertiesAutowired().InstancePerDependency();
            //单个类型带参注册
            //builder.RegisterType<ConfigReader>()
            //       .As<IConfigReader>()
            //       .WithParameter(
            //         new ResolvedParameter(
            //           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "configSectionName",
            //           (pi, ctx) => "sectionName"));
        } 

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });


        }
    }
}
