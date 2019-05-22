using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtCompetenciasLogic
    {
     
        PERFIL_CT_COMPETENCIAS ModCtx = new PERFIL_CT_COMPETENCIAS();

        public PerfilCtCompetenciasModel Crear(PerfilCtCompetenciasModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_COMPETENCIAS Nuevo = new PERFIL_CT_COMPETENCIAS
                {
                    ID_CT_COMPETENCIA = a.ID_CT_COMPETENCIA,
                    ID_TIPO_COMPET = a.ID_TIPO_COMPET,
                    NOMBRE = a.NOMBRE,
                    DESCRIPCION = a.DESCRIPCION,
                    ESTADO = 1
                };
                Ctx.PERFIL_CT_COMPETENCIAS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtCompetenciasModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_COMPETENCIAS
                .Join(Ctx.PERFIL_CT_TIPOS_COMPETENCIAS, b => b.ID_TIPO_COMPET, c => c.ID_TIPO_COMPET, (c, d) =>
                 new { c.ID_TIPO_COMPET, c.ID_CT_COMPETENCIA, c.NOMBRE, c.DESCRIPCION, c.ESTADO,  NombreTipos = d.NOMBRE })

                .Where(e => e.ESTADO == 1).Select(a => new PerfilCtCompetenciasModel
            {
                ID_CT_COMPETENCIA = a.ID_CT_COMPETENCIA,
                ID_TIPO_COMPET = a.ID_TIPO_COMPET,
                NOMBRE_COMPET = a.NombreTipos,
                NOMBRE = a.NOMBRE,
                DESCRIPCION = a.DESCRIPCION,
                ESTADO = a.ESTADO,
               
            });
            return lista.ToList();
        }

        public PerfilCtCompetenciasModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.PERFIL_CT_COMPETENCIAS
                .Join(Ctx.PERFIL_CT_TIPOS_COMPETENCIAS, d => d.ID_TIPO_COMPET, c => c.ID_TIPO_COMPET, (c, d) =>
                 new { c.ID_TIPO_COMPET, c.ID_CT_COMPETENCIA, c.NOMBRE, c.DESCRIPCION, c.ESTADO, NombreTipos = d.NOMBRE })
                .Where(w => w.ID_CT_COMPETENCIA == id).Select(s => s).FirstOrDefault();
            PerfilCtCompetenciasModel b = new PerfilCtCompetenciasModel();
            b.ID_CT_COMPETENCIA = a.ID_CT_COMPETENCIA;
            b.ID_TIPO_COMPET = a.ID_TIPO_COMPET;
            b.NOMBRE_COMPET = a.NombreTipos;
            b.NOMBRE = a.NOMBRE;
            b.DESCRIPCION = a.DESCRIPCION;
            b.ESTADO = a.ESTADO;
            return b;
        }

        public PerfilCtCompetenciasModel Actualizar(PerfilCtCompetenciasModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_COMPETENCIAS.Where(s => s.ID_CT_COMPETENCIA == a.ID_CT_COMPETENCIA).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_COMPETENCIA = a.ID_CT_COMPETENCIA;
                    ResCtx.ID_TIPO_COMPET = a.ID_TIPO_COMPET;
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
                var ResCtx = Ctx.PERFIL_CT_COMPETENCIAS.Where(s => s.ID_CT_COMPETENCIA == id).FirstOrDefault();
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