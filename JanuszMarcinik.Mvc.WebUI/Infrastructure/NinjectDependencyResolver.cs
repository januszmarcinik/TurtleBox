using JanuszMarcinik.Mvc.Domain.Application.Repositories.Abstract;
using JanuszMarcinik.Mvc.Domain.Application.Repositories.Concrete;
using JanuszMarcinik.Mvc.Domain.Data;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

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
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();

            kernel.Bind<INotesRepository>().To<NotesRepository>().InSingletonScope();
            kernel.Bind<INoteImagesRepository>().To<NoteImagesRepository>().InSingletonScope();
            kernel.Bind<ITimeCountersRepository>().To<TimeCountersRepository>().InSingletonScope();
        }
    }
}