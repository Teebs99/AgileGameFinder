using AgileGameFinder.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GameSystemServices
    {
        public bool AddGameSystem(CreateGameSystem model)
        {
            var entity = new GameSystem() { CompanyName = model.CompanyName, SystemName = model.SystemName };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameSystems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<string> GetGamesByGameSystemName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameSystems.Single(e => e.SystemName.ToLower() == name.ToLower());
                return entity.Games;
            }
        }
        
    }
}
