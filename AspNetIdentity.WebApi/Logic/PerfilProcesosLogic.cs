using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilProcesosLogic
    {
        
        PERFIL_PROCESOS ModCtx = new PERFIL_PROCESOS();

        public PerfilProcesosModel Crear(PerfilProcesosModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_PROCESOS Nuevo = new PERFIL_PROCESOS
                {
                    ID_PROCESO = a.ID_PROCESO,
                    ID_PERFIL = a.ID_PERFIL,
                    NOMBRE = a.NOMBRE,
                    DESCRIPCION = a.DESCRIPCION,
                    ESTADO = 1
                    
                };
                Ctx.PERFIL_PROCESOS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilProcesosModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_PROCESOS.Where(w => w.ESTADO == 1).Select(a => new PerfilProcesosModel
            {
                ID_PROCESO = a.ID_PROCESO,
                ID_PERFIL = a.ID_PERFIL,
                NOMBRE = a.NOMBRE,
                DESCRIPCION = a.DESCRIPCION,
            });

            return lista.ToList();
        }
        public List<PerfilProcesosModel> ConsultarIdD(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_PROCESOS.Where(w => w.ESTADO == 1).Where(w => w.ID_PERFIL == Idpa).Select(a => new PerfilProcesosModel
            {
                ID_PROCESO = a.ID_PROCESO,
                ID_PERFIL = a.ID_PERFIL,
                NOMBRE = a.NOMBRE,
                DESCRIPCION = a.DESCRIPCION,
            });

            return lista.ToList();
        }
        public PerfilProcesosModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_PROCESOS a = Ctx.PERFIL_PROCESOS.Where(w => w.ESTADO == 1).Where(w => w.ID_PROCESO == id).Select(s => s).FirstOrDefault();
            PerfilProcesosModel res = new PerfilProcesosModel();
            res.ID_PROCESO = a.ID_PROCESO;
            res.ID_PERFIL = a.ID_PERFIL;
            res.NOMBRE = a.NOMBRE;
            res.DESCRIPCION = a.DESCRIPCION;
            
            
            return res;
        }

        public PerfilProcesosModel Actualizar(PerfilProcesosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_PROCESOS.Where(s => s.ID_PROCESO == a.ID_PROCESO).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_PROCESO = a.ID_PROCESO;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    ResCtx.NOMBRE = a.NOMBRE;
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                  
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new PERFIL_PROCESOS();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.PERFIL_PROCESOS.Where(s => s.ID_PROCESO == id).FirstOrDefault();
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