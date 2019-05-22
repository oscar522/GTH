using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebApi.Logic
{
    public class HvCtDeptoLogic
    {
        
        HV_CT_DEPTO ModCtx = new HV_CT_DEPTO();

        public HvCtDeptoModel Crear(HvCtDeptoModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_CT_DEPTO Nuevo = new HV_CT_DEPTO
                {
                       ID_CT_DEPTO = a.ID_CT_DEPTO,
                       ID_CT_PAIS = a.ID_CT_PAIS,
                       ESTADO = 1,
                       NOMBRE = a.NOMBRE
                    };
               
                Ctx.HV_CT_DEPTO.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<HvCtDeptoModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_DEPTO
                 .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO,b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE,  })
                 .Where(a => a.ESTADO == 1)
                .Select(a => new HvCtDeptoModel
            {
                ID_CT_DEPTO = a.ID_CT_DEPTO,
                ID_CT_PAIS = a.ID_CT_PAIS,
                NOMBRE_PAIS = a.NombrePais,
                NOMBRE = a.NOMBRE

            });

            return lista.ToList();
        }

        public HvCtDeptoModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_CT_DEPTO
                 .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ESTADO, b.ID_CT_DEPTO, b.ID_CT_PAIS, b.NOMBRE, NombrePais = c.NOMBRE, })
                 .Where(g => g.ESTADO == 1)
                .Where(w => w.ID_CT_DEPTO == id).Select(s => s).FirstOrDefault();
            HvCtDeptoModel x = new HvCtDeptoModel();
            x.ID_CT_DEPTO = a.ID_CT_DEPTO;
            x.ID_CT_PAIS = a.ID_CT_PAIS;
            x.NOMBRE_PAIS = a.NombrePais;
            x.NOMBRE = a.NOMBRE;
            return x;
        }
        public List<HvCtDeptoModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_CT_DEPTO.Where(w => w.ID_CT_PAIS == Idpa).Select(a => new HvCtDeptoModel //
            {
                ID_CT_DEPTO = a.ID_CT_DEPTO,
                ID_CT_PAIS = a.ID_CT_PAIS,
                NOMBRE = a.NOMBRE
            });

            return lista.ToList();
        }

        public HvCtDeptoModel Actualizar(HvCtDeptoModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_CT_DEPTO.Where(s => s.ID_CT_DEPTO == a.ID_CT_DEPTO).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;
                    
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
                var ResCtx = Ctx.HV_CT_DEPTO.Where(s => s.ID_CT_DEPTO == id).Where(s => s.ESTADO == 1).FirstOrDefault();
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