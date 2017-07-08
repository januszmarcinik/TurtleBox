using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities.TurtleBarrel;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.NoteImages;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Notes;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.TimeCounters;

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
            CreateMap<Note, NoteViewModel>();

            CreateMap<NoteImage, NoteImageViewModel>()
                .Ignore(p => p.Image);

            CreateMap<TimeCounter, TimeCounterViewModel>();
        }
        #endregion
    }
}