using AgileGameFinder.Models;

using Data;
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

        public IEnumerable<GameSystemListItem> GetCompatibleList(string game)
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameSystems.Where(q => q.Games.Contains(game)).Select(q=> new GameSystemListItem() { SystemName = q.SystemName});
                return query;
            }
        }

        public bool AddGameToSystem(int systemId, string game)
        {
            using (var ctx = new ApplicationDbContext())
            {
                GameSystem entity = ctx.GameSystems.Find(systemId);
                entity.Games.Add(game);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveGameFromSystem(int systemId, string game)
        {
            using (var ctx = new ApplicationDbContext())
            {
                GameSystem entity = ctx.GameSystems.Find(systemId);
                entity.Games.Remove(game);
                return ctx.SaveChanges() == 1;
            }
           public bool DeleteGameSystem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameSystems.Single(e => e.SystemId == id);
                ctx.GameSystems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

    }
}
