using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctconocimientos")]
    public class HvCtConocimientosController : ApiController
    {
        [Authorize]
        [Route("gethvctconocimientosid/{id}")]
        public HvCtConocimientosModel Get(int id)
        {
            HvCtConocimientosLogic a = new HvCtConocimientosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctconocimientos")]
        public List<HvCtConocimientosModel> Get()
        {
            HvCtConocimientosLogic a = new HvCtConocimientosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctconocimientoscreate")]
        public IHttpActionResult Post(HvCtConocimientosModel b)
        {
            HvCtConocimientosLogic a = new HvCtConocimientosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctconocimientosupdate")]
        public IHttpActionResult Put(HvCtConocimientosModel b)
        {
            HvCtConocimientosLogic a = new HvCtConocimientosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }
    

        [Authorize]
        [Route("gethvctconocimientosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtConocimientosLogic a = new HvCtConocimientosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}