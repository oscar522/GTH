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
    public class PerfilCtSubAreaController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListArea()
        {
            string Id = "0";
            string Controller = "perfilctarea";
            string Method = "getperfilctarea";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilCtAreaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilCtAreaModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.DESCRIPCION, Value = x.ID_CT_AREA.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubarea";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilCtSubAreaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilCtSubAreaModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(PerfilCtSubAreaModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilctsubarea";
            string Method = "perfilctsubareacreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    PerfilCtSubAreaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilCtSubAreaModel>(jsonResult.ToString());
                    if (processModel.DESCRIPCION.Equals(""))
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
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubareaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilCtSubAreaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilCtSubAreaModel>(jsonResult.ToString());

            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(PerfilCtSubAreaModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilctsubarea";
            string Method = "perfilctsubareaupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    PerfilCtSubAreaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilCtSubAreaModel>(jsonResult.ToString());
                    if (processModel.DESCRIPCION.Equals(""))
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
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubareaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilCtSubAreaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilCtSubAreaModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubareaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilCtSubAreaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilCtSubAreaModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(PerfilCtSubAreaModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubareadelete";
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