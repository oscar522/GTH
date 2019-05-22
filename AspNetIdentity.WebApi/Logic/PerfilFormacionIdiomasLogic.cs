using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilFormacionIdiomasLogic
    {
             PERFIL_FORMA_IDIOMAS ModCtx = new PERFIL_FORMA_IDIOMAS();

        public PerfilFormacionIdiomasModel Crear(PerfilFormacionIdiomasModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_FORMA_IDIOMAS Nuevo = new PERFIL_FORMA_IDIOMAS
                {

                    ID_FORMA_IDIOM = a.ID_FORMA_IDIOM,
                    ID_PERFIL = a.ID_PERFIL,
                    ID_IDIOMA = a.ID_IDIOMA,
                    ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL,
                    ESTADO = 1
                    
                };

                Ctx.PERFIL_FORMA_IDIOMAS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilFormacionIdiomasModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_FORMA_IDIOMAS
                .Join(Ctx.PERFIL_CT_IDIOM_NIVEL, b => b.ID_IDIOM_NIVEL, c => c.ID_IDIOM_NIVEL, (b, c) =>
                 new { b.ESTADO, b.ID_FORMA_IDIOM, b.ID_PERFIL, b.ID_IDIOMA, b.ID_IDIOM_NIVEL, NombreNivel = c.NOMBRE })
                 .Join(Ctx.PERFIL_CT_IDIOMAS, b => b.ID_IDIOMA, c => c.ID_IDIOMA, (b, c) =>
                 new { b.ESTADO, b.ID_FORMA_IDIOM, b.ID_PERFIL, b.ID_IDIOMA, b.ID_IDIOM_NIVEL, b.NombreNivel, NombreIdioma = c.NOMBRE })
                .Where(w => w.ESTADO == 1)
                .Select(a => new PerfilFormacionIdiomasModel
            {
                ID_FORMA_IDIOM = a.ID_FORMA_IDIOM,
                ID_PERFIL = a.ID_PERFIL,
                ID_IDIOMA = a.ID_IDIOMA,
                NombreIdioma= a.NombreIdioma,
                ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL,
                NombreNivel = a.NombreNivel
            });

            return lista.ToList();
        }
        public List<PerfilFormacionIdiomasModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_FORMA_IDIOMAS
                .Join(Ctx.PERFIL_CT_IDIOM_NIVEL, b => b.ID_IDIOM_NIVEL, c => c.ID_IDIOM_NIVEL, (b, c) =>
                 new { b.ESTADO, b.ID_FORMA_IDIOM, b.ID_PERFIL, b.ID_IDIOMA, b.ID_IDIOM_NIVEL, NombreNivel = c.NOMBRE })
                 .Join(Ctx.PERFIL_CT_IDIOMAS, b => b.ID_IDIOMA, c => c.ID_IDIOMA, (b, c) =>
                 new { b.ESTADO, b.ID_FORMA_IDIOM, b.ID_PERFIL, b.ID_IDIOMA, b.ID_IDIOM_NIVEL, b.NombreNivel, NombreIdioma = c.NOMBRE })
                .Where(w => w.ESTADO == 1).Where(w => w.ID_PERFIL == Idpa).Select(a => new PerfilFormacionIdiomasModel
                {
                    ID_FORMA_IDIOM = a.ID_FORMA_IDIOM,
                    ID_PERFIL = a.ID_PERFIL,
                    ID_IDIOMA = a.ID_IDIOMA,
                    NombreIdioma = a.NombreIdioma,
                    ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL,
                    NombreNivel = a.NombreNivel
                });

            return lista.ToList();
        }
        public PerfilFormacionIdiomasModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.PERFIL_FORMA_IDIOMAS
                .Join(Ctx.PERFIL_CT_IDIOM_NIVEL, b => b.ID_IDIOM_NIVEL, c => c.ID_IDIOM_NIVEL, (b, c) =>
                 new { b.ESTADO, b.ID_FORMA_IDIOM, b.ID_PERFIL, b.ID_IDIOMA, b.ID_IDIOM_NIVEL, NombreNivel = c.NOMBRE })
                 .Join(Ctx.PERFIL_CT_IDIOMAS, b => b.ID_IDIOMA, c => c.ID_IDIOMA, (b, c) =>
                 new { b.ESTADO, b.ID_FORMA_IDIOM, b.ID_PERFIL, b.ID_IDIOMA, b.ID_IDIOM_NIVEL, b.NombreNivel, NombreIdioma = c.NOMBRE })
                .Where(w => w.ESTADO == 1)

                .Where(w => w.ID_FORMA_IDIOM == id).Select(s => s).FirstOrDefault();
            PerfilFormacionIdiomasModel res = new PerfilFormacionIdiomasModel();
            res.ID_FORMA_IDIOM = a.ID_FORMA_IDIOM;
            res.ID_PERFIL = a.ID_PERFIL;
            res.ID_IDIOMA = a.ID_IDIOMA;
            res.ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL;
            res.NombreIdioma = a.NombreIdioma;
            res.NombreNivel = a.NombreNivel;
            
            Ctx.SaveChanges();
            return res;
        }

        public PerfilFormacionIdiomasModel Actualizar(PerfilFormacionIdiomasModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_FORMA_IDIOMAS.Where(s => s.ID_FORMA_IDIOM == a.ID_FORMA_IDIOM).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_FORMA_IDIOM = a.ID_FORMA_IDIOM;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    ResCtx.ID_IDIOMA = a.ID_IDIOMA;
                    ResCtx.ID_IDIOM_NIVEL = a.ID_IDIOM_NIVEL;
                   
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_FORMA_IDIOMAS.Where(s => s.ID_FORMA_IDIOM == id).FirstOrDefault();
                Ctx.PERFIL_FORMA_IDIOMAS.Remove(ResCtx);
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