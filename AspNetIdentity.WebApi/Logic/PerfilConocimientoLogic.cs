using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilConocimientoLogic
    {

        PERFIL_CONOCIMIENTOS ModCtx = new PERFIL_CONOCIMIENTOS();

        public PerfilConocimientoModel Crear(PerfilConocimientoModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities ())
            {
                PERFIL_CONOCIMIENTOS Nuevo = new PERFIL_CONOCIMIENTOS
                {
                    ID_CONOCIMIENTO = a.ID_CONOCIMIENTO,
                    ID_PERFIL = a.ID_PERFIL,
                    NOMBRE = a.NOMBRE,
                    DESCRIPCION = a.DESCRIPCION,
                   
                };

                ModCtx = Ctx.PERFIL_CONOCIMIENTOS.GroupBy(r => r.ID_CONOCIMIENTO).OrderByDescending(g => g.Key).FirstOrDefault().First();
                if (ModCtx.ID_CONOCIMIENTO == 0)
                {
                    Nuevo.ID_CONOCIMIENTO = 1;
                }
                else
                {
                    Nuevo.ID_CONOCIMIENTO = ModCtx.ID_CONOCIMIENTO + 1;
                }
                Ctx.PERFIL_CONOCIMIENTOS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilConocimientoModel> Consulta()
        {
            AspNetIdentityEntities Ctx  = new AspNetIdentityEntities ();
            var lista = Ctx.PERFIL_CONOCIMIENTOS.Select(a => new PerfilConocimientoModel
            {
                ID_CONOCIMIENTO = a.ID_CONOCIMIENTO,
                ID_PERFIL = a.ID_PERFIL,
                NOMBRE = a.NOMBRE,
                DESCRIPCION = a.DESCRIPCION,
              

            });

            return lista.ToList();
        }

        public PerfilConocimientoModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx  = new AspNetIdentityEntities ();
            PERFIL_CONOCIMIENTOS a = Ctx.PERFIL_CONOCIMIENTOS.Where(w => w.ID_CONOCIMIENTO == id).Select(s => s).FirstOrDefault();
            PerfilConocimientoModel res = new PerfilConocimientoModel();
            res.ID_CONOCIMIENTO = a.ID_CONOCIMIENTO;
            res.ID_PERFIL = a.ID_PERFIL;
            res.NOMBRE = a.NOMBRE;
            res.DESCRIPCION = a.DESCRIPCION;
            
            return res;
        }

        public PerfilConocimientoModel Actualizar(PerfilConocimientoModel a)
        {
            using (var Ctx = new AspNetIdentityEntities ())
            {
                var ResCtx = Ctx.PERFIL_CONOCIMIENTOS.Where(s => s.ID_CONOCIMIENTO == a.ID_CONOCIMIENTO).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities ())
            {
                var ResCtx = Ctx.PERFIL_CONOCIMIENTOS.Where(s => s.ID_CONOCIMIENTO == id).FirstOrDefault();
                Ctx.PERFIL_CONOCIMIENTOS.Remove(ResCtx);
                Ctx.SaveChanges();
            }
            return "realizado ";
        }

    }
}