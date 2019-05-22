using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvconocimientos")]
    public class HvConocimientosController : ApiController
    {
        [Authorize]
        [Route("gethvconocimientosid/{id}")]
        public HvConocimientosModel Get(int id)
        {
            HvConocimientosLogic a = new HvConocimientosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvconocimientosidd/{idd}")]
        public List<HvConocimientosModel> GetD(int idd)
        {
            HvConocimientosLogic a = new HvConocimientosLogic();
            return a.ConsultarIdP(idd);
        }

        [Authorize]
        [Route("gethvconocimientos")]
        public List<HvConocimientosModel> Get()
        {
            HvConocimientosLogic a = new HvConocimientosLogic();
            return a.Consulta(); ;
        }

        [HttpPost]
        [Authorize]
        [Route("hvconocimientoscreate")]
        public IHttpActionResult Post(HvConocimientosModel b)
        {
            HvConocimientosLogic a = new HvConocimientosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvconocimientosupdate")]
        public IHttpActionResult Put(HvConocimientosModel b)
        {
            HvConocimientosLogic a = new HvConocimientosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvconocimientosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvConocimientosLogic a = new HvConocimientosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}