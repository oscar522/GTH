using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;
using System.Threading.Tasks;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctciudad")]
    public class HvCtCiudadController : ApiController
    {
        [Authorize]
        [Route("gethvctciudadid/{id}")]
        public HvCtCiudadModel Get(int id)
        {
            HvCtCiudadLogic a = new HvCtCiudadLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvctciudad/{IdP}")]
        public List<HvCtCiudadModel> Get(string IdP)
        {
            HvCtCiudadLogic a = new HvCtCiudadLogic();
            var model = new List<HvCtCiudadModel>();
            if (IdP.Equals("0") || IdP.Equals("") || IdP is null)
            {
                model = a.Consulta();
            }
            else
            {
                model = a.ConsultarIdP(IdP);
            }
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("hvctciudadcreate")]
        public IHttpActionResult Post(HvCtCiudadModel b)
        {
            HvCtCiudadLogic a = new HvCtCiudadLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctciudadupdate")]
        public IHttpActionResult Put(HvCtCiudadModel b)
        {
            HvCtCiudadLogic a = new HvCtCiudadLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctciudaddelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtCiudadLogic a = new HvCtCiudadLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}