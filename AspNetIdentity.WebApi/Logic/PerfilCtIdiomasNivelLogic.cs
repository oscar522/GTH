using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtIdiomasNivelLogic
    {
       
        PERFIL_CT_IDIOM_NIVEL ModCtx = new PERFIL_CT_IDIOM_NIVEL();

        public PerfilCtIdiomasNivelModel Crear(PerfilCtIdiomasNivelModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_IDIOM_NIVEL Nuevo = new PERFIL_CT_IDIOM_NIVEL
                {
                    ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                Ctx.PERFIL_CT_IDIOM_NIVEL.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtIdiomasNivelModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_IDIOM_NIVEL.Where(e => e.ESTADO == 1).Select(a => new PerfilCtIdiomasNivelModel
            {
                ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL,
                NOMBRE = a.NOMBRE,
            });

            return lista.ToList();
        }

        public PerfilCtIdiomasNivelModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_CT_IDIOM_NIVEL a = Ctx.PERFIL_CT_IDIOM_NIVEL.Where(w => w.ID_IDIOM_NIVEL == id).Select(s => s).FirstOrDefault();
            PerfilCtIdiomasNivelModel res = new PerfilCtIdiomasNivelModel();
            res.ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL;
            res.NOMBRE = a.NOMBRE;
           
            return res;
        }

        public PerfilCtIdiomasNivelModel Actualizar(PerfilCtIdiomasNivelModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_IDIOM_NIVEL.Where(s => s.ID_IDIOM_NIVEL == a.ID_IDIOM_NIVEL).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL;
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
                var ResCtx = Ctx.PERFIL_CT_IDIOM_NIVEL.Where(s => s.ID_IDIOM_NIVEL == id).FirstOrDefault();
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