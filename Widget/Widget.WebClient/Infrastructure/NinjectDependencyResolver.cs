using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Widget.Domain.Abstract;
using Widget.Domain.Concrete;

namespace Widget.WebClient.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel) {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            kernel.Bind<IStateRepository>().To<EfStateRepository>();
            kernel.Bind<IWidgetRepository>().To<EfWidgetRepository>();
        }
    }
}