using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebApi.Logic
{
    public class PerfilCtAreLogic
    {

        PERFIL_CT_AREA ModCtx = new PERFIL_CT_AREA();

        public PerfilCtAreaModel Crear(PerfilCtAreaModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities ())
            {
                PERFIL_CT_AREA Nuevo = new PERFIL_CT_AREA
                {
                    DESCRIPCION = a.DESCRIPCION,
                    ESTADO = 1
                };
                Ctx.PERFIL_CT_AREA.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<PerfilCtAreaModel> Consulta()
        {
            AspNetIdentityEntities Ctx  = new AspNetIdentityEntities();
            var lista = Ctx.PERFIL_CT_AREA.Where(e => e.ESTADO == 1).Select(a => new PerfilCtAreaModel
            {   
                ID_CT_AREA = a.ID_CT_AREA,
                DESCRIPCION = a.DESCRIPCION,
            });
            return lista.ToList();
        }

        public PerfilCtAreaModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx  = new AspNetIdentityEntities ();
            PERFIL_CT_AREA Found = Ctx.PERFIL_CT_AREA.Where(w => w.ID_CT_AREA == id).Select(s => s).FirstOrDefault();
            PerfilCtAreaModel Area = new PerfilCtAreaModel();
            Area.ID_CT_AREA = Found.ID_CT_AREA;
            Area.DESCRIPCION = Found.DESCRIPCION;
            return Area;
        }

        public PerfilCtAreaModel Actualizar(PerfilCtAreaModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.PERFIL_CT_AREA.Where(s => s.ID_CT_AREA == a.ID_CT_AREA).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities ())
            {
                var ResCtx = Ctx.PERFIL_CT_AREA.Where(s => s.ID_CT_AREA == id).FirstOrDefault();
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