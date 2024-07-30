using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using SMS.Domain.Abstract;
using SMS.Domain.Concrete;

namespace SMS.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver 
    {
        private readonly IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IStudentRepository>().To<EFStudentRepository>();
            kernel.Bind<IStaffRepository>().To<EFStaffRepository>();
            kernel.Bind<IScheduleRepository>().To<EFScheduleRepository>();
            kernel.Bind<ICourseRepository>().To<EFCourseRepository>();
            kernel.Bind<ISubjectRepository>().To<EFSubjectRepository>();
            kernel.Bind<ITransactionRepository>().To<EFTransactionRepository>();
            // put bindings here
        }
    }
}