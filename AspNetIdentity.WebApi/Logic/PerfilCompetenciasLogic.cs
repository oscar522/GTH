using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCompetenciasLogic
    {

        PERFIL_COMPETENCIAS ModCtx = new PERFIL_COMPETENCIAS();

        public PerfilCompetenciasModel Crear(PerfilCompetenciasModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities ())
            {
                PERFIL_COMPETENCIAS Nuevo = new PERFIL_COMPETENCIAS
                {
                    ID_PERFI_COMPE = a.ID_PERFI_COMPE,
                    ID_PERFIL = a.ID_PERFIL,
                   
                };

                ModCtx = Ctx.PERFIL_COMPETENCIAS.GroupBy(r => r.ID_PERFI_COMPE).OrderByDescending(g => g.Key).FirstOrDefault().First();
                if (ModCtx.ID_PERFI_COMPE == 0)
                {
                    Nuevo.ID_PERFI_COMPE = 1;
                }
                else
                {
                    Nuevo.ID_PERFI_COMPE = ModCtx.ID_PERFI_COMPE + 1;
                }
                Ctx.PERFIL_COMPETENCIAS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCompetenciasModel> Consulta()
        {
            AspNetIdentityEntities Ctx  = new AspNetIdentityEntities ();
            var lista = Ctx.PERFIL_COMPETENCIAS.Select(a => new PerfilCompetenciasModel
            {
                ID_PERFI_COMPE = a.ID_PERFI_COMPE,
                ID_PERFIL = a.ID_PERFIL,
                
               

            });

            return lista.ToList();
        }

        public PerfilCompetenciasModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx  = new AspNetIdentityEntities ();
            PERFIL_COMPETENCIAS a = Ctx.PERFIL_COMPETENCIAS.Where(w => w.ID_PERFI_COMPE == id).Select(s => s).FirstOrDefault();
            PerfilCompetenciasModel res = new PerfilCompetenciasModel();
            res.ID_PERFI_COMPE = a.ID_PERFI_COMPE;
            res.ID_PERFIL = a.ID_PERFIL;
            res.ID_PERFI_COMPE = a.ID_PERFI_COMPE;
            
            return res;
        }

        public PerfilCompetenciasModel Actualizar(PerfilCompetenciasModel a)
        {
            using (var Ctx = new AspNetIdentityEntities ())
            {
                var ResCtx = Ctx.PERFIL_COMPETENCIAS.Where(s => s.ID_PERFI_COMPE == a.ID_PERFI_COMPE).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_PERFI_COMPE = a.ID_PERFI_COMPE;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    ResCtx.ID_PERFI_COMPE = a.ID_PERFI_COMPE;
                    
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities ())
            {
                var ResCtx = Ctx.PERFIL_COMPETENCIAS.Where(s => s.ID_PERFI_COMPE == id).FirstOrDefault();
                Ctx.PERFIL_COMPETENCIAS.Remove(ResCtx);
                Ctx.SaveChanges();
            }
            return "realizado ";
        }
    }
}