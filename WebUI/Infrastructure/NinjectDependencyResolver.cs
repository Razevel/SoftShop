using Domain.Abstract;
using Domain.Concrete.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Entities;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IRepository<Product>>().To<ProductsRepository>();
            kernel.Bind<IRepository<Order>>().To<OrdersRepository>();
            kernel.Bind<IRepository<Category>>().To<CategoriesRepository>();

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}