using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/perfilprocesos")]
    public class PerfilProcesosController : ApiController
    {
        [Authorize]
        [Route("getperfilprocesosid/{id}")]
        public PerfilProcesosModel Get(int id)
        {
            PerfilProcesosLogic a = new PerfilProcesosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilprocesosidd/{idd}")]
        public List<PerfilProcesosModel> GetD(string idd)
        {
            PerfilProcesosLogic a = new PerfilProcesosLogic();
            return a.ConsultarIdD(idd);/*______________*/
        }

        [Authorize]    /*______________*/
        [Route("getperfilprocesos")]
        public List<PerfilProcesosModel> Get(string IdP)
        {
            PerfilProcesosLogic a = new PerfilProcesosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilprocesoscreate")]
        public IHttpActionResult Post(PerfilProcesosModel b)
        {
            PerfilProcesosLogic a = new PerfilProcesosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("perfilprocesosupdate")]
        public IHttpActionResult Put(PerfilProcesosModel b)
        {
            PerfilProcesosLogic a = new PerfilProcesosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilprocesosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilProcesosLogic a = new PerfilProcesosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}