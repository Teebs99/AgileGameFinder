using AgileGameFinder.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GameSystemServices
    {

        public List<string> GetGamesByGameSystemName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameSystems.Single(e => e.SystemName.ToLower() == name.ToLower());
                return entity.Games;
            }
        }
        public IEnumerable<GameSystemListItem> GetCompatibleList(string game)
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameSystems.Where(q => q.Games.Contains(game)).Select(q=> new GameSystemListItem() { SystemName = q.SystemName});
                return query;
            }
        }
    }
}
