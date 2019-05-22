using AspNetIdentity.Models;
using System.Collections.Generic;
using System.Web.Http;
using AspNetIdentity.WebApi.Logic;


namespace AspNetIdentity.WebApi.Controllers
{
    public class PerfilCompetenciasController : ApiController
    {
        // GET api/values/5
        public PerfilCompetenciasModel Get(int id)
        {
            PerfilCompetenciasLogic a = new PerfilCompetenciasLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        public List<PerfilCompetenciasModel> Get()
        {
           PerfilCompetenciasLogic a = new PerfilCompetenciasLogic();
            return a.Consulta();
        }

        // POST api/values
        public void Post(PerfilCompetenciasModel b)
        {
           PerfilCompetenciasLogic a = new PerfilCompetenciasLogic();
            a.Crear(b);
        }

        // PUT api/values/5
        public void Put(PerfilCompetenciasModel b)
        {
           PerfilCompetenciasLogic a = new PerfilCompetenciasLogic();
            a.Actualizar(b);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
           PerfilCompetenciasLogic a = new PerfilCompetenciasLogic();
            a.Eliminar(id);
        }
    }
}
