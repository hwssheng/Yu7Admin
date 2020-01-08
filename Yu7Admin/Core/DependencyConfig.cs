
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using System;
using System.Linq;
using System.Reflection;
using Autofac.Integration.WebApi;
using Yu7Admin.Domain.IRepository;
using Yu7Admin.Domain.IRepository.Repository.Yu7;
using Yu7Admin.Domain.Repository;
using Yu7Admin.Domain.Repository.Repository.Yu7;

namespace Yu7Admin.Core
{
    public class DependencyConfig
    { 
        public static void Register()
        {
            try
            {


                var builder = new ContainerBuilder();
                //var config = GlobalConfiguration.Configuration;

                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

                //注册MvcApplication程序集中所有的控制器
                builder.RegisterControllers(typeof(DependencyConfig).Assembly);

                //注册仓储层服务
                //builder.RegisterType<PostRepository>().As<IPostRepository>();
                //注册基于接口约束的实体
                //var assembly = AppDomain.CurrentDomain.GetAssemblies();

                var allAssemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load);

                Assembly[] assemblies = allAssemblies.Where(m =>
                          m.FullName.Contains("Service") ||
                          m.FullName.Contains("Repository"))
                    .ToArray();

                builder.RegisterAssemblyTypes(assemblies)
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                //注册过滤器
                builder.RegisterFilterProvider();
                builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());



                // OPTIONAL: Register the Autofac filter provider.
                //builder.RegisterWebApiFilterProvider(config);

                // OPTIONAL: Register the Autofac model binder provider.
                builder.RegisterWebApiModelBinderProvider();

                // Set the dependency resolver to be Autofac.
                var container = builder.Build();
                //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

                //设置依赖注入解析器
                System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
 
                 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
