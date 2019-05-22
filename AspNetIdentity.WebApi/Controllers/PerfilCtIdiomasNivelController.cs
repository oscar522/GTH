using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctnivelidiomas")]
    public class PerfilCtIdiomasNivelController : ApiController
    {
        [Authorize]
        [Route("getperfilctnivelidiomasid/{id}")]
        public PerfilCtIdiomasNivelModel Get(int id)
        {
            PerfilCtIdiomasNivelLogic a = new PerfilCtIdiomasNivelLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctnivelidiomas")]
        public List<PerfilCtIdiomasNivelModel> Get()
        {
            PerfilCtIdiomasNivelLogic a = new PerfilCtIdiomasNivelLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctnivelidiomascreate")]
        public IHttpActionResult Post(PerfilCtIdiomasNivelModel b)
        {
            PerfilCtIdiomasNivelLogic a = new PerfilCtIdiomasNivelLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilctnivelidiomasupdate")]
        public IHttpActionResult Put(PerfilCtIdiomasNivelModel b)
        {
            PerfilCtIdiomasNivelLogic a = new PerfilCtIdiomasNivelLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctnivelidiomasdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilCtIdiomasNivelLogic a = new PerfilCtIdiomasNivelLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}
