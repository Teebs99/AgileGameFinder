﻿using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileGameFinder.Controllers
{
    public class GameSystemController : ApiController
    {
        private GameSystemServices CreateService()
        {
            return new GameSystemServices();
        }

        [HttpGet]
        public IHttpActionResult GetGamesBySystemName(string consoleName)
        {
            var service = CreateService();
            var entity = service.GetGamesByGameSystemName(consoleName);
            if (entity != null)
                return Ok(entity);
            return NotFound();

        }
        [HttpGet]
        public IHttpActionResult GetCompatibleSystems(string game)
        {
            var service = CreateService();
            var entity = service.GetCompatibleList(game);
            if (entity != null)
                return Ok(entity);
            return NotFound();
        }
        [HttpPut]
        public IHttpActionResult AddGameToConsole(int systemId, string game)
        {
            var service = CreateService();
            if (!service.AddGameToSystem(systemId, game))
                return InternalServerError();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult DeleteGameFromConsole(int systemId, string game)
        {
            var service = CreateService();
            if (!service.RemoveGameFromSystem(systemId, game))
                return InternalServerError();
            return Ok();
        }
    }
}
