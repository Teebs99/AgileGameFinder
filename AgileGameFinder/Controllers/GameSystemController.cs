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
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateService();
            if (!service.DeleteGameSystem(id))
                return InternalServerError();
            return Ok();
        }
    }
}
