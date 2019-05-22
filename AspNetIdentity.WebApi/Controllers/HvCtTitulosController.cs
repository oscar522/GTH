using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvcttitulos")]
    public class HvCtTitulosController : ApiController
    {
        [Authorize]
        [Route("gethvcttitulosid/{id}")]
        public HvCtTitulosModel Get(int id)
        {
            HvCtTitulosLogic a = new HvCtTitulosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvcttitulos")]
        public List<HvCtTitulosModel> Get()
        {
            HvCtTitulosLogic a = new HvCtTitulosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvcttituloscreate")]
        public IHttpActionResult Post(HvCtTitulosModel b)
        {
            HvCtTitulosLogic a = new HvCtTitulosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize]
        [Route("hvcttitulosupdate")]
        public IHttpActionResult Put (HvCtTitulosModel b)
        {
            HvCtTitulosLogic a = new HvCtTitulosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvcttitulosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtTitulosLogic a = new HvCtTitulosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}