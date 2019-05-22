using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtEspecialidadLogic
    {
       
        PERFIL_CT_ESPECIALIDAD ModCtx = new PERFIL_CT_ESPECIALIDAD();

        public PerfilCtEspecialidadModel Crear(PerfilCtEspecialidadModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_ESPECIALIDAD Nuevo = new PERFIL_CT_ESPECIALIDAD
                {
                    ID_ESPECIALIDAD = a.ID_ESPECIALIDAD,
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                Ctx.PERFIL_CT_ESPECIALIDAD.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtEspecialidadModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_ESPECIALIDAD.Where(e => e.ESTADO == 1).Select(a => new PerfilCtEspecialidadModel
            {
                ID_ESPECIALIDAD = a.ID_ESPECIALIDAD,
                NOMBRE = a.NOMBRE,

            });

            return lista.ToList();
        }

        public PerfilCtEspecialidadModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_CT_ESPECIALIDAD a = Ctx.PERFIL_CT_ESPECIALIDAD.Where(w => w.ID_ESPECIALIDAD == id).Select(s => s).FirstOrDefault();
            PerfilCtEspecialidadModel res = new PerfilCtEspecialidadModel();
            res.ID_ESPECIALIDAD = a.ID_ESPECIALIDAD;
            res.NOMBRE = a.NOMBRE;
            
            return res;
        }

        public PerfilCtEspecialidadModel Actualizar(PerfilCtEspecialidadModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_ESPECIALIDAD.Where(s => s.ID_ESPECIALIDAD == a.ID_ESPECIALIDAD).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_ESPECIALIDAD = a.ID_ESPECIALIDAD;
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
                var ResCtx = Ctx.PERFIL_CT_ESPECIALIDAD.Where(s => s.ID_ESPECIALIDAD == id).FirstOrDefault();
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