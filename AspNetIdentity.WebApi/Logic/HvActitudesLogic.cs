using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic

{
    public class HvActitudesLogic
    {

        HV_ACTITUDES ModCtx = new HV_ACTITUDES();

        public HvActitudesModel Crear(HvActitudesModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_ACTITUDES Nuevo = new HV_ACTITUDES
                {
                    ID_ACTITUDES = a.ID_ACTITUDES,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_ACTITUDES = a.ID_CT_ACTITUDES,
                    ESTADO = 1
                };
                Ctx.HV_ACTITUDES.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvActitudesModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_ACTITUDES
                .Join(Ctx.HV_CT_ACTITUDES, b => b.ID_CT_ACTITUDES, c => c.ID_ACTITUDES, (b, c) =>
                 new {b.ESTADO, b.ID_ACTITUDES, b.ID_CT_ACTITUDES, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                 .Where(d => d.ESTADO == 1)
                .Select(a => new HvActitudesModel
                {
                ID_ACTITUDES = a.ID_ACTITUDES,
                ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                NOMBRE_CT_ACTITUDES = a.NombreCt,
                ID_CT_ACTITUDES = a.ID_CT_ACTITUDES.Value
        });

            return lista.ToList();
        }
        public List<HvActitudesModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_ACTITUDES
                .Join(Ctx.HV_CT_ACTITUDES, b => b.ID_CT_ACTITUDES, c => c.ID_ACTITUDES, (b, c) =>
                 new { b.ESTADO, b.ID_ACTITUDES, b.ID_CT_ACTITUDES, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                .Where(d => d.ESTADO == 1)
                .Where(w => w.ID_ACTITUDES == Idpa)
                .Select(a => new HvActitudesModel
                {
                    ID_ACTITUDES = a.ID_ACTITUDES,
                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    NOMBRE_CT_ACTITUDES = a.NombreCt,
                    ID_CT_ACTITUDES = a.ID_CT_ACTITUDES.Value
                });

            return lista.ToList();
        }
        public HvActitudesModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var e = Ctx.HV_ACTITUDES
                .Join(Ctx.HV_CT_ACTITUDES, b => b.ID_CT_ACTITUDES, c => c.ID_ACTITUDES, (b, c) =>
                 new { b.ESTADO, b.ID_ACTITUDES, b.ID_CT_ACTITUDES, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                
                .Where(w => w.ID_ACTITUDES == id).Select(s => s).FirstOrDefault();
                HvActitudesModel a = new HvActitudesModel();

                a.ID_ACTITUDES = e.ID_ACTITUDES;
                a.ID_DATOS_BASICOS = e.ID_DATOS_BASICOS;
                a.ID_CT_ACTITUDES = e.ID_CT_ACTITUDES.Value;
                a.NOMBRE_CT_ACTITUDES = e.NombreCt;
            return a;
        }

        public List<HvActitudesModel> ConsultarIdD(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_ACTITUDES
                .Join(Ctx.HV_CT_ACTITUDES, b => b.ID_CT_ACTITUDES, c => c.ID_ACTITUDES, (b, c) =>
                 new { b.ESTADO, b.ID_ACTITUDES, b.ID_CT_ACTITUDES, b.ID_DATOS_BASICOS, NombreCt = c.NOMBRE })
                .Where(w => w.ID_DATOS_BASICOS == id)
                .Where(d => d.ESTADO == 1)
                .Select(x => new HvActitudesModel {

                    ID_ACTITUDES = x.ID_ACTITUDES,
                    ID_DATOS_BASICOS = x.ID_DATOS_BASICOS,
                    ID_CT_ACTITUDES = x.ID_CT_ACTITUDES.Value,
                    NOMBRE_CT_ACTITUDES = x.NombreCt
        });
            return lista.ToList();
        }

        public HvActitudesModel Actualizar(HvActitudesModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_ACTITUDES.Where(s => s.ID_ACTITUDES == a.ID_ACTITUDES).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_ACTITUDES = a.ID_ACTITUDES;
                    ResCtx.ID_CT_ACTITUDES = a.ID_CT_ACTITUDES;
                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            var ResCtx = new HV_ACTITUDES();
            using (var Ctx = new AspNetIdentityEntities())
            {
                ResCtx = Ctx.HV_ACTITUDES.Where(s => s.ID_ACTITUDES == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return ResCtx.ID_DATOS_BASICOS.ToString();
        }
    }
}