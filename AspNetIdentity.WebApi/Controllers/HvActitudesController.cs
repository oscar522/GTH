using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvactitudes")]
    public class HvActitudesController : ApiController
    {
        [Authorize]
        [Route("gethvactitudesid/{id}")]
        public HvActitudesModel Get(int id)
        {
            HvActitudesLogic a = new HvActitudesLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvactitudesidd/{idd}")]
        public List<HvActitudesModel> GetD(int idd)
        {
            HvActitudesLogic a = new HvActitudesLogic();
            return a.ConsultarIdD(idd);/*______________*/
        }

        [Authorize]    /*______________*/
        [Route("gethvactitudes")]
        public List<HvActitudesModel> Get()
        {
            HvActitudesLogic a = new HvActitudesLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Authorize]
        [Route("hvactitudescreate")]
        public IHttpActionResult Post(HvActitudesModel b)
        {
            HvActitudesLogic a = new HvActitudesLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }
    

        [HttpPut]
        [Authorize]
        [Route("hvactitudesupdate")]
        public IHttpActionResult Put(HvActitudesModel b)
        {
            HvActitudesLogic a = new HvActitudesLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.ID_DATOS_BASICOS.ToString())) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvactitudesdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            HvActitudesLogic a = new HvActitudesLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}