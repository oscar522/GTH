using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctinstituciones")]
    public class HvCtInstitucionesController : ApiController
    {
        [Authorize]
        [Route("gethvctinstitucionesid/{id}")]
        public HvCtInstitucionesModel Get(int id)
        {
            HvCtInstitucionesLogic a = new HvCtInstitucionesLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctinstituciones")]
        public List<HvCtInstitucionesModel> Get()
        {
            HvCtInstitucionesLogic a = new HvCtInstitucionesLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctinstitucionescreate")]
        public IHttpActionResult Post(HvCtInstitucionesModel b)
        {
            HvCtInstitucionesLogic a = new HvCtInstitucionesLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctinstitucionesupdate")]
        public IHttpActionResult Put(HvCtInstitucionesModel b)
        {
            HvCtInstitucionesLogic a = new HvCtInstitucionesLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctinstitucionesdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtInstitucionesLogic a = new HvCtInstitucionesLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}