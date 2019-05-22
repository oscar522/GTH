using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctescolaridad")]
    public class PerfilCtEscolaridadController : ApiController
    {
        [Authorize]
        [Route("getperfilctescolaridadid/{id}")]
        public PerfilCtEscolaridadModel Get(int id)
        {
            PerfilCtEscolaridadLogic a = new PerfilCtEscolaridadLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctescolaridad")]
        public List<PerfilCtEscolaridadModel> Get()
        {
            PerfilCtEscolaridadLogic a = new PerfilCtEscolaridadLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctescolaridadcreate")]
        public IHttpActionResult Post(PerfilCtEscolaridadModel b)
        {
            PerfilCtEscolaridadLogic a = new PerfilCtEscolaridadLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilctescolaridadupdate")]
        public IHttpActionResult Put(PerfilCtEscolaridadModel b)
        {
            PerfilCtEscolaridadLogic a = new PerfilCtEscolaridadLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctescolaridaddelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilCtEscolaridadLogic a = new PerfilCtEscolaridadLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}
