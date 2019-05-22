using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AspNetIdentity.WebApi.Logic
{
    public class HvConocimientosLogic
    {
        

        public HvConocimientosModel Crear(HvConocimientosModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CONOCIMIENTOS Nuevo = new HV_CONOCIMIENTOS
                {
                    ID_CONOCIMIENTOS = a.ID_CONOCIMIENTOS,
                    ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ESTADO = 1
                };
                Ctx.HV_CONOCIMIENTOS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvConocimientosModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CONOCIMIENTOS
                .Join(Ctx.HV_CT_CONOCIMIENTOS, b => b.ID_CT_CONOCIMIENTOS, c => c.ID_CT_CONOCIMIENTOS, (b, c) =>
                 new { b.ESTADO, b.ID_CONOCIMIENTOS, b.ID_CT_CONOCIMIENTOS, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                 .Where(d => d.ESTADO == 1)
                .Select(a => new HvConocimientosModel
                {
                    ID_CONOCIMIENTOS = a.ID_CONOCIMIENTOS,
                    ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS.Value,
                    NOMBRE_CT_CONOCIMIENTOS =a.NombreCt,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                });

            return lista.ToList();
        }
        public List<HvConocimientosModel> ConsultarIdP(int IdP)
        {
            
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CONOCIMIENTOS
                .Join(Ctx.HV_CT_CONOCIMIENTOS, b => b.ID_CT_CONOCIMIENTOS, c => c.ID_CT_CONOCIMIENTOS, (b, c) =>
                 new { b.ESTADO, b.ID_CONOCIMIENTOS, b.ID_CT_CONOCIMIENTOS, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                 .Where(d => d.ESTADO == 1)
                 .Where(w => w.ID_DATOS_BASICOS == IdP)

                .Select(a => new HvConocimientosModel
                {
                    ID_CONOCIMIENTOS = a.ID_CONOCIMIENTOS,
                    ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS.Value,
                    NOMBRE_CT_CONOCIMIENTOS = a.NombreCt,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                });

            return lista.ToList();
        }
        public HvConocimientosModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var e = Ctx.HV_CONOCIMIENTOS
                .Join(Ctx.HV_CT_CONOCIMIENTOS, b => b.ID_CT_CONOCIMIENTOS, c => c.ID_CT_CONOCIMIENTOS, (b, c) =>
                 new { b.ESTADO, b.ID_CONOCIMIENTOS, b.ID_CT_CONOCIMIENTOS, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                 .Where(d => d.ESTADO == 1)
                .Where(w => w.ID_CONOCIMIENTOS == id).Select(s => s).FirstOrDefault();
            HvConocimientosModel a = new HvConocimientosModel();

            a.ID_CONOCIMIENTOS = e.ID_CONOCIMIENTOS;
            a.ID_CT_CONOCIMIENTOS = e.ID_CT_CONOCIMIENTOS.Value;
            a.NOMBRE_CT_CONOCIMIENTOS = e.NombreCt;
            a.ID_DATOS_BASICOS = e.ID_DATOS_BASICOS;
            return a;
        }

        public HvConocimientosModel Actualizar(HvConocimientosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CONOCIMIENTOS.Where(s => s.ID_CONOCIMIENTOS == a.ID_CONOCIMIENTOS).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CONOCIMIENTOS = a.ID_CONOCIMIENTOS;
                    ResCtx.ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS;
                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new HV_CONOCIMIENTOS();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.HV_CONOCIMIENTOS.Where(s => s.ID_CONOCIMIENTOS == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return ResCtx.ID_DATOS_BASICOS.ToString();
        }
    }
}