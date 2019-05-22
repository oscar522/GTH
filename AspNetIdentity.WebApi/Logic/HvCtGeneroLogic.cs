using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtGeneroLogic
    {
        HV_CT_GENERO ModCtx = new HV_CT_GENERO();

        public HvCtGeneroModel Crear(HvCtGeneroModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_GENERO Nuevo = new HV_CT_GENERO
                {
                    NOMBRE = a.NOMBRE,
                    
                };

                Nuevo.ESTADO = 1;
                Ctx.HV_CT_GENERO.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtGeneroModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_GENERO.Where(x => x.ESTADO == 1).Select(a => new HvCtGeneroModel
            {
                ID_GENERO = a.ID_GENERO,
                NOMBRE = a.NOMBRE,
                

            });

            return lista.ToList();
        }

        public HvCtGeneroModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            HV_CT_GENERO a = Ctx.HV_CT_GENERO.Where(w => w.ID_GENERO == id).Select(s => s).FirstOrDefault();
            HvCtGeneroModel b = new HvCtGeneroModel();
            b.ID_GENERO = a.ID_GENERO;
            b.NOMBRE = a.NOMBRE;
            
            return b;
        }

        public HvCtGeneroModel Actualizar(HvCtGeneroModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_GENERO.Where(s => s.ID_GENERO == a.ID_GENERO).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.ID_GENERO = a.ID_GENERO;
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
                var ResCtx = Ctx.HV_CT_GENERO.Where(s => s.ID_GENERO == id).FirstOrDefault();
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