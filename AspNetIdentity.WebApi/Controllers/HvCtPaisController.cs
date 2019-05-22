using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Text.RegularExpressions;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctpais")]
    public class HvCtPaisController : ApiController
    {
        [Authorize]
        [Route("gethvctpaisid/{id}")]
        public HvCtPaisModel Get(int id)
        {
            HvCtPaisLogic a = new HvCtPaisLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctpais")]
        public List<HvCtPaisModel> Get()
        {
            HvCtPaisLogic a = new HvCtPaisLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctpaiscreate")]
        public IHttpActionResult Post(HvCtPaisModel b)
        {      
            HvCtPaisLogic a = new HvCtPaisLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctpaisupdate")]
        public IHttpActionResult Put(HvCtPaisModel b)
        {
            HvCtPaisLogic a = new HvCtPaisLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctpaisdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtPaisLogic a = new HvCtPaisLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}