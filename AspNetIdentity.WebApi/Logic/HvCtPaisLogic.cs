using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtPaisLogic
    {
        HV_CT_PAIS ModCtx = new HV_CT_PAIS();

        public HvCtPaisModel Crear(HvCtPaisModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_PAIS Nuevo = new HV_CT_PAIS
                {
                    NOMBRE = a.NOMBRE,
                    ESTADO = 1
                };
                              
                Ctx.HV_CT_PAIS.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtPaisModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_PAIS.Where(s => s.ESTADO == 1).Select(a => new HvCtPaisModel
            {
                ID_CT_PAIS = a.ID_CT_PAIS,
                NOMBRE = a.NOMBRE

            });

            return lista.ToList();
        }

        public HvCtPaisModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_PAIS a = Ctx.HV_CT_PAIS.Where(w => w.ID_CT_PAIS == id).Where(s => s.ESTADO == 1).Select(s => s).FirstOrDefault();
            HvCtPaisModel b = new HvCtPaisModel();
            b.ID_CT_PAIS = a.ID_CT_PAIS;
            b.NOMBRE = a.NOMBRE;
            b.ESTADO = a.ESTADO.Value;
            return b;
        }

        public HvCtPaisModel Actualizar(HvCtPaisModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_PAIS.Where(s => s.ESTADO == 1).Where(s => s.ID_CT_PAIS == a.ID_CT_PAIS).FirstOrDefault();
                if (ResCtx != null)
                {
                
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
                var ResCtx = Ctx.HV_CT_PAIS.Where(s => s.ID_CT_PAIS == id).Where(s => s.ESTADO == 1).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "REALIZADO";
        }
    }
}