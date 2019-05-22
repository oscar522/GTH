using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvUbicacionLogic
    {
     
        HV_UBICACION ModCtx = new HV_UBICACION();

        public HvUbicacionModel Crear(HvUbicacionModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {   
                HV_UBICACION Nuevo = new HV_UBICACION
                {
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    ID_HV_HUBICACION = a.ID_HV_HUBICACION,
                    NOMENCLATURA = a.NOMENCLATURA,
                    LOCALIDAD = a.LOCALIDAD,
                    ESTADO = 1
                };

                Ctx.HV_UBICACION.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvUbicacionModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_UBICACION
                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.NOMENCLATURA, b.LOCALIDAD, b.ESTADO, b.ID_DATOS_BASICOS, b.ID_HV_HUBICACION, b.ID_CT_PAIS, b.ID_CT_DEPTO, b.ID_CT_CIUDAD,  NombrePais = c.NOMBRE })

                .Join(Ctx.HV_CT_DEPTO, d => d.ID_CT_DEPTO, e => e.ID_CT_DEPTO, (d, e) =>
                 new { d.NOMENCLATURA, d.LOCALIDAD, d.ESTADO,d.ID_DATOS_BASICOS, d.ID_HV_HUBICACION, d.ID_CT_PAIS, d.ID_CT_DEPTO, d.ID_CT_CIUDAD,  NombreDepto = e.NOMBRE, d.NombrePais })

                .Join(Ctx.HV_CT_CIUDAD, f => f.ID_CT_CIUDAD, g => g.ID_CT_CIUDAD, (f, g) =>
                new { f.NOMENCLATURA, f.LOCALIDAD, f.ESTADO, f.ID_DATOS_BASICOS, f.ID_HV_HUBICACION, f.ID_CT_PAIS, f.ID_CT_DEPTO, f.ID_CT_CIUDAD,   NombreCiudad = g.NOMBRE, f.NombrePais, f.NombreDepto })
                .Where(C => C.ESTADO == 1)
                .Select(a => new HvUbicacionModel
            {
                ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                ID_CT_PAIS = a.ID_CT_PAIS.Value,
                NOMBRE_PAIS = a.NombrePais,
                ID_CT_DEPTO = a.ID_CT_DEPTO.Value,
                NOMBRE_DEPTO = a.NombreDepto,
                ID_CT_CIUDAD = a.ID_CT_CIUDAD.Value,
                NOMBRE_CIUDAD = a.NombreCiudad,
                ID_HV_HUBICACION = a.ID_HV_HUBICACION,
                NOMENCLATURA = a.NOMENCLATURA,
                LOCALIDAD = a.LOCALIDAD,

            });

            return lista.ToList();
        }
        public List<HvUbicacionModel> ConsultarIdD(int IdP)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_UBICACION
                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.NOMENCLATURA, b.LOCALIDAD, b.ESTADO, b.ID_DATOS_BASICOS, b.ID_HV_HUBICACION, b.ID_CT_PAIS, b.ID_CT_DEPTO, b.ID_CT_CIUDAD, NombrePais = c.NOMBRE })
                .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.NOMENCLATURA, c.LOCALIDAD, c.ESTADO, c.ID_DATOS_BASICOS, c.ID_HV_HUBICACION, c.ID_CT_PAIS, c.ID_CT_DEPTO, c.ID_CT_CIUDAD, NombreDepto = d.NOMBRE, c.NombrePais })
                .Join(Ctx.HV_CT_CIUDAD, b => b.ID_CT_CIUDAD, c => c.ID_CT_CIUDAD, (c, d) =>
                new { c.NOMENCLATURA, c.LOCALIDAD, c.ESTADO, c.ID_DATOS_BASICOS, c.ID_HV_HUBICACION, c.ID_CT_PAIS, c.ID_CT_DEPTO, c.ID_CT_CIUDAD, NombreCiudad = d.NOMBRE, c.NombrePais, c.NombreDepto })
                .Where(C => C.ESTADO == 1)
                .Where(w => w.ID_DATOS_BASICOS == IdP)
                .Select(a => new HvUbicacionModel
                {
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_PAIS = a.ID_CT_PAIS.Value,
                    NOMBRE_PAIS = a.NombrePais,
                    ID_CT_DEPTO = a.ID_CT_DEPTO.Value,
                    NOMBRE_DEPTO = a.NombreDepto,
                    ID_CT_CIUDAD = a.ID_CT_CIUDAD.Value,
                    NOMBRE_CIUDAD = a.NombreCiudad,
                    ID_HV_HUBICACION = a.ID_HV_HUBICACION,
                    NOMENCLATURA = a.NOMENCLATURA,
                    LOCALIDAD = a.LOCALIDAD,
                });

            return lista.ToList();
        }
        public HvUbicacionModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_UBICACION
                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.NOMENCLATURA, b.LOCALIDAD, b.ESTADO, b.ID_DATOS_BASICOS, b.ID_HV_HUBICACION, b.ID_CT_PAIS, b.ID_CT_DEPTO, b.ID_CT_CIUDAD, NombrePais = c.NOMBRE })
                .Join(Ctx.HV_CT_DEPTO, b => b.ID_CT_DEPTO, c => c.ID_CT_DEPTO, (c, d) =>
                 new { c.NOMENCLATURA, c.LOCALIDAD, c.ESTADO, c.ID_DATOS_BASICOS, c.ID_HV_HUBICACION, c.ID_CT_PAIS, c.ID_CT_DEPTO, c.ID_CT_CIUDAD, NombreDepto = d.NOMBRE, c.NombrePais })
                .Join(Ctx.HV_CT_CIUDAD, b => b.ID_CT_CIUDAD, c => c.ID_CT_CIUDAD, (c, d) =>
                new { c.NOMENCLATURA, c.LOCALIDAD, c.ESTADO, c.ID_DATOS_BASICOS, c.ID_HV_HUBICACION, c.ID_CT_PAIS, c.ID_CT_DEPTO, c.ID_CT_CIUDAD, NombreCiudad = d.NOMBRE, c.NombrePais, c.NombreDepto })
                .Where(C => C.ESTADO == 1)
                .Where(w => w.ID_HV_HUBICACION == id).Select(s => s).FirstOrDefault();
                HvUbicacionModel e = new HvUbicacionModel();
                e.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                e.ID_CT_PAIS = a.ID_CT_PAIS.Value;
                e.NOMBRE_PAIS = a.NombrePais;
                e.ID_CT_DEPTO = a.ID_CT_DEPTO.Value;
                e.NOMBRE_DEPTO = a.NombreDepto;
                e.ID_CT_CIUDAD = a.ID_CT_CIUDAD.Value;
                e.NOMBRE_CIUDAD = a.NombreCiudad;
                e.ID_HV_HUBICACION = a.ID_HV_HUBICACION;
                e.NOMENCLATURA = a.NOMENCLATURA;
                e.LOCALIDAD = a.LOCALIDAD;
                return e;
        }

        public HvUbicacionModel Actualizar(HvUbicacionModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_UBICACION.Where(s => s.ID_HV_HUBICACION == a.ID_HV_HUBICACION).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
                    ResCtx.ID_HV_HUBICACION = a.ID_HV_HUBICACION;
                    ResCtx.NOMENCLATURA = a.NOMENCLATURA;
                    ResCtx.LOCALIDAD = a.LOCALIDAD;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new HV_UBICACION();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.HV_UBICACION.Where(s => s.ID_HV_HUBICACION == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return ResCtx.ID_DATOS_BASICOS.ToString();
        }
    }
}