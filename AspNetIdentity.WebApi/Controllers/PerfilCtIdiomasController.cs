using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctidiomas")]
    public class PerfilCtIdiomasController : ApiController
    {
        [Authorize]
        [Route("getperfilctidiomasid/{id}")]
        public PerfilCtIdiomasModel Get(int id)
        {
            PerfilCtIdiomasLogic a = new PerfilCtIdiomasLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctidiomas")]
        public List<PerfilCtIdiomasModel> Get()
        {
            PerfilCtIdiomasLogic a = new PerfilCtIdiomasLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctidiomascreate")]
        public IHttpActionResult Post(PerfilCtIdiomasModel b)
        {
            PerfilCtIdiomasLogic a = new PerfilCtIdiomasLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilctidiomasupdate")]
        public IHttpActionResult Put(PerfilCtIdiomasModel b)
        {
            PerfilCtIdiomasLogic a = new PerfilCtIdiomasLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctidiomasdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilCtIdiomasLogic a = new PerfilCtIdiomasLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}