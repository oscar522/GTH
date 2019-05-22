using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;

namespace AspNetIdentity.WebApi.Controllers
{
    [RoutePrefix("api/hvdatosbasicos")]
    public class HvDatosBasicosController : ApiController
    {
        [Authorize]
        [Route("gethvdatosbasicosid/{id}")]
        public HvDatosBasicosModel Get(int id)
        {
            HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            return a.ConsultarId(id);
        }

        [Authorize]
        [Route("gethvdatosbasicosidpersona/{id}")]
        public HvDatosBasicosModel GetPersona(int id)
        {
            HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            return a.ConsultarIdPersona(id);
        }

        //[Authorize]
        //[Route("gethvdatosbasicos")]
        //public List<HvDatosBasicosModel> Get()
        //{
        //     HvDatosBasicosLogic a = new HvDatosBasicosLogic();
        //    return a.Consulta();
        //}

        [Authorize]
        [Route("gethvdatosbasicos")]
        public List<UserDataModel> Get()
        {
            HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            return a.Consulta2();
        }

        [HttpPost]
        [Authorize]
        [Route("hvdatosbasicoscreate")]
        public IHttpActionResult Post(HvDatosBasicosModel b)
        {
            HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.APELLIDOS)) return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Authorize]
        [Route("hvdatosbasicosupdate")]
        public IHttpActionResult Put(HvDatosBasicosModel b)
        {
             HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.APELLIDOS)) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        [Route("hvdatosbasicosupdatepersona")]
        public IHttpActionResult PutPersona(HvDatosBasicosModel b)
        {
            HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            var result = a.ActualizarPersona(b);
            if (!string.IsNullOrEmpty(result.APELLIDOS)) return Ok(result);
            return NotFound();
        }

        [Authorize]
        [Route("gethvdatosbasicosdelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
             HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
        [Authorize]
        [Route("gethvdatosbasicosdeletepersona/{id}")]
        [HttpDelete]
        public string DeletePersona(int id)
        {
            HvDatosBasicosLogic a = new HvDatosBasicosLogic();
            string resul = a.EliminarPersona(id);
            return resul;
        }
    }
}