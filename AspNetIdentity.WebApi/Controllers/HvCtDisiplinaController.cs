using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctdisiplina")]
    public class HvCtDisiplinaController : ApiController
    {
        [Authorize]
        [Route("gethvctdisiplinaid/{id}")]
        public HvCtDisiplinaModel Get(int id)
        {
            HvCtDisiplinaLogic a = new HvCtDisiplinaLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctdisiplina")]
        public List<HvCtDisiplinaModel> Get()
        {
            HvCtDisiplinaLogic a = new HvCtDisiplinaLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctdisiplinacreate")]
        public IHttpActionResult Post(HvCtDisiplinaModel b)
        {
            HvCtDisiplinaLogic a = new HvCtDisiplinaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctdisiplinaupdate")]
        public IHttpActionResult Put(HvCtDisiplinaModel b)
        {
            HvCtDisiplinaLogic a = new HvCtDisiplinaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctdisiplinadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtDisiplinaLogic a = new HvCtDisiplinaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}