using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilLogic
    {

        PERFIL ModCtxPerfil = new PERFIL();

        public PerfilModel Crear(PerfilModel a)
        {
            using (AspNetIdentityEntities CtxPerfil = new AspNetIdentityEntities())
            {

                PERFIL perfilNuevo = new PERFIL
                {
                    ID_PERFIL = a.ID_PERFIL,
                    ID_CT_AREA = a.ID_CT_AREA,
                    ID_CT_SUB_AREA = a.ID_CT_SUB_AREA,
                    NOMBRE = a.NOMBRE,
                    REPORTA = a.REPORTA,
                    SUPERVISA = a.SUPERVISA,
                    OBJETIVO = a.OBJETIVO,
                    ESTADO = 1
                };
                CtxPerfil.PERFIL.Add(perfilNuevo);
                CtxPerfil.SaveChanges();
                a.ID_PERFIL = perfilNuevo.ID_PERFIL;
                return a;
            }
        }

        public List<PerfilModel> ConsultaPerfil()
        {
            AspNetIdentityEntities CtxPerfil = new AspNetIdentityEntities();

            var lista = CtxPerfil.PERFIL
            .Join(CtxPerfil.PERFIL_CT_AREA, a => a.ID_CT_AREA, b => b.ID_CT_AREA, (a, b) => new { a.ESTADO, a.ID_PERFIL, b.ID_CT_AREA, a.ID_CT_SUB_AREA,a.NOMBRE,a.REPORTA, a.SUPERVISA, a.OBJETIVO, NombreArea =b.DESCRIPCION })
            .Join(CtxPerfil.PERFIL_CT_SUB_AREA, b => b.ID_CT_SUB_AREA, c => c.ID_CT_SUB_AREA, (b, c) => new { b.ESTADO, b.ID_PERFIL, b.ID_CT_AREA, b.ID_CT_SUB_AREA, b.NOMBRE, b.REPORTA, b.SUPERVISA, b.OBJETIVO, b.NombreArea, NombreSubArea = c.DESCRIPCION })
            .Join(CtxPerfil.PERFIL, c => c.SUPERVISA, d => d.ID_PERFIL, (c, d) => new {c.ESTADO, c.ID_PERFIL, c.ID_CT_AREA, c.ID_CT_SUB_AREA, c.NOMBRE, c.REPORTA, c.SUPERVISA, c.OBJETIVO, c.NombreArea,c.NombreSubArea, NombreReporta = d.NOMBRE })
            .Join(CtxPerfil.PERFIL, d => d.REPORTA, e => e.ID_PERFIL, (d, e) => new { d.ESTADO, d.ID_PERFIL, d.ID_CT_AREA, d.ID_CT_SUB_AREA, d.NOMBRE, d.REPORTA, d.SUPERVISA, d.OBJETIVO, d.NombreArea, d.NombreSubArea, d.NombreReporta, NombreSupervisa = e.NOMBRE })
            .Where(c => c.ESTADO == 1)
             .Select(a => new PerfilModel
             {
                 ID_PERFIL = a.ID_PERFIL,
                 ID_CT_AREA = a.ID_CT_AREA,
                 NombreArea = a.NombreArea,
                 ID_CT_SUB_AREA = a.ID_CT_SUB_AREA,
                 NombreSubArea = a.NombreSubArea,
                 NOMBRE = a.NOMBRE,
                 REPORTA = a.REPORTA,
                 NombreReporta = a.NombreReporta,
                 SUPERVISA = a.SUPERVISA,
                 NombreSupervisa = a.NombreSupervisa,
                 OBJETIVO = a.OBJETIVO,
             });
          

            return lista.ToList();
        }

        public PerfilModel ConsultarPerfilId(int id)
        {
            AspNetIdentityEntities CtxPerfil = new AspNetIdentityEntities();
            var t = CtxPerfil.PERFIL
                .Join(CtxPerfil.PERFIL_CT_AREA, a => a.ID_CT_AREA, b => b.ID_CT_AREA, (a, b) => new { a.ESTADO, a.ID_PERFIL, b.ID_CT_AREA, a.ID_CT_SUB_AREA, a.NOMBRE, a.REPORTA, a.SUPERVISA, a.OBJETIVO, NombreArea = b.DESCRIPCION })
                .Join(CtxPerfil.PERFIL_CT_SUB_AREA, b => b.ID_CT_SUB_AREA, c => c.ID_CT_SUB_AREA, (b, c) => new { b.ESTADO, b.ID_PERFIL, b.ID_CT_AREA, b.ID_CT_SUB_AREA, b.NOMBRE, b.REPORTA, b.SUPERVISA, b.OBJETIVO, b.NombreArea, NombreSubArea = c.DESCRIPCION })
                .Join(CtxPerfil.PERFIL, c => c.SUPERVISA, d => d.ID_PERFIL, (c, d) => new { c.ESTADO, c.ID_PERFIL, c.ID_CT_AREA, c.ID_CT_SUB_AREA, c.NOMBRE, c.REPORTA, c.SUPERVISA, c.OBJETIVO, c.NombreArea, c.NombreSubArea, NombreReporta = d.NOMBRE })
                .Join(CtxPerfil.PERFIL, d => d.REPORTA, e => e.ID_PERFIL, (d, e) => new { d.ESTADO, d.ID_PERFIL, d.ID_CT_AREA, d.ID_CT_SUB_AREA, d.NOMBRE, d.REPORTA, d.SUPERVISA, d.OBJETIVO, d.NombreArea, d.NombreSubArea, d.NombreReporta, NombreSupervisa = e.NOMBRE })
                .Where(x => x.ESTADO == 1)
                 .Where(w => w.ID_PERFIL == id)
                 .Select(s => s).FirstOrDefault();
                PerfilModel res = new PerfilModel();
                res.ID_PERFIL = t.ID_PERFIL;
                res.ID_CT_AREA = t.ID_CT_AREA;
                res.NombreArea = t.NombreArea;
                res.ID_CT_SUB_AREA = t.ID_CT_SUB_AREA;
                res.NombreSubArea = t.NombreSubArea;
                res.NOMBRE = t.NOMBRE;
                res.REPORTA = t.REPORTA;
                res.NombreReporta = t.NombreReporta;
                res.SUPERVISA = t.SUPERVISA;
                res.NombreSupervisa = t.NombreSupervisa;
                res.OBJETIVO = t.OBJETIVO;
            
            return res;
        }

        public PerfilModel Actualizar(PerfilModel a)
        {
            using (var CtxPerfil = new AspNetIdentityEntities())
            {
                var usu_ctx = CtxPerfil.PERFIL.Where(s => s.ID_PERFIL == a.ID_PERFIL).FirstOrDefault();

                if (usu_ctx != null)
                {
                    usu_ctx.ID_PERFIL = a.ID_PERFIL;
                    usu_ctx.ID_CT_AREA = a.ID_CT_AREA;
                    usu_ctx.ID_CT_SUB_AREA = a.ID_CT_SUB_AREA;
                    usu_ctx.NOMBRE = a.NOMBRE;
                    usu_ctx.REPORTA = a.REPORTA;
                    usu_ctx.SUPERVISA = a.SUPERVISA;
                    usu_ctx.OBJETIVO = a.OBJETIVO;
                   
                    CtxPerfil.SaveChanges();
                }
                
            }

            return a;
        }

        public String Eliminar(int id)
        {
            using (var CtxPerfil = new AspNetIdentityEntities())
            {
                var perfil = CtxPerfil.PERFIL.Where(s => s.ID_PERFIL == id).FirstOrDefault();
                if (perfil != null) // --------------------- //
                {
                    perfil.ESTADO = 0;
                    CtxPerfil.SaveChanges();
                }
            }

            return "realizado ";
        }
    }
}