using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sediment.Test
{
    public class Starter
    {
        [TestInitialize]
        public void Initialize()
        {
            var builder = new ContainerBuilder();


            var container = builder.Build();

            IocContainer.Build(new IocContainerAdapter(container));
        }
    }
}
