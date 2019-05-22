using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtTiposCompetenciaLogic
    {
        PERFIL_CT_TIPOS_COMPETENCIAS ModCtx = new PERFIL_CT_TIPOS_COMPETENCIAS();

        public PerfilCtTiposCompetenciaModel Crear(PerfilCtTiposCompetenciaModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_TIPOS_COMPETENCIAS Nuevo = new PERFIL_CT_TIPOS_COMPETENCIAS
                {
                    ID_TIPO_COMPET = a.ID_TIPO_COMPET,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1 // --------------------- //
                };
                Ctx.PERFIL_CT_TIPOS_COMPETENCIAS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtTiposCompetenciaModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_TIPOS_COMPETENCIAS.Where(e => e.ESTADO == 1).Select(a => new PerfilCtTiposCompetenciaModel
            {
                ID_TIPO_COMPET = a.ID_TIPO_COMPET,
                NOMBRE = a.NOMBRE,

            });

            return lista.ToList();
        }

        public PerfilCtTiposCompetenciaModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_CT_TIPOS_COMPETENCIAS a = Ctx.PERFIL_CT_TIPOS_COMPETENCIAS.Where(w => w.ID_TIPO_COMPET == id).Select(s => s).FirstOrDefault();
            PerfilCtTiposCompetenciaModel res = new PerfilCtTiposCompetenciaModel();
            res.ID_TIPO_COMPET = a.ID_TIPO_COMPET;
            res.NOMBRE = a.NOMBRE;
            return res;
        }

        public PerfilCtTiposCompetenciaModel Actualizar(PerfilCtTiposCompetenciaModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_TIPOS_COMPETENCIAS.Where(s => s.ID_TIPO_COMPET == a.ID_TIPO_COMPET).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_TIPO_COMPET = a.ID_TIPO_COMPET;
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
                var ResCtx = Ctx.PERFIL_CT_TIPOS_COMPETENCIAS.Where(s => s.ID_TIPO_COMPET == id).FirstOrDefault();
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