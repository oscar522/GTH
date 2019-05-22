using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtEstadoCivilLogic
    {
        
        HV_CT_ESTADO_CIVIL ModCtx = new HV_CT_ESTADO_CIVIL();

        public HvCtEstadoCivilModel Crear(HvCtEstadoCivilModel a)
        { 
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_ESTADO_CIVIL Nuevo = new HV_CT_ESTADO_CIVIL
                {
                    ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                Ctx.HV_CT_ESTADO_CIVIL.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtEstadoCivilModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_ESTADO_CIVIL.Where(x => x.ESTADO == 1).Select(a => new HvCtEstadoCivilModel
            {
                ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL,
                NOMBRE = a.NOMBRE
            });
            return lista.ToList();
        }

        public HvCtEstadoCivilModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_ESTADO_CIVIL a = Ctx.HV_CT_ESTADO_CIVIL.Where(w => w.ID_CT_ESTADO_CIVIL == id).Select(s => s).FirstOrDefault();
            HvCtEstadoCivilModel b = new HvCtEstadoCivilModel();
            b.ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL;
            b.NOMBRE = a.NOMBRE;
            return b;
        }

        public HvCtEstadoCivilModel Actualizar(HvCtEstadoCivilModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_ESTADO_CIVIL.Where(s => s.ID_CT_ESTADO_CIVIL == a.ID_CT_ESTADO_CIVIL).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL;
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
                var ResCtx = Ctx.HV_CT_ESTADO_CIVIL.Where(s => s.ID_CT_ESTADO_CIVIL == id).FirstOrDefault();
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