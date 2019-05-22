using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvexperiencia")]
    public class HvExperienciaController: ApiController
    {
        [Authorize]
        [Route("gethvexperienciaid/{id}")]
        public HvExperienciaModel Get(int id)
        {
            HvExperienciaLogic a = new HvExperienciaLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvexperienciaidd/{idd}")]
        public List<HvExperienciaModel> GetD(int idd)
        {
            HvExperienciaLogic a = new HvExperienciaLogic();
            return a.ConsultarIdD(idd);
        }

        [Authorize]
        [Route("gethvexperiencia")]
        public List<HvExperienciaModel> Get(string IdP)
        {
            HvExperienciaLogic a = new HvExperienciaLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvexperienciacreate")]
        public IHttpActionResult Post(HvExperienciaModel b)
        {
            HvExperienciaLogic a = new HvExperienciaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvexperienciaupdate")]
        public IHttpActionResult Put(HvExperienciaModel b)
        {
            HvExperienciaLogic a = new HvExperienciaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvexperienciadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvExperienciaLogic a = new HvExperienciaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}