using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtTitulosLogic
    {
        
        HV_CT_TITULOS ModCtx = new HV_CT_TITULOS();

        public HvCtTitulosModel Crear(HvCtTitulosModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_TITULOS Nuevo = new HV_CT_TITULOS
                {
                    ID_CT_TITULOS = a.ID_CT_TITULOS,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    ID_CT_DEPTO  = a.ID_CT_DEPTO,
                    ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    NOMBRE = a.NOMBRE,
                    TIPO = a.TIPO,
                    ESTADO = 1
                };
                Ctx.HV_CT_TITULOS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtTitulosModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_TITULOS
                 .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_TITULOS, b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE, })

                .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.ESTADO,c.TIPO, c.ID_CT_TITULOS, c.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE, c.NombrePais, NombreDepto = d.NOMBRE })

                .Join(Ctx.HV_CT_CIUDAD, b => b.ID_CT_CIUDAD, c => c.ID_CT_CIUDAD, (c, d) =>
                new {c.ESTADO, c.TIPO, c.ID_CT_TITULOS, c.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE, c.NombrePais, c.NombreDepto, NombreCiudad = d.NOMBRE })
                .Where(a => a.ESTADO == 1)
                .Select(a => new HvCtTitulosModel
            {
                ID_CT_TITULOS = a.ID_CT_TITULOS,
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

        public HvCtTitulosModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_CT_TITULOS
                    .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                     new { b.ESTADO, b.TIPO, b.ID_CT_TITULOS, b.ID_CT_CIUDAD, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE, })
                    .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                     new { c.ESTADO, c.TIPO, c.ID_CT_TITULOS, c.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE, c.NombrePais, NombreDepto = d.NOMBRE })
                    .Join(Ctx.HV_CT_CIUDAD, b => b.ID_CT_CIUDAD, c => c.ID_CT_CIUDAD, (c, d) =>
                     new { c.ESTADO, c.TIPO, c.ID_CT_TITULOS, c.ID_CT_CIUDAD, c.ID_CT_DEPTO, c.ID_CT_PAIS, c.NOMBRE, c.NombrePais, c.NombreDepto, NombreCiudad = d.NOMBRE })
                    .Where(x => x.ESTADO == 1)
                    .Where(w => w.ID_CT_TITULOS == id).Select(s => s).FirstOrDefault();

            HvCtTitulosModel e = new HvCtTitulosModel();
            e.ID_CT_TITULOS = a.ID_CT_TITULOS;
            e.ID_CT_PAIS = a.ID_CT_PAIS;
            e.NOMBRE_PAIS = a.NombrePais;
            e.ID_CT_DEPTO = a.ID_CT_DEPTO;
            e.NOMBRE_DEPTO = a.NombreDepto;
            e.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
            e.NOMBRE_CIUDAD = a.NombreCiudad;
            e.NOMBRE = a.NOMBRE;
            e.TIPO = a.TIPO;
            return e;
        }

        public HvCtTitulosModel Actualizar(HvCtTitulosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_TITULOS.Where(s => s.ID_CT_TITULOS == a.ID_CT_TITULOS).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_TITULOS = a.ID_CT_TITULOS;
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
                var ResCtx = Ctx.HV_CT_TITULOS.Where(s => s.ID_CT_TITULOS == id).FirstOrDefault();
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
