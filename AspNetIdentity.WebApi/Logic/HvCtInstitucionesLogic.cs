using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtInstitucionesLogic
    {
        HV_CT_INSTITUCION ModCtx = new HV_CT_INSTITUCION();

        public HvCtInstitucionesModel Crear(HvCtInstitucionesModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_INSTITUCION Nuevo = new HV_CT_INSTITUCION
                {
                    ID_CT_INSTITUCION = a.ID_CT_INSTITUCION,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    NOMBRE = a.NOMBRE,
                    TIPO = a.TIPO,
                    ESTADO = 1
                };
                Ctx.HV_CT_INSTITUCION.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtInstitucionesModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_INSTITUCION
               .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_INSTITUCION, b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE })

                .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_INSTITUCION, b.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, b.NOMBRE, NombreDepto = c.NOMBRE, b.NombrePais })

                .Join(Ctx.HV_CT_CIUDAD, b => b.ID_CT_CIUDAD, c => c.ID_CT_CIUDAD, (b, c) =>
                new { b.ESTADO, b.TIPO, b.ID_CT_INSTITUCION, b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, b.NombreDepto, b.NombrePais, NombreCiudad = c.NOMBRE })
                .Where(j => j.ESTADO == 1)

                .Select(a => new HvCtInstitucionesModel
                {
                    ID_CT_INSTITUCION = a.ID_CT_INSTITUCION,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    NOMBRE_PAIS = a.NombrePais,
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    NOMBRE_DEPTO = a.NombreDepto, 
                    ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    NOMBRE_CIUDAD = a.NombreCiudad,
                    NOMBRE = a.NOMBRE,
                    TIPO = a.TIPO,
                });
            return lista.ToList();
        }

        public HvCtInstitucionesModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_CT_INSTITUCION
                 .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_INSTITUCION, b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE })

                .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_INSTITUCION, b.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, b.NOMBRE, NombreDepto = c.NOMBRE, b.NombrePais })

                .Join(Ctx.HV_CT_CIUDAD, b => b.ID_CT_CIUDAD, c => c.ID_CT_CIUDAD, (b, c) =>
                new { b.ESTADO, b.TIPO, b.ID_CT_INSTITUCION, b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, b.NombreDepto, b.NombrePais, NombreCiudad = c.NOMBRE })
                .Where(j => j.ESTADO == 1)

                .Where(w => w.ID_CT_INSTITUCION == id).Select(s => s).FirstOrDefault();
            HvCtInstitucionesModel x = new HvCtInstitucionesModel();
            x.ID_CT_INSTITUCION = a.ID_CT_INSTITUCION;
            x.ID_CT_PAIS = a.ID_CT_PAIS;
            x.NOMBRE_PAIS = a.NombrePais;
            x.ID_CT_DEPTO = a.ID_CT_DEPTO;
            x.NOMBRE_DEPTO = a.NombreDepto;
            x.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
            x.NOMBRE_CIUDAD = a.NombreCiudad;
            x.NOMBRE = a.NOMBRE;
            x.TIPO = a.TIPO;
            return x;
        }

        public HvCtInstitucionesModel Actualizar(HvCtInstitucionesModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_INSTITUCION.Where(s => s.ID_CT_INSTITUCION == a.ID_CT_INSTITUCION).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_INSTITUCION = a.ID_CT_INSTITUCION;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.TIPO = a.TIPO;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_INSTITUCION.Where(s => s.ID_CT_INSTITUCION == id).FirstOrDefault();
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