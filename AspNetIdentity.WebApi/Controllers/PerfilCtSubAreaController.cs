using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilctsubarea")]
    public class PerfilCtSubAreaController : ApiController
    {
        [Authorize]
        [Route("getperfilctsubareaid/{id}")]
        public PerfilCtSubAreaModel Get(int id)
        {
            PerfilCtSubAreaLogic a = new PerfilCtSubAreaLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilctsubarea")]
        public List<PerfilCtSubAreaModel> Get()
        {
            PerfilCtSubAreaLogic a = new PerfilCtSubAreaLogic();
            var model = new List<PerfilCtSubAreaModel>();
            return model = a.Consulta();
              //  model = a.ConsultarIdP(IdP);
        }

        [Authorize]
        [Route("getperfilctsubarearea/{id}")]
        public List<PerfilCtSubAreaModel> GetIDArea(int id)
        {
            PerfilCtSubAreaLogic a = new PerfilCtSubAreaLogic();
            var model = new List<PerfilCtSubAreaModel>();
            return model = a.ConsultarIdP(id.ToString());
           //  model = a.ConsultarIdP(IdP);
        }

        [HttpPost]
        [Authorize]
        [Route("perfilctsubareacreate")]
        public IHttpActionResult Post(PerfilCtSubAreaModel b)
        {
             PerfilCtSubAreaLogic a = new PerfilCtSubAreaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.DESCRIPCION)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilctsubareaupdate")]
        public IHttpActionResult Put(PerfilCtSubAreaModel b)
        {
             PerfilCtSubAreaLogic a = new PerfilCtSubAreaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.DESCRIPCION)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilctsubareadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
             PerfilCtSubAreaLogic a = new PerfilCtSubAreaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}