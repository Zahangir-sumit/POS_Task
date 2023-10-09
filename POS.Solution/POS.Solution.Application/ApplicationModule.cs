using Autofac;
using POS.Solution.Application.IService;
using POS.Solution.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PosService>().As<IPosService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
