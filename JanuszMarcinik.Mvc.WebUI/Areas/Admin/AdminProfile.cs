using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.Questionnaires;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questionnaires;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Questions;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Admin
{
    public class AdminProfile : Profile
    {
        #region ProfileName
        public override string ProfileName
        {
            get { return this.GetType().FullName; }
        }
        #endregion

        #region AdminProfile()
        public AdminProfile()
        {
            CreateMap<Questionnaire, QuestionnaireViewModel>();

            CreateMap<Question, QuestionViewModel>()
                .ForMember(p => p.Questionnaire, o => o.MapFrom(s => s.Questionnaire));
        }
        #endregion
    }
}