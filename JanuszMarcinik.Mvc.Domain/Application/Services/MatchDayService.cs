using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.Application.Services
{
    public class MatchDayService : BaseService<MatchDay>
    {
        public List<MatchDay> GetList(long leagueId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.MatchDays.Where(x => x.LeagueId == leagueId)
                    .Include(x => x.League)
                    .Include(x => x.Season).ToList();
            }
        }
    }
}