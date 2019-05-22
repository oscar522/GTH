using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    public class PerfilConocimientoController : ApiController
    {
        // GET api/values/5
        public PerfilConocimientoModel Get(int id)
        {
            PerfilConocimientoLogic a = new PerfilConocimientoLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        public List<PerfilConocimientoModel> Get()
        {
            PerfilConocimientoLogic a = new PerfilConocimientoLogic();
            return a.Consulta();
        }

        // POST api/values
        public void Post(PerfilConocimientoModel b)
        {
            PerfilConocimientoLogic a = new PerfilConocimientoLogic();
            a.Crear(b);
        }

        // PUT api/values/5
        public void Put(PerfilConocimientoModel b)
        {
            PerfilConocimientoLogic a = new PerfilConocimientoLogic();
            a.Actualizar(b);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            PerfilConocimientoLogic a = new PerfilConocimientoLogic();
            a.Eliminar(id);
        }
    }
}
