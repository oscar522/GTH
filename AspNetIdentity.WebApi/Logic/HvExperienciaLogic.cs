using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvExperienciaLogic
    {
      
        HV_EXPERIENCIA ModCtx = new HV_EXPERIENCIA();

        public HvExperienciaModel Crear(HvExperienciaModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_EXPERIENCIA Nuevo = new HV_EXPERIENCIA
                {
                    ID_EXPERIENCIA = a.ID_EXPERIENCIA,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_EMPRESA = a.ID_CT_EMPRESA,
                    ID_CT_CARGO = a.ID_CT_CARGO,
                    DESDE = a.DESDE,
                    HASTA = a.HASTA,
                    TRABAJO_ACTUAL = a.TRABAJO_ACTUAL,
                    DESCRIPCION = a.DESCRIPCION,
                    ARCHIVO_RUTA = a.ARCHIVO_RUTA,
                    ESTADO = 1
                };
                Ctx.HV_EXPERIENCIA.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvExperienciaModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_EXPERIENCIA
                .Join(Ctx.HV_CT_EMPRESAS, b => b.ID_CT_EMPRESA, c => c.ID_CT_EMPRESA, (b, c) =>
                 new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, NOMBRE_EMPRESA = c.NOMBRE })
                 .Join(Ctx.HV_CT_CARGO, b => b.ID_CT_CARGO, c => c.ID_CT_CARGO, (b, c) =>
                 new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, b.NOMBRE_EMPRESA, NOMBRE_CARGO =c.NOMBRE })
                 .Where(x => x.ESTADO == 1)
                .Select(a => new HvExperienciaModel
            {
                ID_EXPERIENCIA = a.ID_EXPERIENCIA,
                ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                ID_CT_EMPRESA = a.ID_CT_EMPRESA,
                NOMBRE_EMPRESA = a.NOMBRE_EMPRESA,
                ID_CT_CARGO = a.ID_CT_CARGO,
                NOMBRE_CARGO = a.NOMBRE_CARGO,
                DESDE = a.DESDE,
                HASTA = a.HASTA,
                TRABAJO_ACTUAL = a.TRABAJO_ACTUAL,
                DESCRIPCION = a.DESCRIPCION,
                ARCHIVO_RUTA = a.ARCHIVO_RUTA,

            });

            return lista.ToList();
        }
        public List<HvExperienciaModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_EXPERIENCIA
                .Join(Ctx.HV_CT_EMPRESAS, b => b.ID_CT_EMPRESA, c => c.ID_CT_EMPRESA, (b, c) =>
                 new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, NOMBRE_EMPRESA = c.NOMBRE })
                 .Join(Ctx.HV_CT_CARGO, b => b.ID_CT_CARGO, c => c.ID_CT_CARGO, (b, c) =>
                 new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, b.NOMBRE_EMPRESA, NOMBRE_CARGO = c.NOMBRE })
                 .Where(x => x.ESTADO == 1)
                 .Where(w => w.ID_DATOS_BASICOS == Idpa)
                .Select(a => new HvExperienciaModel
                {
                    ID_EXPERIENCIA = a.ID_EXPERIENCIA,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_EMPRESA = a.ID_CT_EMPRESA,
                    NOMBRE_EMPRESA = a.NOMBRE_EMPRESA,
                    ID_CT_CARGO = a.ID_CT_CARGO,
                    NOMBRE_CARGO = a.NOMBRE_CARGO,
                    DESDE = a.DESDE,
                    HASTA = a.HASTA,
                    TRABAJO_ACTUAL = a.TRABAJO_ACTUAL,
                    DESCRIPCION = a.DESCRIPCION,
                    ARCHIVO_RUTA = a.ARCHIVO_RUTA,
                });

            return lista.ToList();
        }
        public HvExperienciaModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_EXPERIENCIA
            .Join(Ctx.HV_CT_EMPRESAS, b => b.ID_CT_EMPRESA, c => c.ID_CT_EMPRESA, (b, c) =>
            new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, NOMBRE_EMPRESA = c.NOMBRE })
            .Join(Ctx.HV_CT_CARGO, b => b.ID_CT_CARGO, c => c.ID_CT_CARGO, (b, c) =>
            new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, b.NOMBRE_EMPRESA, NOMBRE_CARGO = c.NOMBRE })
            .Where(x => x.ESTADO == 1)
            .Where(w => w.ID_EXPERIENCIA == id)
            .Select(s => s).FirstOrDefault();
            HvExperienciaModel d = new HvExperienciaModel();
            d.ID_EXPERIENCIA = a.ID_EXPERIENCIA;
            d.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
            d.ID_CT_EMPRESA = a.ID_CT_EMPRESA;
            d.NOMBRE_EMPRESA = a.NOMBRE_EMPRESA;
            d.ID_CT_CARGO = a.ID_CT_CARGO;
            d.NOMBRE_CARGO = a.NOMBRE_CARGO;
            d.DESDE = a.DESDE;
            d.HASTA = a.HASTA;
            d.TRABAJO_ACTUAL = a.TRABAJO_ACTUAL;
            d.DESCRIPCION = a.DESCRIPCION;
            d.ARCHIVO_RUTA = a.ARCHIVO_RUTA;
            return d;
        }

        public List<HvExperienciaModel> ConsultarIdD(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_EXPERIENCIA
            .Join(Ctx.HV_CT_EMPRESAS, b => b.ID_CT_EMPRESA, c => c.ID_CT_EMPRESA, (b, c) =>
            new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, NOMBRE_EMPRESA = c.NOMBRE })
            .Join(Ctx.HV_CT_CARGO, b => b.ID_CT_CARGO, c => c.ID_CT_CARGO, (b, c) =>
            new { b.ESTADO, b.ID_EXPERIENCIA, b.ID_DATOS_BASICOS, b.ID_CT_EMPRESA, b.ID_CT_CARGO, b.DESDE, b.HASTA, b.TRABAJO_ACTUAL, b.DESCRIPCION, b.ARCHIVO_RUTA, b.NOMBRE_EMPRESA, NOMBRE_CARGO = c.NOMBRE })
            .Where(x => x.ESTADO == 1)
            .Where(w => w.ID_DATOS_BASICOS == id)
            .Select(a => new HvExperienciaModel
            {
            ID_EXPERIENCIA = a.ID_EXPERIENCIA,
            ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
            ID_CT_EMPRESA = a.ID_CT_EMPRESA,
            NOMBRE_EMPRESA = a.NOMBRE_EMPRESA,
            ID_CT_CARGO = a.ID_CT_CARGO,
            NOMBRE_CARGO = a.NOMBRE_CARGO,
            DESDE = a.DESDE,
            HASTA = a.HASTA,
            TRABAJO_ACTUAL = a.TRABAJO_ACTUAL,
            DESCRIPCION = a.DESCRIPCION,
            ARCHIVO_RUTA = a.ARCHIVO_RUTA
            });
            return lista.ToList();
        }

        public HvExperienciaModel Actualizar(HvExperienciaModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_EXPERIENCIA.Where(s => s.ID_EXPERIENCIA == a.ID_EXPERIENCIA).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_EXPERIENCIA = a.ID_EXPERIENCIA;
                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    ResCtx.ID_CT_EMPRESA = a.ID_CT_EMPRESA;
                    ResCtx.ID_CT_CARGO = a.ID_CT_CARGO;
                    ResCtx.DESDE = a.DESDE;
                    ResCtx.HASTA = a.HASTA;
                    ResCtx.TRABAJO_ACTUAL = a.TRABAJO_ACTUAL;
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    ResCtx.ARCHIVO_RUTA = a.ARCHIVO_RUTA;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new HV_EXPERIENCIA();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.HV_EXPERIENCIA.Where(s => s.ID_EXPERIENCIA == id).FirstOrDefault();
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