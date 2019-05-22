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
    public class HvCtEstadoCivilController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "hvctestadocivil";
            string Method = "gethvctestadocivil";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtEstadoCivilModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtEstadoCivilModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvctestadocivil";
            string Method = "gethvctestadocivilid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvCtEstadoCivilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtEstadoCivilModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(HvCtEstadoCivilModel ObjData)
        {
            string Id = "0";
            string Controller = "hvctestadocivil";
            string Method = "hvctestadocivilcreate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvCtEstadoCivilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtEstadoCivilModel>(jsonResult.ToString());
                    if (processModel.NOMBRE.Equals(""))
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

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvctestadocivil";
            string Method = "gethvctestadocivilid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvCtEstadoCivilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtEstadoCivilModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(HvCtEstadoCivilModel ObjData)
        {
            string Id = "0";
            string Controller = "hvctestadocivil";
            string Method = "hvctestadocivilupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvCtEstadoCivilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtEstadoCivilModel>(jsonResult.ToString());
                    if (processModel.NOMBRE.Equals(""))
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

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvctestadocivil";
            string Method = "gethvctestadocivilid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvCtEstadoCivilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtEstadoCivilModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(HvCtEstadoCivilModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvctestadocivil";
            string Method = "gethvctestadocivildelete";
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