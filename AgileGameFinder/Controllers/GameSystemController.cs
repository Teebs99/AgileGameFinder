using Data;
using Services;
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

        [HttpPost]
        public IHttpActionResult CreateGameSystem(CreateGameSystem model)
        {
            var service = CreateService();
            if (!ModelState.IsValid)
                return BadRequest();
            if (!service.AddGameSystem(model))
                return InternalServerError();
            return Ok();
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
    }
}
