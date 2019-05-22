using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtCiudadLogic
    {
        HV_CT_CIUDAD ModCtx = new HV_CT_CIUDAD();

        public HvCtCiudadModel Crear(HvCtCiudadModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())// --------------------- //
            {
                HV_CT_CIUDAD Nuevo = new HV_CT_CIUDAD
                {
                   // ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1 // --------------------- //
                };
                Ctx.HV_CT_CIUDAD.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtCiudadModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            
            var lista = Ctx.HV_CT_CIUDAD
                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, b.ESTADO, NombrePais = c.NOMBRE})
                .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE, c.ESTADO, c.NombrePais, NombreDepto = d.NOMBRE })
                .Where(c => c.ESTADO == 1 ).Select(c => new HvCtCiudadModel
                {
                ID_CT_CIUDAD = c.ID_CT_CIUDAD,
                ID_CT_DEPTO = c.ID_CT_DEPTO,
                NOMBRE_DEPTO = c.NombreDepto,
                ID_CT_PAIS = c.ID_CT_PAIS,
                NOMBRE_PAIS = c.NombrePais,
                NOMBRE = c.NOMBRE,
                });

            return lista.ToList();
        }

        public List<HvCtCiudadModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_CIUDAD.Where(w => w.ID_CT_DEPTO == Idpa).Select(a => new HvCtCiudadModel //
            {
                ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                NOMBRE = a.NOMBRE
            });

            return lista.ToList();
        }

        public HvCtCiudadModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_CT_CIUDAD
                .Join(Ctx.HV_CT_PAIS, x => x.ID_CT_PAIS, c => c.ID_CT_PAIS, (x, c) =>
                 new { x.ID_CT_CIUDAD, x.ID_CT_DEPTO, x.ID_CT_PAIS, x.NOMBRE, x.ESTADO, NombrePais = c.NOMBRE })
                .Join(Ctx.HV_CT_DEPTO, x => x.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE, c.ESTADO, c.NombrePais, NombreDepto = d.NOMBRE })
                .Where(w => w.ID_CT_CIUDAD == id).Select(s => s).FirstOrDefault();
            HvCtCiudadModel b = new HvCtCiudadModel();

            b.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
            b.ID_CT_DEPTO = a.ID_CT_DEPTO;
            b.NOMBRE_DEPTO = a.NombreDepto;
            b.ID_CT_PAIS = a.ID_CT_PAIS;
            b.NOMBRE_PAIS = a.NombrePais;
            b.NOMBRE = a.NOMBRE;
            return b;
        }

        public HvCtCiudadModel Actualizar(HvCtCiudadModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_CIUDAD.Where(s => s.ID_CT_CIUDAD == a.ID_CT_CIUDAD).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;
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
                var ResCtx = Ctx.HV_CT_CIUDAD.Where(s => s.ID_CT_CIUDAD == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}