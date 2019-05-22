using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctcargo")]
    public class HvCtCargoController : ApiController
    {
        [Authorize]
        [Route("gethvctcargoid/{id}")]
        public HvCtCargoModel Get(int id)
        {
            HvCtCargoLogic a = new HvCtCargoLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctcargo")]
        public List<HvCtCargoModel> Get()
        {
            HvCtCargoLogic a = new HvCtCargoLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctcargocreate")]
        public IHttpActionResult Posthvctcargocreate(HvCtCargoModel HvCtCargo)
        {
            HvCtCargoLogic a = new HvCtCargoLogic();
            var result = a.Crear(HvCtCargo);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctcargoupdate")]
        public IHttpActionResult Puthvctcargoupdate(HvCtCargoModel HvCtCargo)
        {
            HvCtCargoLogic a = new HvCtCargoLogic();
            var result = a.Actualizar(HvCtCargo);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctcargodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtCargoLogic a = new HvCtCargoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}