using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilcttiposcompetencia")]
    public class PerfilCtTiposCompetenciaController : ApiController
    {
        [Authorize]
        [Route("getperfilcttiposcompetenciaid/{id}")]
        public PerfilCtTiposCompetenciaModel Get(int id)
        {
            PerfilCtTiposCompetenciaLogic a = new PerfilCtTiposCompetenciaLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilcttiposcompetencia")]
        public List<PerfilCtTiposCompetenciaModel> Get()
        {
           PerfilCtTiposCompetenciaLogic a = new PerfilCtTiposCompetenciaLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilcttiposcompetenciacreate")]
        public IHttpActionResult Post(PerfilCtTiposCompetenciaModel b)
        {
           PerfilCtTiposCompetenciaLogic a = new PerfilCtTiposCompetenciaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilcttiposcompetenciaupdate")]
        public IHttpActionResult Put(PerfilCtTiposCompetenciaModel b)
        {
           PerfilCtTiposCompetenciaLogic a = new PerfilCtTiposCompetenciaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilcttiposcompetenciadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
           PerfilCtTiposCompetenciaLogic a = new PerfilCtTiposCompetenciaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}