using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtEmpresaLogic
    {
        HV_CT_EMPRESAS ModCtx = new HV_CT_EMPRESAS();
        public HvCtEmpresaModel Crear(HvCtEmpresaModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_EMPRESAS Nuevo = new HV_CT_EMPRESAS
                {
                    ID_CT_EMPRESA = a.ID_CT_EMPRESA,
                    NOMBRE = a.NOMBRE,
                    PAIS = a.PAIS,
                    DEPTO = a.DEPTO,
                    CIUDAD = a.CIUDAD,
                    TIPO = a.TIPO,
                    ESTADO = 1
                };
                Ctx.HV_CT_EMPRESAS.Add(Nuevo);
                Ctx.SaveChanges();
                a.ID_CT_EMPRESA = Nuevo.ID_CT_EMPRESA;
                return a;
            }
        }
        public List<HvCtEmpresaModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_EMPRESAS
                .Join(Ctx.HV_CT_PAIS, b => b.PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_EMPRESA, b.CIUDAD, b.DEPTO, b.PAIS, b.NOMBRE, NombrePais = c.NOMBRE })
                .Join(Ctx.HV_CT_DEPTO, b => b.DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.ESTADO, c.TIPO, c.ID_CT_EMPRESA, c.CIUDAD, c.DEPTO, c.PAIS, c.NOMBRE, NombreDepto = d.NOMBRE, c.NombrePais })
                .Join(Ctx.HV_CT_CIUDAD, b => b.CIUDAD, c => c.ID_CT_CIUDAD, (c, d) =>
                new { c.ESTADO, c.TIPO, c.ID_CT_EMPRESA, c.CIUDAD, c.DEPTO, c.PAIS, c.NOMBRE, NombreCiudad = d.NOMBRE, c.NombrePais, c.NombreDepto  })
                .Where(C => C.ESTADO == 1)
                .Select(a => new HvCtEmpresaModel
                {
                    ID_CT_EMPRESA = a.ID_CT_EMPRESA,
                    NOMBRE = a.NOMBRE,
                    PAIS = a.PAIS,
                    NOMBRE_PAIS = a.NombreCiudad,
                    DEPTO = a.DEPTO,
                    NOMBRE_DEPTO = a.NombreDepto,
                    CIUDAD = a.CIUDAD,
                    NOMBRE_CIUDAD = a.NombreCiudad,
                    TIPO = a.TIPO,
                });
            return lista.ToList();
        }
        public HvCtEmpresaModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_CT_EMPRESAS.Join(Ctx.HV_CT_PAIS, b => b.PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.TIPO, b.ID_CT_EMPRESA, b.CIUDAD, b.DEPTO, b.PAIS, b.NOMBRE, NombrePais = c.NOMBRE })
                .Join(Ctx.HV_CT_DEPTO, b => b.DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.ESTADO, c.TIPO, c.ID_CT_EMPRESA, c.CIUDAD, c.DEPTO, c.PAIS, c.NOMBRE, NombreDepto = d.NOMBRE, c.NombrePais })
                .Join(Ctx.HV_CT_CIUDAD, b => b.CIUDAD, c => c.ID_CT_CIUDAD, (c, d) =>
                new { c.ESTADO, c.TIPO, c.ID_CT_EMPRESA, c.CIUDAD, c.DEPTO, c.PAIS, c.NOMBRE, NombreCiudad = d.NOMBRE, c.NombrePais, c.NombreDepto })
                .Where(C => C.ESTADO == 1)
                .Where(w => w.ID_CT_EMPRESA == id).Select(s => s).FirstOrDefault();
            HvCtEmpresaModel x = new HvCtEmpresaModel();
            x.ID_CT_EMPRESA = a.ID_CT_EMPRESA;
            x.NOMBRE = a.NOMBRE;
            x.PAIS = a.PAIS;
            x.NOMBRE_PAIS = a.NombrePais;
            x.DEPTO = a.DEPTO;
            x.NOMBRE_DEPTO = a.NombreDepto;
            x.CIUDAD = a.CIUDAD;
            x.NOMBRE_CIUDAD = a.NombreCiudad;
            x.TIPO = a.TIPO;
            return x;
        }

        public HvCtEmpresaModel Actualizar(HvCtEmpresaModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_EMPRESAS.Where(s => s.ID_CT_EMPRESA == a.ID_CT_EMPRESA).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_EMPRESA = a.ID_CT_EMPRESA;
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.PAIS = a.PAIS;
                    ResCtx.DEPTO = a.DEPTO;
                    ResCtx.CIUDAD = a.CIUDAD;
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
                var ResCtx = Ctx.HV_CT_EMPRESAS.Where(s => s.ID_CT_EMPRESA == id).FirstOrDefault();
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