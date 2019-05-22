using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctactitudes")]
    public class HvCtActitudesController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("gethvctactitudesid/{id}")]
        public HvCtActitudesModel Get(int id)
        {
            HvCtActitudesLogic a = new HvCtActitudesLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("gethvctactitudes")]
        public List<HvCtActitudesModel> Get()
        {
            HvCtActitudesLogic a = new HvCtActitudesLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctactitudescreate")]
        public IHttpActionResult Post(HvCtActitudesModel b)
        {
            HvCtActitudesLogic a = new HvCtActitudesLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctactitudesupdate")]
        public IHttpActionResult Put(HvCtActitudesModel b)
        {
            HvCtActitudesLogic a = new HvCtActitudesLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctactitudesdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtActitudesLogic a = new HvCtActitudesLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}