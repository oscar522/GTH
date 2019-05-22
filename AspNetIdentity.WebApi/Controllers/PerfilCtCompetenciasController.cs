using AspNetIdentity.WebApi.Models;
using AspNetIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctcompetencias")]
    public class PerfilCtCompetenciasController : ApiController
    {
        [Authorize]
        [Route("getperfilctcompetenciasid/{id}")]
        public PerfilCtCompetenciasModel Get(int id)
        {
            PerfilCtCompetenciasLogic a = new PerfilCtCompetenciasLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctcompetencias")]
        public List<PerfilCtCompetenciasModel> Get()
        {
            PerfilCtCompetenciasLogic a = new PerfilCtCompetenciasLogic();
            var model = new List<PerfilCtCompetenciasModel>();
            model = a.Consulta();
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctcompetenciascreate")]
        public IHttpActionResult Post(PerfilCtCompetenciasModel b)
        {
            PerfilCtCompetenciasLogic a = new PerfilCtCompetenciasLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("perfilctcompetenciasupdate")]
        public IHttpActionResult Put(PerfilCtCompetenciasModel b)
        {
            PerfilCtCompetenciasLogic a = new PerfilCtCompetenciasLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctcompetenciasdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilCtCompetenciasLogic a = new PerfilCtCompetenciasLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}
