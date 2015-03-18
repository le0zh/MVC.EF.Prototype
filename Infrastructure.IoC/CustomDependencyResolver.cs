using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace le0zh.Infrastructure.IoC
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        private static CustomDependencyResolver _instance;

        public static CustomDependencyResolver GetInstance()
        {
            return _instance;
        }
        private readonly IUnityContainer _container;
        public CustomDependencyResolver()
        {
            this._container = new UnityContainer();
            _instance = this;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this._container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return Enumerable.Empty<object>();
            }
        }
    }
}
