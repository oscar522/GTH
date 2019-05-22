using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtTipoIdentificacionLogic
    {
       
        HV_CT_TIPO_IDENTIFICACION ModCtx = new HV_CT_TIPO_IDENTIFICACION();

        public HvCtTipoIdentificacionModel Crear(HvCtTipoIdentificacionModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_TIPO_IDENTIFICACION Nuevo = new HV_CT_TIPO_IDENTIFICACION
                {
                    ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                Ctx.HV_CT_TIPO_IDENTIFICACION.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtTipoIdentificacionModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_TIPO_IDENTIFICACION.Where(e => e.ESTADO == 1).Select(a => new HvCtTipoIdentificacionModel
            {
                ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION,
                NOMBRE = a.NOMBRE
            });

            return lista.ToList();
        }

        public HvCtTipoIdentificacionModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_TIPO_IDENTIFICACION a = Ctx.HV_CT_TIPO_IDENTIFICACION.Where(w => w.ID_CT_TIPO_IDENTIFICACION == id).Select(s => s).FirstOrDefault();
            HvCtTipoIdentificacionModel b = new HvCtTipoIdentificacionModel();
            b.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
            b.NOMBRE = a.NOMBRE;
            return b;
        }

        public HvCtTipoIdentificacionModel Actualizar(HvCtTipoIdentificacionModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_TIPO_IDENTIFICACION.Where(s => s.ID_CT_TIPO_IDENTIFICACION == a.ID_CT_TIPO_IDENTIFICACION).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
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
                var ResCtx = Ctx.HV_CT_TIPO_IDENTIFICACION.Where(s => s.ID_CT_TIPO_IDENTIFICACION == id).FirstOrDefault();
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