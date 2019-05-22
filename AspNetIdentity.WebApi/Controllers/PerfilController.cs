using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfil")]
    public class PerfilController : ApiController
    {
        [Authorize]
        [Route("getperfilid/{id}")]
        public PerfilModel Get(int id)
        {
            PerfilLogic a = new PerfilLogic();
            return a.ConsultarPerfilId(id);
        }

        [Authorize]
        [Route("getperfil")]
        public List<PerfilModel> Get()
        {
            PerfilLogic a = new PerfilLogic();
            return a.ConsultaPerfil();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilcreate")]
        public IHttpActionResult Post(PerfilModel b)
        {
            PerfilLogic a = new PerfilLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilupdate")]
        public IHttpActionResult Put(PerfilModel b)
        {
            PerfilLogic a = new PerfilLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfildelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilLogic a = new PerfilLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}