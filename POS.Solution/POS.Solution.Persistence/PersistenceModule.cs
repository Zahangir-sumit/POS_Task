using Autofac;
using POS.Solution.Persistence.IRepository;
using POS.Solution.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Persistence
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PosRepository>().As<IPosRepository>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
