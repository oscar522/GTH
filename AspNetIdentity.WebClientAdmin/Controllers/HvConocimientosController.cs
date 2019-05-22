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
    public class HvConocimientosController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListCtConocientos()
        {
            string Id = "0";
            string Controller = "hvctconocimientos";
            string Method = "gethvctconocimientos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtConocimientosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtConocimientosModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_CONOCIMIENTOS.ToString() }).ToList());
        }

        public async Task<ActionResult> Index(int IdP)
        {
            string Id = IdP.ToString();
            string Controller = "hvconocimientos";
            string Method = "gethvconocimientosidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvConocimientosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvConocimientosModel>>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public ActionResult Crear(int IdTable)
        {
            HvConocimientosModel ObjData = new HvConocimientosModel();
            ObjData.ID_DATOS_BASICOS = IdTable;
            return PartialView(ObjData);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(HvConocimientosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvconocimientos";
            string Method = "hvconocimientoscreate";
            HvConocimientosModel processModel = new HvConocimientosModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvConocimientosModel>(jsonResult.ToString());
                    if (processModel.ID_CT_CONOCIMIENTOS.Equals(""))
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
            return RedirectToAction("../HvDatosBasicos/Detail", new { IdTable = processModel.ID_DATOS_BASICOS });
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvconocimientos";
            string Method = "gethvconocimientosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvConocimientosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvConocimientosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> EditJson(HvConocimientosModel ObjData)
        {
            string Id = "0";
            string Controller = "hvconocimientos";
            string Method = "hvconocimientosupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvConocimientosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvConocimientosModel>(jsonResult.ToString());
                    if (processModel.ID_CONOCIMIENTOS.Equals(""))
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

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvconocimientos";
            string Method = "gethvconocimientosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvConocimientosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvConocimientosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvconocimientos";
            string Method = "gethvconocimientosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvConocimientosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvConocimientosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]

        public async Task<ActionResult> Delete(HvConocimientosModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvconocimientos";
            string Method = "gethvconocimientosdelete";
            string result = await employeeProvider.Delete(Controller, Method, Id);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var processModel = (jsonResult.ToString());
            if (processModel.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return Json(ModelState);
            }
            else
            {
                return RedirectToAction("../HvDatosBasicos/Detail", new { IdTable = processModel });
            }
        }
    }
}