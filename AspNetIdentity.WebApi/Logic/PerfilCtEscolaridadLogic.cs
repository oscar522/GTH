using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtEscolaridadLogic
    {
 

        PERFIL_CT_ESCOLARIDAD ModCtx = new PERFIL_CT_ESCOLARIDAD();

        public PerfilCtEscolaridadModel Crear(PerfilCtEscolaridadModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_ESCOLARIDAD Nuevo = new PERFIL_CT_ESCOLARIDAD
                {
                    ID_ESCOLARIDAD = a.ID_ESCOLARIDAD,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                Ctx.PERFIL_CT_ESCOLARIDAD.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtEscolaridadModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_ESCOLARIDAD.Where(e => e.ESTADO == 1).Select(a => new PerfilCtEscolaridadModel
            {
                ID_ESCOLARIDAD = a.ID_ESCOLARIDAD,
                NOMBRE = a.NOMBRE,
            });

            return lista.ToList();
        }

        public PerfilCtEscolaridadModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_CT_ESCOLARIDAD a = Ctx.PERFIL_CT_ESCOLARIDAD.Where(w => w.ID_ESCOLARIDAD == id).Select(s => s).FirstOrDefault();
            PerfilCtEscolaridadModel res = new PerfilCtEscolaridadModel();

            res.ID_ESCOLARIDAD = a.ID_ESCOLARIDAD;
            res.NOMBRE = a.NOMBRE;
            return res;
        }

        public PerfilCtEscolaridadModel Actualizar(PerfilCtEscolaridadModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_ESCOLARIDAD.Where(s => s.ID_ESCOLARIDAD == a.ID_ESCOLARIDAD).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_ESCOLARIDAD = a.ID_ESCOLARIDAD;
                    ResCtx.NOMBRE = a.NOMBRE;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_ESCOLARIDAD.Where(s => s.ID_ESCOLARIDAD == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "realizado ";
        }
    }
}