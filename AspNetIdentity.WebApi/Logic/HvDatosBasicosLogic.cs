using AspNetIdentity.Models;
using AspNetIdentity.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AspNetIdentity.WebApi.Logic
{
    public class HvDatosBasicosLogic
    {

        HV_DATOS_BASICOS ModCtx = new HV_DATOS_BASICOS();

        public HvDatosBasicosModel Crear(HvDatosBasicosModel a)
        {
            using (AspNetIdentityEntities Ctx = new AspNetIdentityEntities())
            {
                HV_DATOS_BASICOS Nuevo = new HV_DATOS_BASICOS
                {

                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,
                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    ID_CT_PAIS = a.ID_CT_PAIS,
                    ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL,
                    ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION,
                    NOMBRES = a.NOMBRES,
                    APELLIDOS = a.APELLIDOS,
                    IDENTIFICACION = a.IDENTIFICACION,
                    F_NACIMIENTO = a.F_NACIMIENTO,
                    GENERO = a.GENERO,
                    DIRECCION = "NA",
                    DESCRIPCION = a.DESCRIPCION,
                    ESTADO = 1,
                    ID_USERS = a.ID_USERS,
                    ID_PERFIL = a.ID_PERFIL
                };
                Ctx.HV_DATOS_BASICOS.Add(Nuevo);
                Ctx.SaveChanges();
                a.ID_DATOS_BASICOS = Nuevo.ID_DATOS_BASICOS;
                return a;
            }
        }

        public List<HvDatosBasicosModel> Consulta()
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.HV_DATOS_BASICOS
                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ID_USERS, b.ID_PERFIL, b.ESTADO, b.ID_DATOS_BASICOS, b.ID_CT_PAIS, b.ID_CT_DEPTO, b.ID_CT_CIUDAD, b.ID_CT_ESTADO_CIVIL, b.ID_CT_TIPO_IDENTIFICACION, b.NOMBRES, b.APELLIDOS, b.IDENTIFICACION, b.F_NACIMIENTO, b.GENERO, b.DIRECCION, b.DESCRIPCION, NombrePais = c.NOMBRE })

                .Join(Ctx.HV_CT_DEPTO, d => d.ID_CT_DEPTO, e => e.ID_CT_DEPTO, (d, e) =>
                 new { d.ID_USERS, d.ID_PERFIL, d.ESTADO, d.ID_DATOS_BASICOS, d.ID_CT_PAIS, d.ID_CT_DEPTO, d.ID_CT_CIUDAD, d.ID_CT_ESTADO_CIVIL, d.ID_CT_TIPO_IDENTIFICACION, d.NOMBRES, d.APELLIDOS, d.IDENTIFICACION, d.F_NACIMIENTO, d.GENERO, d.DIRECCION, d.DESCRIPCION, NombreDepto = e.NOMBRE, d.NombrePais })

                .Join(Ctx.HV_CT_CIUDAD, f => f.ID_CT_CIUDAD, g => g.ID_CT_CIUDAD, (f, g) =>
                 new { f.ID_USERS, f.ID_PERFIL, f.ESTADO, f.ID_DATOS_BASICOS, f.ID_CT_PAIS, f.ID_CT_DEPTO, f.ID_CT_CIUDAD, f.ID_CT_ESTADO_CIVIL, f.ID_CT_TIPO_IDENTIFICACION, f.NOMBRES, f.APELLIDOS, f.IDENTIFICACION, f.F_NACIMIENTO, f.GENERO, f.DIRECCION, f.DESCRIPCION, NombreCiudad = g.NOMBRE, f.NombrePais, f.NombreDepto })

                 .Join(Ctx.HV_CT_ESTADO_CIVIL, h => h.ID_CT_ESTADO_CIVIL, i => i.ID_CT_ESTADO_CIVIL, (h, i) =>
                 new { h.ID_USERS, h.ID_PERFIL, h.ESTADO, h.ID_DATOS_BASICOS, h.ID_CT_PAIS, h.ID_CT_DEPTO, h.ID_CT_CIUDAD, h.ID_CT_ESTADO_CIVIL, h.ID_CT_TIPO_IDENTIFICACION, h.NOMBRES, h.APELLIDOS, h.IDENTIFICACION, h.F_NACIMIENTO, h.GENERO, h.DIRECCION, h.DESCRIPCION, NombreEstado = i.NOMBRE, h.NombrePais, h.NombreDepto, h.NombreCiudad })

                 .Join(Ctx.HV_CT_TIPO_IDENTIFICACION, j => j.ID_CT_TIPO_IDENTIFICACION, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new { j.ID_USERS, j.ID_PERFIL, j.ESTADO, j.ID_DATOS_BASICOS, j.ID_CT_PAIS, j.ID_CT_DEPTO, j.ID_CT_CIUDAD, j.ID_CT_ESTADO_CIVIL, j.ID_CT_TIPO_IDENTIFICACION, j.NOMBRES, j.APELLIDOS, j.IDENTIFICACION, j.F_NACIMIENTO, j.GENERO, j.DIRECCION, j.DESCRIPCION, NombreTipo = k.NOMBRE, j.NombrePais, j.NombreDepto, j.NombreCiudad, j.NombreEstado })

                 .Join(Ctx.HV_CT_GENERO, l => l.GENERO, m => m.ID_GENERO, (l, m) =>
                 new { l.ID_USERS, l.ID_PERFIL, l.ESTADO, l.ID_DATOS_BASICOS, l.ID_CT_PAIS, l.ID_CT_DEPTO, l.ID_CT_CIUDAD, l.ID_CT_ESTADO_CIVIL, l.ID_CT_TIPO_IDENTIFICACION, l.NOMBRES, l.APELLIDOS, l.IDENTIFICACION, l.F_NACIMIENTO, l.GENERO, l.DIRECCION, l.DESCRIPCION, l.NombreTipo, l.NombrePais, l.NombreDepto, l.NombreCiudad, l.NombreEstado, NombreGenero = m.NOMBRE, m.ID_GENERO })

                 .Join(Ctx.PERFIL, n => n.ID_PERFIL, o => o.ID_PERFIL, (n, o) =>
                 new { n.ID_USERS, n.ESTADO, n.ID_DATOS_BASICOS, n.ID_CT_PAIS, n.ID_CT_DEPTO, n.ID_CT_CIUDAD, n.ID_CT_ESTADO_CIVIL, n.ID_CT_TIPO_IDENTIFICACION, n.NOMBRES, n.APELLIDOS, n.IDENTIFICACION, n.F_NACIMIENTO, n.GENERO, n.DIRECCION, n.DESCRIPCION, n.NombreTipo, n.NombrePais, n.NombreDepto, n.NombreCiudad, n.NombreEstado, n.NombreGenero, n.ID_GENERO, NombrePerfil = o.NOMBRE, o.ID_PERFIL })

                 .Join(Ctx.Users, p => p.ID_USERS, q => q.Id_User, (p, q) =>
                 new { p.ID_USERS, p.ESTADO, p.ID_DATOS_BASICOS, p.ID_CT_PAIS, p.ID_CT_DEPTO, p.ID_CT_CIUDAD, p.ID_CT_ESTADO_CIVIL, p.ID_CT_TIPO_IDENTIFICACION, p.NOMBRES, p.APELLIDOS, p.IDENTIFICACION, p.F_NACIMIENTO, p.GENERO, p.DIRECCION, p.DESCRIPCION, p.NombreTipo, p.NombrePais, p.NombreDepto, p.NombreCiudad, p.NombreEstado, p.NombreGenero, p.ID_GENERO, p.NombrePerfil, p.ID_PERFIL, Imagen = q.ImageName })


                 .Where(e => e.ESTADO == 1)
                .Select(a => new HvDatosBasicosModel
                {

                    ID_DATOS_BASICOS = a.ID_DATOS_BASICOS,

                    ID_CT_PAIS = a.ID_CT_PAIS,
                    NOMBRE_PAIS = a.NombrePais,

                    ID_CT_DEPTO = a.ID_CT_DEPTO,
                    NOMBRE_DEPTO = a.NombreDepto,

                    ID_CT_CIUDAD = a.ID_CT_CIUDAD,
                    NOMBRE_CIUDAD = a.NombreCiudad,

                    ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL,
                    NOMBRE_ESTADO_CIVIL = a.NombreEstado,

                    ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION,
                    NOMBRE_TIPO_IDENTIFICACION = a.NombreTipo,

                    NOMBRES = a.NOMBRES,
                    APELLIDOS = a.APELLIDOS,
                    IDENTIFICACION = a.IDENTIFICACION,
                    F_NACIMIENTO = a.F_NACIMIENTO,

                    GENERO = a.ID_GENERO,
                    NOMBRE_GENERO = a.NombreGenero,

                    DIRECCION = a.DIRECCION,
                    DESCRIPCION = a.DESCRIPCION,

                    ID_PERFIL = a.ID_PERFIL,
                    NOMBRE_PERFIL = a.NombrePerfil,
                    IMAGE_NAME = a.Imagen

                });

            return lista.ToList();
        }

        public List<UserDataModel> Consulta2()
        {
            UserDataModel model = new UserDataModel();
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var lista = Ctx.Users
                .Select(a => new UserDataModel
                {
                    Id = a.Id_User,
                    Name = a.Name,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Image = a.ImageName,
                    Active = a.Active,
                });


            

            return lista.ToList();
        }

        public HvDatosBasicosModel ConsultarId(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_DATOS_BASICOS
                
                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ID_USERS, b.ID_PERFIL, b.ESTADO, b.ID_DATOS_BASICOS, b.ID_CT_PAIS, b.ID_CT_DEPTO, b.ID_CT_CIUDAD, b.ID_CT_ESTADO_CIVIL, b.ID_CT_TIPO_IDENTIFICACION, b.NOMBRES, b.APELLIDOS, b.IDENTIFICACION, b.F_NACIMIENTO, b.GENERO, b.DIRECCION, b.DESCRIPCION, NombrePais = c.NOMBRE })

                .Join(Ctx.HV_CT_DEPTO, d => d.ID_CT_DEPTO, e => e.ID_CT_DEPTO, (d, e) =>
                 new { d.ID_USERS, d.ID_PERFIL, d.ESTADO, d.ID_DATOS_BASICOS, d.ID_CT_PAIS, d.ID_CT_DEPTO, d.ID_CT_CIUDAD, d.ID_CT_ESTADO_CIVIL, d.ID_CT_TIPO_IDENTIFICACION, d.NOMBRES, d.APELLIDOS, d.IDENTIFICACION, d.F_NACIMIENTO, d.GENERO, d.DIRECCION, d.DESCRIPCION, NombreDepto = e.NOMBRE, d.NombrePais })

                .Join(Ctx.HV_CT_CIUDAD, f => f.ID_CT_CIUDAD, g => g.ID_CT_CIUDAD, (f, g) =>
                 new { f.ID_USERS, f.ID_PERFIL, f.ESTADO, f.ID_DATOS_BASICOS, f.ID_CT_PAIS, f.ID_CT_DEPTO, f.ID_CT_CIUDAD, f.ID_CT_ESTADO_CIVIL, f.ID_CT_TIPO_IDENTIFICACION, f.NOMBRES, f.APELLIDOS, f.IDENTIFICACION, f.F_NACIMIENTO, f.GENERO, f.DIRECCION, f.DESCRIPCION, NombreCiudad = g.NOMBRE, f.NombrePais, f.NombreDepto })

                 .Join(Ctx.HV_CT_ESTADO_CIVIL, h => h.ID_CT_ESTADO_CIVIL, i => i.ID_CT_ESTADO_CIVIL, (h, i) =>
                 new { h.ID_USERS, h.ID_PERFIL, h.ESTADO, h.ID_DATOS_BASICOS, h.ID_CT_PAIS, h.ID_CT_DEPTO, h.ID_CT_CIUDAD, h.ID_CT_ESTADO_CIVIL, h.ID_CT_TIPO_IDENTIFICACION, h.NOMBRES, h.APELLIDOS, h.IDENTIFICACION, h.F_NACIMIENTO, h.GENERO, h.DIRECCION, h.DESCRIPCION, NombreEstado = i.NOMBRE, h.NombrePais, h.NombreDepto, h.NombreCiudad })

                 .Join(Ctx.HV_CT_TIPO_IDENTIFICACION, j => j.ID_CT_TIPO_IDENTIFICACION, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new { j.ID_USERS, j.ID_PERFIL, j.ESTADO, j.ID_DATOS_BASICOS, j.ID_CT_PAIS, j.ID_CT_DEPTO, j.ID_CT_CIUDAD, j.ID_CT_ESTADO_CIVIL, j.ID_CT_TIPO_IDENTIFICACION, j.NOMBRES, j.APELLIDOS, j.IDENTIFICACION, j.F_NACIMIENTO, j.GENERO, j.DIRECCION, j.DESCRIPCION, NombreTipo = k.NOMBRE, j.NombrePais, j.NombreDepto, j.NombreCiudad, j.NombreEstado })

                 .Join(Ctx.HV_CT_GENERO, l => l.GENERO, m => m.ID_GENERO, (l, m) =>
                 new { l.ID_USERS, l.ID_PERFIL, l.ESTADO, l.ID_DATOS_BASICOS, l.ID_CT_PAIS, l.ID_CT_DEPTO, l.ID_CT_CIUDAD, l.ID_CT_ESTADO_CIVIL, l.ID_CT_TIPO_IDENTIFICACION, l.NOMBRES, l.APELLIDOS, l.IDENTIFICACION, l.F_NACIMIENTO, l.GENERO, l.DIRECCION, l.DESCRIPCION, l.NombreTipo, l.NombrePais, l.NombreDepto, l.NombreCiudad, l.NombreEstado, NombreGenero = m.NOMBRE, m.ID_GENERO })

                 .Join(Ctx.PERFIL, n => n.ID_PERFIL, o => o.ID_PERFIL, (n, o) =>
                 new { n.ID_USERS, n.ESTADO, n.ID_DATOS_BASICOS, n.ID_CT_PAIS, n.ID_CT_DEPTO, n.ID_CT_CIUDAD, n.ID_CT_ESTADO_CIVIL, n.ID_CT_TIPO_IDENTIFICACION, n.NOMBRES, n.APELLIDOS, n.IDENTIFICACION, n.F_NACIMIENTO, n.GENERO, n.DIRECCION, n.DESCRIPCION, n.NombreTipo, n.NombrePais, n.NombreDepto, n.NombreCiudad, n.NombreEstado, n.NombreGenero, n.ID_GENERO, NombrePerfil = o.NOMBRE, o.ID_PERFIL })

                 .Join(Ctx.Users, p => p.ID_USERS, q => q.Id_User, (p, q) =>
                 new { p.ID_USERS, p.ESTADO, p.ID_DATOS_BASICOS, p.ID_CT_PAIS, p.ID_CT_DEPTO, p.ID_CT_CIUDAD, p.ID_CT_ESTADO_CIVIL, p.ID_CT_TIPO_IDENTIFICACION, p.NOMBRES, p.APELLIDOS, p.IDENTIFICACION, p.F_NACIMIENTO, p.GENERO, p.DIRECCION, p.DESCRIPCION, p.NombreTipo, p.NombrePais, p.NombreDepto, p.NombreCiudad, p.NombreEstado, p.NombreGenero, p.ID_GENERO, p.NombrePerfil, p.ID_PERFIL, Imagen = q.ImageName })


                //.Where(e => e.ESTADO == 1)

                .Where(w => w.ID_DATOS_BASICOS == id).Select(s => s).FirstOrDefault();
            HvDatosBasicosModel z = new HvDatosBasicosModel();

            z.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
            z.ID_CT_PAIS = a.ID_CT_PAIS;
            z.NOMBRE_PAIS = a.NombrePais;
            z.ID_CT_DEPTO = a.ID_CT_DEPTO;
            z.NOMBRE_DEPTO = a.NombreDepto;
            z.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
            z.NOMBRE_CIUDAD = a.NombreCiudad;
            z.ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL;
            z.NOMBRE_ESTADO_CIVIL = a.NombreEstado;
            z.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
            z.NOMBRE_TIPO_IDENTIFICACION = a.NombreTipo;
            z.NOMBRES = a.NOMBRES;
            z.APELLIDOS = a.APELLIDOS;
            z.IDENTIFICACION = a.IDENTIFICACION;
            z.F_NACIMIENTO = a.F_NACIMIENTO;
            z.GENERO = a.ID_GENERO;
            z.NOMBRE_GENERO = a.NombreGenero;
            z.DIRECCION = a.DIRECCION;
            z.DESCRIPCION = a.DESCRIPCION;
            z.IMAGE_NAME = a.Imagen;
            z.ID_PERFIL = a.ID_PERFIL;
            z.NOMBRE_PERFIL = a.NombrePerfil;
            return z;
        }

        public HvDatosBasicosModel ConsultarIdPersona(int id)
        {
            AspNetIdentityEntities Ctx = new AspNetIdentityEntities();
            var a = Ctx.HV_DATOS_BASICOS

                .Join(Ctx.HV_CT_PAIS, b => b.ID_CT_PAIS, c => c.ID_CT_PAIS, (b, c) =>
                 new { b.ID_USERS, b.ID_PERFIL, b.ESTADO, b.ID_DATOS_BASICOS, b.ID_CT_PAIS, b.ID_CT_DEPTO, b.ID_CT_CIUDAD, b.ID_CT_ESTADO_CIVIL, b.ID_CT_TIPO_IDENTIFICACION, b.NOMBRES, b.APELLIDOS, b.IDENTIFICACION, b.F_NACIMIENTO, b.GENERO, b.DIRECCION, b.DESCRIPCION, NombrePais = c.NOMBRE })

                .Join(Ctx.HV_CT_DEPTO, d => d.ID_CT_DEPTO, e => e.ID_CT_DEPTO, (d, e) =>
                 new { d.ID_USERS, d.ID_PERFIL, d.ESTADO, d.ID_DATOS_BASICOS, d.ID_CT_PAIS, d.ID_CT_DEPTO, d.ID_CT_CIUDAD, d.ID_CT_ESTADO_CIVIL, d.ID_CT_TIPO_IDENTIFICACION, d.NOMBRES, d.APELLIDOS, d.IDENTIFICACION, d.F_NACIMIENTO, d.GENERO, d.DIRECCION, d.DESCRIPCION, NombreDepto = e.NOMBRE, d.NombrePais })

                .Join(Ctx.HV_CT_CIUDAD, f => f.ID_CT_CIUDAD, g => g.ID_CT_CIUDAD, (f, g) =>
                 new { f.ID_USERS, f.ID_PERFIL, f.ESTADO, f.ID_DATOS_BASICOS, f.ID_CT_PAIS, f.ID_CT_DEPTO, f.ID_CT_CIUDAD, f.ID_CT_ESTADO_CIVIL, f.ID_CT_TIPO_IDENTIFICACION, f.NOMBRES, f.APELLIDOS, f.IDENTIFICACION, f.F_NACIMIENTO, f.GENERO, f.DIRECCION, f.DESCRIPCION, NombreCiudad = g.NOMBRE, f.NombrePais, f.NombreDepto })

                 .Join(Ctx.HV_CT_ESTADO_CIVIL, h => h.ID_CT_ESTADO_CIVIL, i => i.ID_CT_ESTADO_CIVIL, (h, i) =>
                 new { h.ID_USERS, h.ID_PERFIL, h.ESTADO, h.ID_DATOS_BASICOS, h.ID_CT_PAIS, h.ID_CT_DEPTO, h.ID_CT_CIUDAD, h.ID_CT_ESTADO_CIVIL, h.ID_CT_TIPO_IDENTIFICACION, h.NOMBRES, h.APELLIDOS, h.IDENTIFICACION, h.F_NACIMIENTO, h.GENERO, h.DIRECCION, h.DESCRIPCION, NombreEstado = i.NOMBRE, h.NombrePais, h.NombreDepto, h.NombreCiudad })

                 .Join(Ctx.HV_CT_TIPO_IDENTIFICACION, j => j.ID_CT_TIPO_IDENTIFICACION, k => k.ID_CT_TIPO_IDENTIFICACION, (j, k) =>
                 new { j.ID_USERS, j.ID_PERFIL, j.ESTADO, j.ID_DATOS_BASICOS, j.ID_CT_PAIS, j.ID_CT_DEPTO, j.ID_CT_CIUDAD, j.ID_CT_ESTADO_CIVIL, j.ID_CT_TIPO_IDENTIFICACION, j.NOMBRES, j.APELLIDOS, j.IDENTIFICACION, j.F_NACIMIENTO, j.GENERO, j.DIRECCION, j.DESCRIPCION, NombreTipo = k.NOMBRE, j.NombrePais, j.NombreDepto, j.NombreCiudad, j.NombreEstado })

                 .Join(Ctx.HV_CT_GENERO, l => l.GENERO, m => m.ID_GENERO, (l, m) =>
                 new { l.ID_USERS, l.ID_PERFIL, l.ESTADO, l.ID_DATOS_BASICOS, l.ID_CT_PAIS, l.ID_CT_DEPTO, l.ID_CT_CIUDAD, l.ID_CT_ESTADO_CIVIL, l.ID_CT_TIPO_IDENTIFICACION, l.NOMBRES, l.APELLIDOS, l.IDENTIFICACION, l.F_NACIMIENTO, l.GENERO, l.DIRECCION, l.DESCRIPCION, l.NombreTipo, l.NombrePais, l.NombreDepto, l.NombreCiudad, l.NombreEstado, NombreGenero = m.NOMBRE, m.ID_GENERO })

                 .Join(Ctx.PERFIL, n => n.ID_PERFIL, o => o.ID_PERFIL, (n, o) =>
                 new { n.ID_USERS, n.ESTADO, n.ID_DATOS_BASICOS, n.ID_CT_PAIS, n.ID_CT_DEPTO, n.ID_CT_CIUDAD, n.ID_CT_ESTADO_CIVIL, n.ID_CT_TIPO_IDENTIFICACION, n.NOMBRES, n.APELLIDOS, n.IDENTIFICACION, n.F_NACIMIENTO, n.GENERO, n.DIRECCION, n.DESCRIPCION, n.NombreTipo, n.NombrePais, n.NombreDepto, n.NombreCiudad, n.NombreEstado, n.NombreGenero, n.ID_GENERO, NombrePerfil = o.NOMBRE, o.ID_PERFIL })

                 .Join(Ctx.Users, p => p.ID_USERS, q => q.Id_User, (p, q) =>
                 new { p.ID_USERS, p.ESTADO, p.ID_DATOS_BASICOS, p.ID_CT_PAIS, p.ID_CT_DEPTO, p.ID_CT_CIUDAD, p.ID_CT_ESTADO_CIVIL, p.ID_CT_TIPO_IDENTIFICACION, p.NOMBRES, p.APELLIDOS, p.IDENTIFICACION, p.F_NACIMIENTO, p.GENERO, p.DIRECCION, p.DESCRIPCION, p.NombreTipo, p.NombrePais, p.NombreDepto, p.NombreCiudad, p.NombreEstado, p.NombreGenero, p.ID_GENERO, p.NombrePerfil, p.ID_PERFIL, Imagen = q.ImageName })


                //.Where(e => e.ESTADO == 1)

                .Where(w => w.ID_USERS == id).Select(s => s).FirstOrDefault();
            HvDatosBasicosModel z = new HvDatosBasicosModel();
            if (a != null) {
                z.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                z.ID_CT_PAIS = a.ID_CT_PAIS;
                z.NOMBRE_PAIS = a.NombrePais;
                z.ID_CT_DEPTO = a.ID_CT_DEPTO;
                z.NOMBRE_DEPTO = a.NombreDepto;
                z.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
                z.NOMBRE_CIUDAD = a.NombreCiudad;
                z.ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL;
                z.NOMBRE_ESTADO_CIVIL = a.NombreEstado;
                z.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
                z.NOMBRE_TIPO_IDENTIFICACION = a.NombreTipo;
                z.NOMBRES = a.NOMBRES;
                z.APELLIDOS = a.APELLIDOS;
                z.IDENTIFICACION = a.IDENTIFICACION;
                z.F_NACIMIENTO = a.F_NACIMIENTO;
                z.GENERO = a.ID_GENERO;
                z.NOMBRE_GENERO = a.NombreGenero;
                z.DIRECCION = a.DIRECCION;
                z.DESCRIPCION = a.DESCRIPCION;
                z.IMAGE_NAME = a.Imagen;
                z.ID_PERFIL = a.ID_PERFIL;
                z.NOMBRE_PERFIL = a.NombrePerfil;

            }
         
            return z;
        }

        public HvDatosBasicosModel Actualizar(HvDatosBasicosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_DATOS_BASICOS.Where(s => s.ID_DATOS_BASICOS == a.ID_DATOS_BASICOS).FirstOrDefault();
                if (ResCtx != null)
                {

                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;
                    ResCtx.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
                    ResCtx.ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL;
                    ResCtx.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
                    ResCtx.NOMBRES = a.NOMBRES;
                    ResCtx.APELLIDOS = a.APELLIDOS;
                    ResCtx.IDENTIFICACION = a.IDENTIFICACION;
                    ResCtx.F_NACIMIENTO = a.F_NACIMIENTO;
                    ResCtx.GENERO = a.GENERO;
                    ResCtx.DIRECCION = "NA";
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public HvDatosBasicosModel ActualizarPersona(HvDatosBasicosModel a)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_DATOS_BASICOS.Where(s => s.ID_USERS == a.ID_USERS).FirstOrDefault();
                if (ResCtx != null)
                {
                    ResCtx.ID_DATOS_BASICOS = a.ID_DATOS_BASICOS;
                    ResCtx.ID_CT_DEPTO = a.ID_CT_DEPTO;
                    ResCtx.ID_CT_PAIS = a.ID_CT_PAIS;
                    ResCtx.ID_CT_CIUDAD = a.ID_CT_CIUDAD;
                    ResCtx.ID_CT_ESTADO_CIVIL = a.ID_CT_ESTADO_CIVIL;
                    ResCtx.ID_CT_TIPO_IDENTIFICACION = a.ID_CT_TIPO_IDENTIFICACION;
                    ResCtx.NOMBRES = a.NOMBRES;
                    ResCtx.APELLIDOS = a.APELLIDOS;
                    ResCtx.IDENTIFICACION = a.IDENTIFICACION;
                    ResCtx.F_NACIMIENTO = a.F_NACIMIENTO;
                    ResCtx.GENERO = a.GENERO;
                    ResCtx.DIRECCION = "NA";
                    ResCtx.DESCRIPCION = a.DESCRIPCION;
                    ResCtx.ID_PERFIL = a.ID_PERFIL;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_DATOS_BASICOS.Where(s => s.ID_DATOS_BASICOS == id).FirstOrDefault();
                if (ResCtx != null) // --------------------- //
                {
                    ResCtx.ESTADO = 0;
                    Ctx.SaveChanges();
                }
            }
            return "realizado ";
        }

        public String EliminarPersona(int id)
        {
            using (var Ctx = new AspNetIdentityEntities())
            {
                var ResCtx = Ctx.HV_DATOS_BASICOS.Where(s => s.ID_USERS == id).FirstOrDefault();
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