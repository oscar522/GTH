using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilformacion")]
    public class PerfilFormacionController : ApiController
    {
        [Authorize]
        [Route("getperfilformacionid/{id}")]
        public PerfilFormacionModel Get(int id)
        {
            PerfilFormacionLogic a = new PerfilFormacionLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilformacionidd/{idd}")]
        public List<PerfilFormacionModel> GetD(string idd)
        {
            PerfilFormacionLogic a = new PerfilFormacionLogic();
            return a.ConsultarIdD(idd);/*______________*/
        }


        [Authorize]    /*______________*/
        [Route("getperfilformacion")]
        public List<PerfilFormacionModel> Get(string IdP)
        {
            PerfilFormacionLogic a = new PerfilFormacionLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilformacioncreate")]
        public IHttpActionResult Post(PerfilFormacionModel b)
        {
            PerfilFormacionLogic a = new PerfilFormacionLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilformacionupdate")]
        public IHttpActionResult Put(PerfilFormacionModel b)
        {
            PerfilFormacionLogic a = new PerfilFormacionLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilformaciondelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilFormacionLogic a = new PerfilFormacionLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}