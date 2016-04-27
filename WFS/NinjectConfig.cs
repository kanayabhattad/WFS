using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WFS
{
    public static class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {

        }
    }
}