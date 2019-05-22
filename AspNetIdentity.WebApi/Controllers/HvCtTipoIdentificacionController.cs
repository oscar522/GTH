using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvcttipoidentificacion")]
    public class HvCtTipoIdentificacionController : ApiController
    {
        [Authorize]
        [Route("gethvcttipoidentificacionid/{id}")]
        public HvCtTipoIdentificacionModel Get(int id)
        {
            HvCtTipoIdentificacionLogic a = new HvCtTipoIdentificacionLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvcttipoidentificacion")]
        public List<HvCtTipoIdentificacionModel> Get()
        {
            HvCtTipoIdentificacionLogic a = new HvCtTipoIdentificacionLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvcttipoidentificacioncreate")]
        public IHttpActionResult Post(HvCtTipoIdentificacionModel b)
        {
            HvCtTipoIdentificacionLogic a = new HvCtTipoIdentificacionLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvcttipoidentificacionupdate")]
        public IHttpActionResult Put(HvCtTipoIdentificacionModel b)
        {
            HvCtTipoIdentificacionLogic a = new HvCtTipoIdentificacionLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvcttipoidentificaciondelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtTipoIdentificacionLogic a = new HvCtTipoIdentificacionLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}