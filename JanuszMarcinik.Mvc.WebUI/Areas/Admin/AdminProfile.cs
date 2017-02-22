using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Leagues;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Seasons;
using JanuszMarcinik.Mvc.WebUI.Areas.Admin.Models.Teams;

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
            CreateMap<Season, SeasonViewModel>();

            CreateMap<League, LeagueViewModel>()
                .Ignore(p => p.Image);

            CreateMap<Team, TeamViewModel>()
                .ForMember(p => p.League, o => o.MapFrom(s => s.League))
                .Ignore(p => p.Image);

            CreateMap<Player, PlayerViewModel>();

            CreateMap<Table, TableViewModel>();

            CreateMap<Match, MatchViewModel>();
        }
        #endregion
    }
}