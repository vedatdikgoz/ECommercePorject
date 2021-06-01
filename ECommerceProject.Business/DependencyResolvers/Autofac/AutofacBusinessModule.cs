using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Business.Concrete;
using ECommerceProject.Core.Utilities.Interceptors;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.DataAccess.Concrete.EntityFramework;

namespace ECommerceProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderRepository>().As<IOrderRepository>().SingleInstance();

            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<EfMessageRepository>().As<IMessageRepository>().SingleInstance();

            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();
            builder.RegisterType<EfCartRepository>().As<ICartRepository>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
