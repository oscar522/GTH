using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctestadocivil")]
    public class HvCtEstadoCivilController : ApiController
    {
        [Authorize]
        [Route("gethvctestadocivilid/{id}")]
        public HvCtEstadoCivilModel Get(int id)
        {
            HvCtEstadoCivilLogic a = new HvCtEstadoCivilLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctestadocivil")]
        public List<HvCtEstadoCivilModel> Get()
        {
            HvCtEstadoCivilLogic a = new HvCtEstadoCivilLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctestadocivilcreate")]
        public IHttpActionResult Post(HvCtEstadoCivilModel b)
        {
            HvCtEstadoCivilLogic a = new HvCtEstadoCivilLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctestadocivilupdate")]
        public IHttpActionResult Put(HvCtEstadoCivilModel b)
        {
            HvCtEstadoCivilLogic a = new HvCtEstadoCivilLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctestadocivildelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtEstadoCivilLogic a = new HvCtEstadoCivilLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}