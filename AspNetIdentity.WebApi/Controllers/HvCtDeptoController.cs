using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvctdepto")]
    public class HvCtDeptoController : ApiController
    {
        [Authorize]
        [Route("gethvctdeptoid/{id}")]
        public HvCtDeptoModel Get(int id)
           
        {
            var model = new HvCtDeptoModel();
            if (id != 0) {
                HvCtDeptoLogic a = new HvCtDeptoLogic();
                model=  a.ConsultarId(id);
            }
           
            return model;
        }

        [Authorize]
        [Route("gethvctdepto/{IdP}")]
        public List<HvCtDeptoModel> Get(string IdP)
        {
            HvCtDeptoLogic a = new HvCtDeptoLogic();
            var model = new List<HvCtDeptoModel>();
            if (IdP.Equals("0") || IdP.Equals("") || IdP is null)
            {
                model = a.Consulta();
            }
            else {
                model = a.ConsultarIdP(IdP);
            }
            return model;
        }

        [HttpPost]
        [Authorize]
        [Route("hvctdeptocreate")]
        public IHttpActionResult Post(HvCtDeptoModel b)
        {
            HvCtDeptoLogic a = new HvCtDeptoLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvctdeptoupdate")]
        public IHttpActionResult Put(HvCtDeptoModel b)
        {
            HvCtDeptoLogic a = new HvCtDeptoLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.NOMBRE)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvctdeptodelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvCtDeptoLogic a = new HvCtDeptoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}