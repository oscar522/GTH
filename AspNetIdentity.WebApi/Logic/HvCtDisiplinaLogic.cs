using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtDisiplinaLogic
    {
        
        HV_CT_DISIPLINA ModCtx = new HV_CT_DISIPLINA();

        public HvCtDisiplinaModel Crear(HvCtDisiplinaModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_DISIPLINA Nuevo = new HV_CT_DISIPLINA
                {
                    ID_CT_DISIPLINA = a.ID_CT_DISIPLINA,
                    NOMBRE = a.NOMBRE,
                    DESCRIPCION = a.DESCRIPCION,
                    ESTADO = 1
                };
                Ctx.HV_CT_DISIPLINA.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtDisiplinaModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_DISIPLINA.Where(z => z.ESTADO == 1).Select(a => new HvCtDisiplinaModel
            {
                ID_CT_DISIPLINA = a.ID_CT_DISIPLINA,
                NOMBRE = a.NOMBRE,
                DESCRIPCION = a.DESCRIPCION,
            });
            return lista.ToList();
        }

        public HvCtDisiplinaModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_DISIPLINA a = Ctx.HV_CT_DISIPLINA.Where(w => w.ID_CT_DISIPLINA == id).Select(s => s).FirstOrDefault();
            HvCtDisiplinaModel b = new HvCtDisiplinaModel();
            b.ID_CT_DISIPLINA = a.ID_CT_DISIPLINA;
            b.NOMBRE = a.NOMBRE;
            b.DESCRIPCION = a.DESCRIPCION;
            return b;
        }

        public HvCtDisiplinaModel Actualizar(HvCtDisiplinaModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_DISIPLINA.Where(s => s.ID_CT_DISIPLINA == a.ID_CT_DISIPLINA).FirstOrDefault();
                if (ResCtx != null)
                {
                if (ResCtx != null)
                    ResCtx.ID_CT_DISIPLINA = a.ID_CT_DISIPLINA;
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_DISIPLINA.Where(s => s.ID_CT_DISIPLINA == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "realizado ";
        }
    }
}