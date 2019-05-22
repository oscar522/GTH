using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilRelacionesLogic
    {

        PERFIL_RELACIONES ModCtx = new PERFIL_RELACIONES();

        public PerfilRelacionesModel Crear(PerfilRelacionesModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_RELACIONES Nuevo = new PERFIL_RELACIONES
                {
                    ID_RELACION = a.ID_RELACION,
                    ID_PERFIL = a.ID_PERFIL,
                    TIPO = a.TIPO,
                    NOMBRE = a.NOMBRE,
                    MOTIVO = a.MOTIVO,
                    ESTADO = 1
                };
                Ctx.PERFIL_RELACIONES.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilRelacionesModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_RELACIONES.Where(w => w.ESTADO == 1).Select(a => new PerfilRelacionesModel
            {
                ID_RELACION = a.ID_RELACION,
                ID_PERFIL = a.ID_PERFIL,
                TIPO = a.TIPO,
                NOMBRE = a.NOMBRE,
                MOTIVO = a.MOTIVO,
                

            });

            return lista.ToList();
        }
        public List<PerfilRelacionesModel> ConsultarIdD(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_RELACIONES.Where(w => w.ESTADO == 1).Where(w => w.ID_PERFIL == Idpa).Select(a => new PerfilRelacionesModel
            {
                ID_RELACION = a.ID_RELACION,
                ID_PERFIL = a.ID_PERFIL,
                TIPO = a.TIPO,
                NOMBRE = a.NOMBRE,
                MOTIVO = a.MOTIVO,
            });

            return lista.ToList();
        }
        public PerfilRelacionesModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_RELACIONES a = Ctx.PERFIL_RELACIONES.Where(w => w.ESTADO == 1).Where(w => w.ID_RELACION == id).Select(s => s).FirstOrDefault();
            PerfilRelacionesModel b = new PerfilRelacionesModel();
            b.ID_RELACION = a.ID_RELACION;
            b.ID_PERFIL = a.ID_PERFIL;
            b.TIPO = a.TIPO;
            b.NOMBRE = a.NOMBRE;
            b.MOTIVO = a.MOTIVO;
            
            return b;
        }

        public PerfilRelacionesModel Actualizar(PerfilRelacionesModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_RELACIONES.Where(s => s.ID_RELACION == a.ID_RELACION).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_RELACION = a.ID_RELACION;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    ResCtx.TIPO = a.TIPO;
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.MOTIVO = a.MOTIVO;
                    
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new PERFIL_RELACIONES();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.PERFIL_RELACIONES.Where(s => s.ID_RELACION == id).FirstOrDefault();
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