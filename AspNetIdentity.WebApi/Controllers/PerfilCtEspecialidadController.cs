using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctespecialidad")]
    public class PerfilCtEspecialidadController : ApiController
    {
        [Authorize]
        [Route("getperfilctespecialidadid/{id}")]
        public PerfilCtEspecialidadModel Get(int id)
        {
            PerfilCtEspecialidadLogic a = new PerfilCtEspecialidadLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctespecialidad")]
        public List<PerfilCtEspecialidadModel> Get()
        {
            PerfilCtEspecialidadLogic a = new PerfilCtEspecialidadLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctespecialidadcreate")]
        public IHttpActionResult Post(PerfilCtEspecialidadModel b)
        {
            PerfilCtEspecialidadLogic a = new PerfilCtEspecialidadLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilctespecialidadupdate")]
        public IHttpActionResult Put(PerfilCtEspecialidadModel b)
        {
            PerfilCtEspecialidadLogic a = new PerfilCtEspecialidadLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctespecialidaddelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilCtEspecialidadLogic a = new PerfilCtEspecialidadLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}
