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
    public class HvEstudiosController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListCtInstituciones()
        {
            string Id = "0";
            string Controller = "hvctinstituciones";
            string Method = "gethvctinstituciones";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtInstitucionesModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtInstitucionesModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_INSTITUCION.ToString() }).ToList());
        }

        public async Task<ActionResult> ListCtTitulos()
        {
            string Id = "0";
            string Controller = "hvcttitulos";
            string Method = "gethvcttitulos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtTitulosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtTitulosModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_TITULOS.ToString() }).ToList());
           
        }

        public async Task<ActionResult> ListCtDisiplina()
        {
            string Id = "0";
            string Controller = "hvctdisiplina";
            string Method = "gethvctdisiplina";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtDisiplinaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtDisiplinaModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DISIPLINA.ToString() }).ToList());
        }

        public async Task<ActionResult> Index(int IdP)
        {
            string Id = IdP.ToString();
            string Controller = "hvestudios";
            string Method = "gethvestudiosidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvEstudiosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvEstudiosModel>>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public ActionResult Crear(int IdTable)
        {
            HvEstudiosModel ObjData = new HvEstudiosModel();
            ObjData.ID_DATOS_BASICOS = IdTable;
            return PartialView(ObjData);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(HvEstudiosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvestudios";
            string Method = "hvestudioscreate";
            HvEstudiosModel processModel = new HvEstudiosModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvEstudiosModel>(jsonResult.ToString());
                    if (processModel.ID_DATOS_BASICOS.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        View(processModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    View(processModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                View(processModel);
            }
            return RedirectToAction("../HvDatosBasicos/Detail", new { IdTable = processModel.ID_DATOS_BASICOS });// ----------- //
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvestudios";
            string Method = "gethvestudiosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvEstudiosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvEstudiosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> EditJson(HvEstudiosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvestudios";
            string Method = "hvestudiosupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvEstudiosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvEstudiosModel>(jsonResult.ToString());
                    if (processModel.ID_ESTUDIOS.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        return Json("OK");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return Json(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                var errorList = (from item in ModelState
                                 from error in item.Value.Errors
                                 select new
                                 {
                                     Msg = error.ErrorMessage,
                                     Cam = item.Key
                                 }
                    ).ToList();
                return Json(errorList);
            }
        }

        public async Task<ActionResult> Detail(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvestudios";
            string Method = "gethvestudiosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvEstudiosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvEstudiosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvestudios";
            string Method = "gethvestudiosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvEstudiosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvEstudiosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]

        public async Task<ActionResult> Delete(HvEstudiosModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvestudios";
            string Method = "gethvestudiosdelete";
            string result = await employeeProvider.Delete( Controller, Method,Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var processModel = (jsonResult.ToString());
            if (processModel.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return Json(ModelState);
            }
            else
            {
                return RedirectToAction("../HvDatosBasicos/Detail", new { IdTable = processModel });// ----------- //
            }
        }
    }
}