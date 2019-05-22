using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtConocimientosLogic
    {
        
        HV_CT_CONOCIMIENTOS ModCtx = new HV_CT_CONOCIMIENTOS();

        public HvCtConocimientosModel Crear(HvCtConocimientosModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_CONOCIMIENTOS Nuevo = new HV_CT_CONOCIMIENTOS
                {

                   // ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS,
                    NOMBRE = a.NOMBRE,
                    CT_SECTOR = a.CT_SECTOR,
                    ESTADO = 1
                };
                Ctx.HV_CT_CONOCIMIENTOS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtConocimientosModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_CONOCIMIENTOS.Where(z => z.ESTADO == 1).Select(a => new HvCtConocimientosModel
            {
                ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS,
                NOMBRE = a.NOMBRE,
                CT_SECTOR = a.CT_SECTOR

            });

            return lista.ToList();
        }

        public HvCtConocimientosModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_CONOCIMIENTOS a = Ctx.HV_CT_CONOCIMIENTOS.Where(w => w.ID_CT_CONOCIMIENTOS == id).Select(s => s).FirstOrDefault();
            HvCtConocimientosModel b = new HvCtConocimientosModel();
            b.ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS;
            b.NOMBRE = a.NOMBRE;
            b.CT_SECTOR = a.CT_SECTOR;
            return b;
        }

        public HvCtConocimientosModel Actualizar(HvCtConocimientosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_CONOCIMIENTOS.Where(s => s.ID_CT_CONOCIMIENTOS == a.ID_CT_CONOCIMIENTOS).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_CONOCIMIENTOS = a.ID_CT_CONOCIMIENTOS;
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.CT_SECTOR = a.CT_SECTOR;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            { 
                var ResCtx = Ctx.HV_CT_CONOCIMIENTOS.Where(s => s.ID_CT_CONOCIMIENTOS == id).FirstOrDefault();
                if (ResCtx != null)
                    ResCtx.ESTADO = 0;
                Ctx.SaveChanges();
            }
            return "realizado ";
        }
    }
}