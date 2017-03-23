using JanuszMarcinik.Mvc.Domain.Application.Services;
using JanuszMarcinik.Mvc.Domain.Application.Services.Dictionaries;
using JanuszMarcinik.Mvc.Domain.Application.Services.Questionnaires;
using JanuszMarcinik.Mvc.Domain.Identity.Context;
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
            kernel.Bind<ApplicationIdentityDbContext>().ToSelf().InRequestScope();

            kernel.Bind<AnswerService>().ToSelf().InRequestScope();
            kernel.Bind<IntervieweeService>().ToSelf().InRequestScope();
            kernel.Bind<QuestionnaireService>().ToSelf().InRequestScope();
            kernel.Bind<QuestionService>().ToSelf().InRequestScope();
            kernel.Bind<ResultService>().ToSelf().InRequestScope();
            kernel.Bind<BaseDictionaryService>().ToSelf().InRequestScope();
        }
    }
}