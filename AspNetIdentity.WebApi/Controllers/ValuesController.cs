using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Logic;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetIdentity.WebApi.Controllers
{
    public class ValuesController : BaseApiController
    {
        // GET api/values/5
        public PerfilModel Get(int id)
        {
            PerfilLogic a = new PerfilLogic();
            return a.ConsultarPerfilId(id);
        }

        // GET api/values/
        public List<PerfilModel> Get()
        {
            PerfilLogic a = new PerfilLogic();
            return a.ConsultaPerfil();
        }

        // POST api/values
        public void Post(PerfilModel perfil)
        {
            PerfilLogic a = new PerfilLogic();
            a.Crear(perfil);
        }

        // PUT api/values/5
        public void Put(PerfilModel perfil)
        {
            PerfilLogic a = new PerfilLogic();
            a.Actualizar(perfil);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            PerfilLogic a = new PerfilLogic();
            a.Eliminar(id);
        }
    }
}
