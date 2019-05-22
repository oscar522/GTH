using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilFinalidadLogic
    {
      

        PERFIL_FINALIDADES ModCtx = new PERFIL_FINALIDADES();

        public PerfilFinalidadModel Crear(PerfilFinalidadModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_FINALIDADES Nuevo = new PERFIL_FINALIDADES
                {
                    ID_FINALIDAD = a.ID_FINALIDAD,
                    ID_PERFIL = a.ID_PERFIL,
                    ACCION = a.ACCION,
                    FUNCION = a.FUNCION,
                    RESULTADOS = a.RESULTADOS,
                    ESTADO = 1
                    
                };

                Ctx.PERFIL_FINALIDADES.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilFinalidadModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_FINALIDADES.Where(w => w.ESTADO == 1).Select(a => new PerfilFinalidadModel
            {
                ID_FINALIDAD = a.ID_FINALIDAD,
                ID_PERFIL = a.ID_PERFIL,
                ACCION = a.ACCION,
                FUNCION = a.FUNCION,
                RESULTADOS = a.RESULTADOS,
            });

            return lista.ToList();
        }
        public List<PerfilFinalidadModel> ConsultarIdD(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_FINALIDADES.Where(w => w.ESTADO == 1).Where(w => w.ID_PERFIL == Idpa).Select(a => new PerfilFinalidadModel
            {
                ID_FINALIDAD = a.ID_FINALIDAD,
                ID_PERFIL = a.ID_PERFIL,
                ACCION = a.ACCION,
                FUNCION = a.FUNCION,
                RESULTADOS = a.RESULTADOS,
            });

            return lista.ToList();
        }
        public PerfilFinalidadModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            PERFIL_FINALIDADES a = Ctx.PERFIL_FINALIDADES.Where(w => w.ESTADO == 1).Where(w => w.ID_FINALIDAD == id).Select(s => s).FirstOrDefault();
            PerfilFinalidadModel res = new PerfilFinalidadModel();
            res.ID_FINALIDAD = a.ID_FINALIDAD;
            res.ID_PERFIL = a.ID_PERFIL;
            res.ACCION = a.ACCION;
            res.FUNCION = a.FUNCION;
            res.RESULTADOS = a.RESULTADOS;
           
            return res;
        }

        public PerfilFinalidadModel Actualizar(PerfilFinalidadModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_FINALIDADES.Where(s => s.ID_FINALIDAD == a.ID_FINALIDAD).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_FINALIDAD = a.ID_FINALIDAD;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    ResCtx.ACCION = a.ACCION;
                    ResCtx.FUNCION = a.FUNCION;
                    ResCtx.RESULTADOS = a.RESULTADOS;
                    
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new PERFIL_FINALIDADES();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.PERFIL_FINALIDADES.Where(s => s.ID_FINALIDAD == id).FirstOrDefault();
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