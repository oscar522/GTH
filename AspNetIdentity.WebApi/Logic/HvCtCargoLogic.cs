using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtCargoLogic
    {
        HV_CT_CARGO ModCtx = new HV_CT_CARGO();
        public HvCtCargoModel Crear(HvCtCargoModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_CARGO Nuevo = new HV_CT_CARGO
                {
                    ID_CT_CARGO = a.ID_CT_CARGO,
                    NOMBRE = a.NOMBRE,
                    DESCRIPCION = a.DESCRIPCION,
                };
                Nuevo.ESTADO = 1;
                Ctx.HV_CT_CARGO.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtCargoModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
             HvCtCargoModel b = new HvCtCargoModel();
            var lista = Ctx.HV_CT_CARGO.Where(x => x.ESTADO == 1 ).Select(a => new HvCtCargoModel
            {
                ID_CT_CARGO = a.ID_CT_CARGO,
                NOMBRE = a.NOMBRE,
                DESCRIPCION = a.DESCRIPCION,
            });

            return lista.ToList();
        }

        public HvCtCargoModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_CARGO a = Ctx.HV_CT_CARGO.Where(w => w.ID_CT_CARGO == id).Select(s => s).FirstOrDefault();
            HvCtCargoModel b = new HvCtCargoModel();
            b.ID_CT_CARGO = a.ID_CT_CARGO;
            b.NOMBRE = a.NOMBRE;
            b.DESCRIPCION = a.DESCRIPCION;
            return b;
        }

        public HvCtCargoModel Actualizar(HvCtCargoModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_CARGO.Where(s => s.ID_CT_CARGO == a.ID_CT_CARGO).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_CARGO = a.ID_CT_CARGO;
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
                var ResCtx = Ctx.HV_CT_CARGO.Where(s => s.ID_CT_CARGO == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}