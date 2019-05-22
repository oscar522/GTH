using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace desempeno.webapi.Controllers
{
    [RoutePrefix("api/hvestudios")]
    public class HvEstudiosController : ApiController
    {
        [Authorize]
        [Route("gethvestudiosid/{id}")]
        public HvEstudiosModel Get(int id)
        {
            HvEstudiosLogic a = new HvEstudiosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvestudiosidd/{idd}")]
        public List<HvEstudiosModel> GetD(int idd)
        {
            HvEstudiosLogic a = new HvEstudiosLogic();
            return a.ConsultarIdD(idd);/*______________*/
        }

        [Authorize]    /*______________*/
        [Route("gethvestudios")]
        public List<HvEstudiosModel> Get()
        {
            HvEstudiosLogic a = new HvEstudiosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvestudioscreate")]
        public IHttpActionResult Post(HvEstudiosModel b)
        {
            HvEstudiosLogic a = new HvEstudiosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvestudiosupdate")]
        public IHttpActionResult Put(HvEstudiosModel b)
        {
            HvEstudiosLogic a = new HvEstudiosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvestudiosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvEstudiosLogic a = new HvEstudiosLogic();
           string resul = a.Eliminar(id);
            return resul;
        }
    }
}