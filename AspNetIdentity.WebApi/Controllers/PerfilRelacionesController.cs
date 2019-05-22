using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilrelaciones")]
    public class PerfilRelacionesController : ApiController
    {
        [Authorize]
        [Route("getperfilrelacionesid/{id}")]
        public PerfilRelacionesModel Get(int id)
        {
            PerfilRelacionesLogic a = new PerfilRelacionesLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilrelacionesidd/{idd}")]
        public List<PerfilRelacionesModel> GetD(string idd)
        {
            PerfilRelacionesLogic a = new PerfilRelacionesLogic();
            return a.ConsultarIdD(idd);/*______________*/
        }

        [Authorize]    /*______________*/
        [Route("getperfilrelaciones")]
        public List<PerfilRelacionesModel> Get(string IdP)
        {
            PerfilRelacionesLogic a = new PerfilRelacionesLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilrelacionescreate")]
        public IHttpActionResult Post(PerfilRelacionesModel b)
        {
            PerfilRelacionesLogic a = new PerfilRelacionesLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilrelacionesupdate")]
        public IHttpActionResult Put(PerfilRelacionesModel b)
        {
            PerfilRelacionesLogic a = new PerfilRelacionesLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilrelacionesdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilRelacionesLogic a = new PerfilRelacionesLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}