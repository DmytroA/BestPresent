using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Configuration;

namespace TourSite2.Models
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
              ? null
              : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}