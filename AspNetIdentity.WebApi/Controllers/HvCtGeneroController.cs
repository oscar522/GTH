using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctgenero")]
    public class HvCtGeneroController : BaseApiController
    {
        // GET api/values/5
        [Authorize]
        [Route("gethvctgeneroid/{id}")]
        public HvCtGeneroModel Get(int id)
        {
            HvCtGeneroLogic a = new HvCtGeneroLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        [Authorize]
        [Route("gethvctgenero")]
        public List<HvCtGeneroModel> Get()
        {
            HvCtGeneroLogic a = new HvCtGeneroLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctgenerocreate")]
        public IHttpActionResult Post(HvCtGeneroModel b)
        {
            HvCtGeneroLogic a = new HvCtGeneroLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctgeneroupdate")]
        public IHttpActionResult Put(HvCtGeneroModel b)
        {
            HvCtGeneroLogic a = new HvCtGeneroLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctgenerodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtGeneroLogic a = new HvCtGeneroLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}