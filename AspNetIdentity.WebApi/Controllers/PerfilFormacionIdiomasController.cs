using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Logic;
using System.Collections.Generic;
using System.Web.Http;


namespace AspNetIdentity.WebApi.Controllers
{
    public class PerfilFormacionIdiomasController : ApiController
    {
        // GET api/values/5
        public PerfilFormacionIdiomasModel Get(int id)
        {
            PerfilFormacionIdiomasLogic a = new PerfilFormacionIdiomasLogic();
            return a.ConsultarId(id);
        }

        // GET api/values/
        public List<PerfilFormacionIdiomasModel> Get(string IdP)
        {
            PerfilFormacionIdiomasLogic a = new PerfilFormacionIdiomasLogic();
            var model = new List<PerfilFormacionIdiomasModel>();
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

        // POST api/values
        public PerfilFormacionIdiomasModel Post(PerfilFormacionIdiomasModel b)
        {
            PerfilFormacionIdiomasLogic a = new PerfilFormacionIdiomasLogic();
            return a.Crear(b);
        }

        // PUT api/values/5
        public PerfilFormacionIdiomasModel Put(PerfilFormacionIdiomasModel b)
        {
            PerfilFormacionIdiomasLogic a = new PerfilFormacionIdiomasLogic();
            return  a.Actualizar(b);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            PerfilFormacionIdiomasLogic a = new PerfilFormacionIdiomasLogic();
            a.Eliminar(id);
        }
    }
}
