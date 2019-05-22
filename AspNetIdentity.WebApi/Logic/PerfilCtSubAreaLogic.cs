using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtSubAreaLogic
    {
        
        PERFIL_CT_SUB_AREA ModCtx = new PERFIL_CT_SUB_AREA();

        public PerfilCtSubAreaModel Crear(PerfilCtSubAreaModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                PERFIL_CT_SUB_AREA Nuevo = new PERFIL_CT_SUB_AREA
                {
                    ID_CT_SUB_AREA = a.ID_CT_SUB_AREA,
                    ID_CT_AREA = a.ID_CT_AREA,
                    DESCRIPCION = a.DESCRIPCION,
                    ESTADO = 1 
                };
                Ctx.PERFIL_CT_SUB_AREA.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtSubAreaModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_SUB_AREA
                .Join(Ctx.PERFIL_CT_AREA, b => b.ID_CT_AREA, c => c.ID_CT_AREA, (b, c) =>
                 new { b.ID_CT_AREA,b.ID_CT_SUB_AREA,b.ESTADO,b.DESCRIPCION,NombreArea = c.DESCRIPCION})
                .Where(e => e.ESTADO == 1).Select(a => new PerfilCtSubAreaModel
            {
                ID_CT_SUB_AREA = a.ID_CT_SUB_AREA,
                ID_CT_AREA = a.ID_CT_AREA,
                DESCRIPCION = a.DESCRIPCION,
                NombreArea = a.NombreArea,
                });

            return lista.ToList();
        }

        public List<PerfilCtSubAreaModel> ConsultarIdP(string IdP)
        {
            int Idpa = Convert.ToInt32(IdP);
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_SUB_AREA
                .Join(Ctx.PERFIL_CT_AREA, b => b.ID_CT_AREA, c => c.ID_CT_AREA, (b, c) =>
                 new { b.ID_CT_AREA, b.ID_CT_SUB_AREA, b.ESTADO, b.DESCRIPCION, NombreArea = c.DESCRIPCION })
                .Where(w => w.ID_CT_AREA == Idpa).Select(a => new PerfilCtSubAreaModel //
            {
                ID_CT_SUB_AREA = a.ID_CT_SUB_AREA,
                ID_CT_AREA = a.ID_CT_AREA,
                DESCRIPCION = a.DESCRIPCION,
                NombreArea = a.NombreArea,
                });

            return lista.ToList();
        }

        public PerfilCtSubAreaModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.PERFIL_CT_SUB_AREA
                .Join(Ctx.PERFIL_CT_AREA, b => b.ID_CT_AREA, c => c.ID_CT_AREA, (b, c) =>
                 new { b.ID_CT_AREA, b.ID_CT_SUB_AREA, b.ESTADO, b.DESCRIPCION, NombreArea = c.DESCRIPCION })
                .Where(w => w.ID_CT_SUB_AREA == id).Select(s => s).FirstOrDefault();
            PerfilCtSubAreaModel res = new PerfilCtSubAreaModel();
            res.ID_CT_SUB_AREA = a.ID_CT_SUB_AREA;
            res.ID_CT_AREA = a.ID_CT_AREA;
            res.DESCRIPCION = a.DESCRIPCION;
            res.NombreArea = a.NombreArea;

            return res;
        }

        public PerfilCtSubAreaModel Actualizar(PerfilCtSubAreaModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_SUB_AREA.Where(s => s.ID_CT_SUB_AREA == a.ID_CT_SUB_AREA).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_CT_SUB_AREA = a.ID_CT_SUB_AREA;
                    ResCtx.ID_CT_AREA = a.ID_CT_AREA;
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_SUB_AREA.Where(s => s.ID_CT_SUB_AREA == id).FirstOrDefault();
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