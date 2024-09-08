using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Burada hangi interface'in karşılığı ne olacak onu belirtiyoruz
            
       
            builder.RegisterType<CarManager>().As<ICarService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCarDal>().As<ICarDal>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().InstancePerLifetimeScope();
            builder.RegisterType<RentalManager>().As<IRentalService>().InstancePerLifetimeScope();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();

          
        }
    }
}
