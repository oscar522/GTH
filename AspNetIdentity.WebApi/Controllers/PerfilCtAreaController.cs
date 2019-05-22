using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctarea")]
    public class PerfilCtAreaController: ApiController
    {
        [Authorize]
        [Route("getperfilctareaid/{id}")]
        public PerfilCtAreaModel Get(int id)
        {
            PerfilCtAreLogic a = new PerfilCtAreLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctarea")]
        public List<PerfilCtAreaModel> Get()
        {
           PerfilCtAreLogic a = new PerfilCtAreLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctareacreate")]
        public IHttpActionResult Post(PerfilCtAreaModel b)
        {
           PerfilCtAreLogic a = new PerfilCtAreLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.DESCRIPCION)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilctareaupdate")]
        public IHttpActionResult Put(PerfilCtAreaModel b)
        {
           PerfilCtAreLogic a = new PerfilCtAreLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.DESCRIPCION)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctareadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
           PerfilCtAreLogic a = new PerfilCtAreLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}