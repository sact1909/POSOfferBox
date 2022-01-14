using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Module = Autofac.Module;
using System.Reflection;

namespace POSOfferBox.BL
{
    public class BLModule : Module
    {
        //
        /// <summary>
        /// Este modulo lo que hace es todar todas las clases que implementan interfaces
        /// e registrarlas con las interfaces que tienen, eso permite que de manera automatica 
        /// se tome todo lo que tiene la libreria y se auto-inyecte
        /// en este caso BasicService y IBasicService se auto registran.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var _current = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(_current)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();

            base.Load(builder);
        }
    }
}
