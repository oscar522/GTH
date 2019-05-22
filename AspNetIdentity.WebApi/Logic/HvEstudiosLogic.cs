using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvEstudiosLogic
    {
        HV_ESTUDIOS ModCtx = new HV_ESTUDIOS();

        public HvEstudiosModel Crear(HvEstudiosModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {   
                HV_ESTUDIOS Nuevo = new HV_ESTUDIOS
                {
                    ID_ESTUDIOS = a.ID_ESTUDIOS,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_INSTITUCION = a.ID_CT_INSTITUCION,
                    ID_CT_TITULOS = a.ID_CT_TITULOS,
                    ID_CT_DISIPLINA = a.ID_CT_DISIPLINA,
                    DESDE = a.DESDE,
                    HASTA = a.HASTA,
                    NOTA = a.NOTA,
                    DESCRIPCION = a.DESCRIPCION,
                    ARCHIVO_RUTA = a.ARCHIVO_RUTA,
                    ACTIVIDADES = a.ACTIVIDADES,
                    ESTADO = 1
                };
                Ctx.HV_ESTUDIOS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvEstudiosModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_ESTUDIOS
                .Join(Ctx.HV_CT_INSTITUCION, d => d.ID_CT_INSTITUCION, c => c.ID_CT_INSTITUCION, (d, c) =>
                 new {
                     d.ID_ESTUDIOS,
                     d.ID_DATOS_BASICOS,
                     d.ID_CT_INSTITUCION,
                     d.ID_CT_TITULOS,
                     d.ID_CT_DISIPLINA,
                     d.DESDE,
                     d.HASTA,
                     d.NOTA,
                     d.DESCRIPCION,
                     d.ARCHIVO_RUTA,
                     d.ACTIVIDADES,
                     d.ESTADO,
                     NomnreInstitucion = c.NOMBRE
                 })
                 .Join(Ctx.HV_CT_TITULOS, d => d.ID_CT_TITULOS, c => c.ID_CT_TITULOS, (d, c) =>
                 new {
                     d.ID_ESTUDIOS,
                     d.ID_DATOS_BASICOS,
                     d.ID_CT_INSTITUCION,
                     d.ID_CT_TITULOS,
                     d.ID_CT_DISIPLINA,
                     d.DESDE,
                     d.HASTA,
                     d.NOTA,
                     d.DESCRIPCION,
                     d.ARCHIVO_RUTA,
                     d.ACTIVIDADES,
                     d.ESTADO,
                     d.NomnreInstitucion,
                     NomnreTitulos = c.NOMBRE,
                 })
                 .Join(Ctx.HV_CT_DISIPLINA, d => d.ID_CT_DISIPLINA, c => c.ID_CT_DISIPLINA, (d, c) =>
                 new {
                     d.ID_ESTUDIOS,
                     d.ID_DATOS_BASICOS,
                     d.ID_CT_INSTITUCION,
                     d.ID_CT_TITULOS,
                     d.ID_CT_DISIPLINA,
                     d.DESDE,
                     d.HASTA,
                     d.NOTA,
                     d.DESCRIPCION,
                     d.ARCHIVO_RUTA,
                     d.ACTIVIDADES,
                     d.ESTADO,
                     d.NomnreInstitucion,
                     d.NomnreTitulos,
                     NomnreDisiplina = c.NOMBRE,
                 })
                 .Where(w => w.ESTADO == 1)
                .Select(a => new HvEstudiosModel
            {
                ID_ESTUDIOS = a.ID_ESTUDIOS,
                ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                ID_CT_INSTITUCION = a.ID_CT_INSTITUCION,
                ID_CT_TITULOS = a.ID_CT_TITULOS,
                ID_CT_DISIPLINA = a.ID_CT_DISIPLINA,
                DESDE = a.DESDE,
                HASTA = a.HASTA,
                NOTA = a.NOTA,
                DESCRIPCION = a.DESCRIPCION,
                ARCHIVO_RUTA = a.ARCHIVO_RUTA,
                ACTIVIDADES = a.ACTIVIDADES,
                NOMBRE_INSTITUCION = a.NomnreInstitucion,
                NOMBRE_DISIPLINA = a.NomnreDisiplina,
                NOMBRE_TITULO = a.NomnreTitulos,

        });

            return lista.ToList();
        }

        public HvEstudiosModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_ESTUDIOS
                .Join(Ctx.HV_CT_INSTITUCION, d => d.ID_CT_INSTITUCION, c => c.ID_CT_INSTITUCION, (d, c) =>
                new {d.ID_ESTUDIOS,d.ID_DATOS_BASICOS,d.ID_CT_INSTITUCION,d.ID_CT_TITULOS,d.ID_CT_DISIPLINA,d.DESDE,d.HASTA,d.NOTA,d.DESCRIPCION,d.ARCHIVO_RUTA,d.ACTIVIDADES,d.ESTADO,NomnreInstitucion = c.NOMBRE})
                .Join(Ctx.HV_CT_TITULOS, d => d.ID_CT_TITULOS, c => c.ID_CT_TITULOS, (d, c) =>
                new {d.ID_ESTUDIOS,d.ID_DATOS_BASICOS,d.ID_CT_INSTITUCION,d.ID_CT_TITULOS,d.ID_CT_DISIPLINA,d.DESDE,d.HASTA,d.NOTA,d.DESCRIPCION,d.ARCHIVO_RUTA,d.ACTIVIDADES,d.ESTADO,d.NomnreInstitucion,NomnreTitulos = c.NOMBRE})                 
                .Join(Ctx.HV_CT_DISIPLINA, d => d.ID_CT_DISIPLINA, c => c.ID_CT_DISIPLINA, (d, c) => 
                new {d.ID_ESTUDIOS,d.ID_DATOS_BASICOS,d.ID_CT_INSTITUCION,d.ID_CT_TITULOS,d.ID_CT_DISIPLINA,d.DESDE,d.HASTA,d.NOTA,d.DESCRIPCION,d.ARCHIVO_RUTA,d.ACTIVIDADES,d.ESTADO,d.NomnreInstitucion,d.NomnreTitulos,NomnreDisiplina = c.NOMBRE})                
                .Where(w => w.ID_ESTUDIOS == id)
                .Select(s => s).FirstOrDefault();
                HvEstudiosModel b = new HvEstudiosModel();
                b.ID_ESTUDIOS = a.ID_ESTUDIOS;
                b.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                b.ID_CT_INSTITUCION = a.ID_CT_INSTITUCION;
                b.ID_CT_TITULOS = a.ID_CT_TITULOS;
                b.ID_CT_DISIPLINA = a.ID_CT_DISIPLINA;
                b.DESDE = a.DESDE;
                b.HASTA = a.HASTA;
                b.NOTA = a.NOTA;
                b.DESCRIPCION = a.DESCRIPCION;
                b.ARCHIVO_RUTA = a.ARCHIVO_RUTA;
                b.ACTIVIDADES = a.ACTIVIDADES;
                b.NOMBRE_INSTITUCION = a.NomnreInstitucion;
                b.NOMBRE_DISIPLINA = a.NomnreDisiplina;
                b.NOMBRE_TITULO = a.NomnreTitulos;
            return b;
        }

        public List<HvEstudiosModel> ConsultarIdD(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_ESTUDIOS
                .Join(Ctx.HV_CT_INSTITUCION, d => d.ID_CT_INSTITUCION, c => c.ID_CT_INSTITUCION, (d, c) =>
                 new {
                     d.ID_ESTUDIOS,
                     d.ID_DATOS_BASICOS,
                     d.ID_CT_INSTITUCION,
                     d.ID_CT_TITULOS,
                     d.ID_CT_DISIPLINA,
                     d.DESDE,
                     d.HASTA,
                     d.NOTA,
                     d.DESCRIPCION,
                     d.ARCHIVO_RUTA,
                     d.ACTIVIDADES,
                     d.ESTADO,
                     NomnreInstitucion = c.NOMBRE
                 })
                 .Join(Ctx.HV_CT_TITULOS, d => d.ID_CT_TITULOS, c => c.ID_CT_TITULOS, (d, c) =>
                 new {
                     d.ID_ESTUDIOS,
                     d.ID_DATOS_BASICOS,
                     d.ID_CT_INSTITUCION,
                     d.ID_CT_TITULOS,
                     d.ID_CT_DISIPLINA,
                     d.DESDE,
                     d.HASTA,
                     d.NOTA,
                     d.DESCRIPCION,
                     d.ARCHIVO_RUTA,
                     d.ACTIVIDADES,
                     d.ESTADO,
                     d.NomnreInstitucion,
                     NomnreTitulos = c.NOMBRE,
                 })
                 .Join(Ctx.HV_CT_DISIPLINA, d => d.ID_CT_DISIPLINA, c => c.ID_CT_DISIPLINA, (d, c) =>
                 new {
                     d.ID_ESTUDIOS,
                     d.ID_DATOS_BASICOS,
                     d.ID_CT_INSTITUCION,
                     d.ID_CT_TITULOS,
                     d.ID_CT_DISIPLINA,
                     d.DESDE,
                     d.HASTA,
                     d.NOTA,
                     d.DESCRIPCION,
                     d.ARCHIVO_RUTA,
                     d.ACTIVIDADES,
                     d.ESTADO,
                     d.NomnreInstitucion,
                     d.NomnreTitulos,
                     NomnreDisiplina = c.NOMBRE,
                 })
                .Where(w => w.ID_DATOS_BASICOS == id)
                .Select(a => new HvEstudiosModel {
                    ID_ESTUDIOS = a.ID_ESTUDIOS,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_INSTITUCION = a.ID_CT_INSTITUCION,
                    ID_CT_TITULOS = a.ID_CT_TITULOS,
                    ID_CT_DISIPLINA = a.ID_CT_DISIPLINA,
                    DESDE = a.DESDE,
                    HASTA = a.HASTA,
                    NOTA = a.NOTA,
                    DESCRIPCION = a.DESCRIPCION,
                    ARCHIVO_RUTA = a.ARCHIVO_RUTA,
                    ACTIVIDADES = a.ACTIVIDADES,
                    NOMBRE_INSTITUCION = a.NomnreInstitucion,
                    NOMBRE_DISIPLINA = a.NomnreDisiplina,
                    NOMBRE_TITULO = a.NomnreTitulos });
            return lista.ToList();
        }

        public HvEstudiosModel Actualizar(HvEstudiosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_ESTUDIOS.Where(s => s.ID_ESTUDIOS == a.ID_ESTUDIOS).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_ESTUDIOS = a.ID_ESTUDIOS;
                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    ResCtx.ID_CT_INSTITUCION = a.ID_CT_INSTITUCION;
                    ResCtx.ID_CT_TITULOS = a.ID_CT_TITULOS;
                    ResCtx.ID_CT_DISIPLINA = a.ID_CT_DISIPLINA;
                    ResCtx.DESDE = a.DESDE;
                    ResCtx.HASTA = a.HASTA;
                    ResCtx.NOTA = a.NOTA;
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    ResCtx.ARCHIVO_RUTA = a.ARCHIVO_RUTA;
                    ResCtx.ACTIVIDADES = a.ACTIVIDADES;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new HV_ESTUDIOS();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.HV_ESTUDIOS.Where(s => s.ID_ESTUDIOS == id).FirstOrDefault();
                Ctx.HV_ESTUDIOS.Remove(ResCtx);
                Ctx.SaveChanges();
            }
            return ResCtx.ID_DATOS_BASICOS.ToString();
        }
    }
}