using JanuszMarcinik.Mvc.Domain.Application.Services;
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
            kernel.Bind<GoalService>().ToSelf().InRequestScope();
            kernel.Bind<LeagueService>().ToSelf().InRequestScope();
            kernel.Bind<MatchService>().ToSelf().InRequestScope();
            kernel.Bind<PlayerService>().ToSelf().InRequestScope();
            kernel.Bind<SeasonService>().ToSelf().InRequestScope();
            kernel.Bind<TableService>().ToSelf().InRequestScope();
            kernel.Bind<TeamService>().ToSelf().InRequestScope();
        }
    }
}