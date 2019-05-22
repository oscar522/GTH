using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using AspNetIdentity.WebClientAdmin.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class HvDatosBasicosController : BaseController
    {
        private EmployeeProvider _employeeProvider;

        EmployeeProvider employeeProvider
        {
            get
            {
                if (_employeeProvider == null)
                {
                    _employeeProvider = new EmployeeProvider(bearerToken);
                }
                return _employeeProvider;
            }
            set
            {
                _employeeProvider = value;
            }
        }

        public async Task<ActionResult> ListDepto()
        {
            string Id = "0";
            string Controller = "hvctDepto";
            string Method = "gethvctDepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());
        }

        public async Task<ActionResult> ListGenero()
        {
            string Id = "0";
            string Controller = "hvctgenero";
            string Method = "gethvctgenero";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtGeneroModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtGeneroModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_GENERO.ToString() }).ToList());
        }

        public async Task<ActionResult> ListDeptoId(string IdP)
        {
            string Id = "0";
            string Controller = "hvctDepto";
            string Method = "gethvctdepto";
            string result = await employeeProvider.Get(IdP, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtDeptoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());

        }

        public async Task<ActionResult> ListPais()
        {
            string Id = "0";
            string Controller = "hvctpais";
            string Method = "gethvctpais";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtPaisModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_PAIS.ToString() }).ToList());
        }

        public async Task<ActionResult> ListCiudadId(string IdP)
        {
            string Id = IdP.ToString();
            string Controller = "hvctciudad";
            string Method = "gethvctciudad";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtCiudadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtCiudadModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_CIUDAD.ToString() }).ToList());
        }

        public async Task<ActionResult> ListEstadoCivil()
        {
            string Id = "0";
            string Controller = "hvctestadocivil";
            string Method = "gethvctestadocivil";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtEstadoCivilModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtEstadoCivilModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_ESTADO_CIVIL.ToString() }).ToList());
        }

        public async Task<ActionResult> ListTipoIdentificacion()
        {
            string Id = "0";
            string Controller = "hvcttipoidentificacion";
            string Method = "gethvcttipoidentificacion";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtTipoIdentificacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtTipoIdentificacionModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_TIPO_IDENTIFICACION.ToString() }).ToList());
        }

        public async Task<ActionResult> ListUserData() {
            string Id = GetTokenObject().nameid;
            string Controller = "userdata";
            string Method = "getuserdataid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            UserDataModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDataModel>(jsonResult.ToString());
            return Json(processModel);
        }

        public async Task<ActionResult> ListUserProgress(Int32 id)
        {
            string Id = id.ToString();
            string Controller = "userdata";
            string Method = "progreso";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            Int16  processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Int16>(jsonResult.ToString());
            return Json(processModel);
        }

        public async Task<ActionResult> ListPerfil()
        {
            string Id = "0";
            string Controller = "perfil";
            string Method = "getperfil";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_PERFIL.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {
            string Ids = GetTokenObject().nameid;
            string Id = "0";
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<UserDataModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDataModel>>(jsonResult.ToString());
            List<UserDataModel> model = new List<UserDataModel>();
            
            string Controller2 = "userdata";
            string Method2 = "progresoIndex";
            foreach (UserDataModel a in processModel) {

                string Idd = a.Id.ToString();
                string result2 = await employeeProvider.Get(Idd, Controller2, Method2);
                var jsonResult2 = Newtonsoft.Json.JsonConvert.DeserializeObject(result2);
                Int16 processModel2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Int16>(jsonResult2.ToString());
                a.Completed = processModel2;
                
                string Controller3 = "hvdatosbasicos";
                string Method3 = "gethvdatosbasicosidpersona";
                string result3 = await employeeProvider.Get(Idd, Controller3, Method3);
                var jsonResult3 = Newtonsoft.Json.JsonConvert.DeserializeObject(result3);
                HvDatosBasicosModel processModel3 = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult3.ToString());

                if (processModel3.ID_DATOS_BASICOS != 0) {
                    a.Existe = 1;
                }
                model.Add(a);
            }

            return View(model);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(HvDatosBasicosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvdatosbasicos";
            string Method = "hvdatosbasicoscreate";
            HvDatosBasicosModel processModel = new HvDatosBasicosModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
                    if (processModel.ID_DATOS_BASICOS.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(processModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(processModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(processModel);
            }
            return RedirectToAction("Edit", new { IdTable = processModel.ID_DATOS_BASICOS });
        }

        public async Task<ActionResult> EditPersona(int IdTable)
        {

            string nameid = GetTokenObject().nameid;
            string role = GetTokenObject().role;
            string Id = "";
            UserDataModel processModel2 = new UserDataModel();

            if (role.Equals("User"))
            {
                string Controller2 = "userdata";
                string Method2 = "getuserdataid";
                string result2 = await employeeProvider.Get(nameid, Controller2, Method2);
                var jsonResult2 = Newtonsoft.Json.JsonConvert.DeserializeObject(result2);
                processModel2 = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDataModel>(jsonResult2.ToString());
                Id = processModel2.Id.ToString();
            }
            else {
                Id = IdTable.ToString();
            }
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosidpersona";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvDatosBasicosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
            if (processModel.ID_DATOS_BASICOS == 0) {
                return RedirectToAction("Crear");
            } else {
                return View("Edit", processModel);
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditPersona(HvDatosBasicosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvdatosbasicos";
            string Method = "hvdatosbasicosupdatepersona";
            HvDatosBasicosModel processModel = new HvDatosBasicosModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
                    if (processModel.APELLIDOS.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(processModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(processModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(processModel);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvDatosBasicosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(HvDatosBasicosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvdatosbasicos";
            string Method = "hvdatosbasicosupdate";
            HvDatosBasicosModel processModel = new HvDatosBasicosModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
                    if (processModel.APELLIDOS.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(processModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(processModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(processModel);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Detail(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvDatosBasicosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> DetailPersona(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosidpersona";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvDatosBasicosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> DeletePersona(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosidpersona";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvDatosBasicosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> DeletePersona(HvDatosBasicosModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosdeletepersona";
            string result = await employeeProvider.Delete(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var processModel = (jsonResult.ToString());
            if (processModel.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return Json(ModelState);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvDatosBasicosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvDatosBasicosModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(HvDatosBasicosModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "hvdatosbasicos";
            string Method = "gethvdatosbasicosdelete";
            string result = await employeeProvider.Delete(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var processModel = (jsonResult.ToString());
            if (processModel.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return Json(ModelState);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}