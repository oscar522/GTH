using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Models
{
    [RoutePrefix("api/perfilfinalidad")]
    public class PerfilFinalidadController : ApiController
    {
        [Authorize]
        [Route("getperfilfinalidadid/{id}")]
        public PerfilFinalidadModel Get(int id)
        {
            PerfilFinalidadLogic a = new PerfilFinalidadLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("getperfilfinalidadidd/{idd}")]
        public List<PerfilFinalidadModel> GetD(string idd)
        {
            PerfilFinalidadLogic a = new PerfilFinalidadLogic();
            return a.ConsultarIdD(idd);/*______________*/
        }

        [Authorize]    /*______________*/
        [Route("getperfilfinalidad")]
        public List<PerfilFinalidadModel> Get(string IdP)
        {
            PerfilFinalidadLogic a = new PerfilFinalidadLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("perfilfinalidadcreate")]
        public IHttpActionResult Post(PerfilFinalidadModel b)
        {
            PerfilFinalidadLogic a = new PerfilFinalidadLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();

        }

        [HttpPut]
        [Authorize]
        [Route("perfilfinalidadupdate")]
        public IHttpActionResult Put(PerfilFinalidadModel b)
        {
            PerfilFinalidadLogic a = new PerfilFinalidadLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_PERFIL.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("getperfilfinalidaddelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            PerfilFinalidadLogic a = new PerfilFinalidadLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}
