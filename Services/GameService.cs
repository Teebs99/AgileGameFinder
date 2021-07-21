﻿using AgileGameFinder.Models;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GameService
    {
        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                Title = model.Title,
                Description = model.Desciption,
                Genre = model.Genre,
                Multiplayer = model.Multiplayer
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Games
                   // .Where(e => e.GameId == )
                   .Select(e => new GameListItem
                   {
                       GameId = e.GameId,
                       Title = e.Title,
                       Description = e.Description,
                       Genre = e.Genre,
                       Multiplayer = e.Multiplayer
                   });
                return query.ToArray();
            }
        }
        public GameDetail GetGameById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Games
                    .Single(e => e.GameId == id);

                    return new GameDetail
                    {
                        GameId = entity.GameId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Genre = entity.Genre,
                        Multiplayer = entity.Multiplayer
                    };
            }
        }
        public bool UpdateGame (GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Games
                    .Single(e => e.GameId == model.GameId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Genre = model.Genre;
                entity.Multiplayer = model.Multiplayer;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Games
                    .Single(e => e.GameId == gameId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
