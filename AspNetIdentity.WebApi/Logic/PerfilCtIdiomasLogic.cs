using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtIdiomasLogic
    {


        PERFIL_CT_IDIOMAS ModCtx = new PERFIL_CT_IDIOMAS();

        public PerfilCtIdiomasModel Crear(PerfilCtIdiomasModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_IDIOMAS Nuevo = new PERFIL_CT_IDIOMAS
                {
                    ID_IDIOMA = a.ID_IDIOMA,
                    NOMBRE = a.NOMBRE,
                    
                    ESTADO = 1 // --------------------- //
                };
                Ctx.PERFIL_CT_IDIOMAS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtIdiomasModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_IDIOMAS
                .Where(e => e.ESTADO == 1).Select(a => new PerfilCtIdiomasModel
            {
                    ID_IDIOMA = a.ID_IDIOMA,
                    NOMBRE = a.NOMBRE,
                   
            });

            return lista.ToList();
        }

        public PerfilCtIdiomasModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.PERFIL_CT_IDIOMAS
                .Where(w => w.ID_IDIOMA == id).Select(s => s).FirstOrDefault();
            PerfilCtIdiomasModel res = new PerfilCtIdiomasModel();
            res.ID_IDIOMA = a.ID_IDIOMA;
            res.NOMBRE = a.NOMBRE;
            return res;
        }

        public PerfilCtIdiomasModel Actualizar(PerfilCtIdiomasModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_IDIOMAS.Where(s => s.ID_IDIOMA == a.ID_IDIOMA).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_IDIOMA = a.ID_IDIOMA;
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
                var ResCtx = Ctx.PERFIL_CT_IDIOMAS.Where(s => s.ID_IDIOMA == id).FirstOrDefault();
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