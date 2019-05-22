using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilFormacionLogic
    {
       
        PERFIL_FORMACION ModCtx = new PERFIL_FORMACION();

        public PerfilFormacionModel Crear(PerfilFormacionModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_FORMACION Nuevo = new PERFIL_FORMACION
                {
                    ID_FORMACION = a.ID_FORMACION,
                    ID_PERFIL = a.ID_PERFIL,
                    ID_ESCOLARIDAD = a.ID_ESCOLARIDAD,
                    ID_ESPECIALIDAD = a.ID_ESPECIALIDAD,
                    EXPERIENCIA = a.EXPERIENCIA,
                    ESTADO = 1
                };
                Ctx.PERFIL_FORMACION.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilFormacionModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_FORMACION
                .Join(Ctx.PERFIL_CT_ESCOLARIDAD, b => b.ID_ESCOLARIDAD, c => c.ID_ESCOLARIDAD, (b, c) =>
                 new { b.ID_FORMACION,b.ID_PERFIL, b.ID_ESCOLARIDAD, b.ID_ESPECIALIDAD, b.EXPERIENCIA, b.ESTADO, NombreEscolaridad = c.NOMBRE })
                 .Join(Ctx.PERFIL_CT_ESPECIALIDAD, b => b.ID_ESPECIALIDAD, c => c.ID_ESPECIALIDAD, (b, c) =>
                 new { b.ID_FORMACION, b.ID_PERFIL, b.ID_ESCOLARIDAD, b.ID_ESPECIALIDAD, b.EXPERIENCIA, b.ESTADO, b.NombreEscolaridad, NombreEspecialidad = c.NOMBRE })
                .Where(w => w.ESTADO == 1).Select(a => new PerfilFormacionModel
                {

                    ID_FORMACION = a.ID_FORMACION,
                    ID_PERFIL = a.ID_PERFIL,
                    ID_ESCOLARIDAD = a.ID_ESCOLARIDAD,
                    NombreEscolaridad = a.NombreEscolaridad,
                    ID_ESPECIALIDAD = a.ID_ESPECIALIDAD,
                    NombreEspecialidad = a.NombreEspecialidad,
                    EXPERIENCIA = a.EXPERIENCIA,
                

                });

            return lista.ToList();
        }

        public List<PerfilFormacionModel> ConsultarIdD(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_FORMACION
                .Join(Ctx.PERFIL_CT_ESCOLARIDAD, b => b.ID_ESCOLARIDAD, c => c.ID_ESCOLARIDAD, (b, c) =>
                 new { b.ID_FORMACION, b.ID_PERFIL, b.ID_ESCOLARIDAD, b.ID_ESPECIALIDAD, b.EXPERIENCIA, b.ESTADO, NombreEscolaridad = c.NOMBRE })
                 .Join(Ctx.PERFIL_CT_ESPECIALIDAD, b => b.ID_ESPECIALIDAD, c => c.ID_ESPECIALIDAD, (b, c) =>
                 new { b.ID_FORMACION, b.ID_PERFIL, b.ID_ESCOLARIDAD, b.ID_ESPECIALIDAD, b.EXPERIENCIA, b.ESTADO, b.NombreEscolaridad, NombreEspecialidad = c.NOMBRE })
                .Where(w => w.ESTADO == 1).Where(w => w.ID_PERFIL == Idpa).Select(a => new PerfilFormacionModel
                {
                    ID_FORMACION = a.ID_FORMACION,
                    ID_PERFIL = a.ID_PERFIL,
                    ID_ESCOLARIDAD = a.ID_ESCOLARIDAD,
                    NombreEscolaridad = a.NombreEscolaridad,
                    ID_ESPECIALIDAD = a.ID_ESPECIALIDAD,
                    NombreEspecialidad = a.NombreEspecialidad,
                    EXPERIENCIA = a.EXPERIENCIA,
                });
      

            return lista.ToList();
        }

        public PerfilFormacionModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.PERFIL_FORMACION
                .Join(Ctx.PERFIL_CT_ESCOLARIDAD, b => b.ID_ESCOLARIDAD, c => c.ID_ESCOLARIDAD, (b, c) =>
                 new { b.ID_FORMACION, b.ID_PERFIL, b.ID_ESCOLARIDAD, b.ID_ESPECIALIDAD, b.EXPERIENCIA, b.ESTADO, NombreEscolaridad = c.NOMBRE })
                 .Join(Ctx.PERFIL_CT_ESPECIALIDAD, b => b.ID_ESPECIALIDAD, c => c.ID_ESPECIALIDAD, (b, c) =>
                 new { b.ID_FORMACION, b.ID_PERFIL, b.ID_ESCOLARIDAD, b.ID_ESPECIALIDAD, b.EXPERIENCIA, b.ESTADO, b.NombreEscolaridad, NombreEspecialidad = c.NOMBRE })
                .Where(w => w.ESTADO == 1).Where(w => w.ID_FORMACION == id).Select(s => s).FirstOrDefault();
            PerfilFormacionModel res = new PerfilFormacionModel();
            res.ID_FORMACION = a.ID_FORMACION;
            res.ID_PERFIL = a.ID_PERFIL;
            res.ID_ESCOLARIDAD = a.ID_ESCOLARIDAD;
            res.NombreEscolaridad = a.NombreEscolaridad;
            res.ID_ESPECIALIDAD = a.ID_ESPECIALIDAD;
            res.NombreEspecialidad = a.NombreEspecialidad;
            res.EXPERIENCIA = a.EXPERIENCIA;
            
            return res;
        }

        public PerfilFormacionModel Actualizar(PerfilFormacionModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_FORMACION.Where(s => s.ID_FORMACION == a.ID_FORMACION).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_FORMACION = a.ID_FORMACION;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    ResCtx.ID_ESCOLARIDAD = a.ID_ESCOLARIDAD;
                    ResCtx.ID_ESPECIALIDAD = a.ID_ESPECIALIDAD;
                    ResCtx.EXPERIENCIA = a.EXPERIENCIA;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new PERFIL_FORMACION();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.PERFIL_FORMACION.Where(s => s.ID_FORMACION == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return ResCtx.ID_PERFIL.ToString();
        }
    }
}