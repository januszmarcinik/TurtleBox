using JanuszMarcinik.Mvc.Domain.Application.Base;
using JanuszMarcinik.Mvc.Domain.Application.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace JanuszMarcinik.Mvc.Domain.Application.Services
{
    public class TeamService : BaseService<Team>
    {
        new public Team GetById(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Teams.Include(x => x.League).FirstOrDefault(x => x.TeamId == id);
            }
        }

        public List<Team> GetList(long leagueId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Teams.Where(x => x.LeagueId == leagueId).Include(x => x.League).ToList();
            }
        }
    }
}