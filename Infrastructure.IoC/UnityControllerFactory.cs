using Microsoft.Practices.Unity;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace le0zh.Infrastructure.IoC
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer _container;
        public UnityControllerFactory(IUnityContainer container)
        {
            this._container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                var val =  null == controllerType ? null : (IController)this._container.Resolve(controllerType);
                return val;
            }
            catch
            {
                return null;
            }
        }
    }
}
