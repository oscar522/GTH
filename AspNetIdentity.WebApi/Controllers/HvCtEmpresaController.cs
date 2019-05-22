using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctempresa")]
    public class HvCtEmpresaController : ApiController
    {
        [Authorize]
        [Route("gethvctempresaid/{id}")]
        public HvCtEmpresaModel Get(int id)
        {
            HvCtEmpresaLogic a = new HvCtEmpresaLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctempresa")]
        public List<HvCtEmpresaModel> Get()
        {
            HvCtEmpresaLogic a = new HvCtEmpresaLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvctempresacreate")]
        public IHttpActionResult Post(HvCtEmpresaModel b)
        {
            HvCtEmpresaLogic a = new HvCtEmpresaLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctempresaupdate")]
        public IHttpActionResult Put(HvCtEmpresaModel b)
        {
            HvCtEmpresaLogic a = new HvCtEmpresaLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctempresadelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtEmpresaLogic a = new HvCtEmpresaLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}