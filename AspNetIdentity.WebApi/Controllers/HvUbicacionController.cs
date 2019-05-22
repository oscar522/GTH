using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvubicacion")]
    public class HvUbicacionController : ApiController
    {
        [Authorize]
        [Route("gethvubicacionid/{id}")]
        public HvUbicacionModel Get(int id)
        {
            HvUbicacionLogic a = new HvUbicacionLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvubicacionidd/{IdP}")]
        public List<HvUbicacionModel> GetD(int IdP)
        {
            HvUbicacionLogic a = new HvUbicacionLogic();
            return a.ConsultarIdD(IdP);
        }

        [Authorize]    /*______________*/
        [Route("gethvubicacion")]
        public List<HvUbicacionModel> Get(string IdP)
        {
            HvUbicacionLogic a = new HvUbicacionLogic();
            return a.Consulta();
        }



        [HttpPost]
        [Authorize]
        [Route("hvubicacioncreate")]
        public IHttpActionResult Post(HvUbicacionModel b)
        {
            HvUbicacionLogic a = new HvUbicacionLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvubicacionupdate")]
        public IHttpActionResult Put(HvUbicacionModel b)
        {
            HvUbicacionLogic a = new HvUbicacionLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvubicaciondelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvUbicacionLogic a = new HvUbicacionLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}