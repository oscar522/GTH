using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtActitudesLogic
    {
        HV_CT_ACTITUDES ModCtx = new HV_CT_ACTITUDES();

        public HvCtActitudesModel Crear(HvCtActitudesModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_ACTITUDES Nuevo = new HV_CT_ACTITUDES
                {
                    ID_ACTITUDES = a.ID_ACTITUDES,
                    NOMBRE = a.NOMBRE,
                    
                };

               
                Nuevo.ESTADO = 1;
                Ctx.HV_CT_ACTITUDES.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtActitudesModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_ACTITUDES.Where(x => x.ESTADO == 1).Select(a => new HvCtActitudesModel
            {
                ID_ACTITUDES = a.ID_ACTITUDES,
                NOMBRE = a.NOMBRE,
                

            });

            return lista.ToList();
        }

        public HvCtActitudesModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_ACTITUDES a = Ctx.HV_CT_ACTITUDES.Where(w => w.ID_ACTITUDES == id).Select(s => s).FirstOrDefault();
            HvCtActitudesModel b = new HvCtActitudesModel();
            b.ID_ACTITUDES = a.ID_ACTITUDES;
            b.NOMBRE = a.NOMBRE;
            
            return b;
        }

        public HvCtActitudesModel Actualizar(HvCtActitudesModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_ACTITUDES.Where(s => s.ID_ACTITUDES == a.ID_ACTITUDES).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ID_ACTITUDES = a.ID_ACTITUDES;
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
                var ResCtx = Ctx.HV_CT_ACTITUDES.Where(s => s.ID_ACTITUDES == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}