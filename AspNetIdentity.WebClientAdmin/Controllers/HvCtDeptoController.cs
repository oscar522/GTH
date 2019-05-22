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
    public class HvCtDeptoController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "hvctdepto";
            string Method = "gethvctdepto";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtDeptoModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> CrearJson(HvCtDeptoModel ObjData)
        {
            string Id = "0";
            string Controller = "hvctdepto";
            string Method = "hvctdeptocreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvCtDeptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtDeptoModel>(jsonResult.ToString());
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
            string Controller = "hvctdepto";
            string Method = "gethvctdeptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvCtDeptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtDeptoModel>(jsonResult.ToString());
           
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(HvCtDeptoModel ObjData)
        {
            string Id = "0";
            string Controller = "hvctdepto";
            string Method = "hvctdeptoupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvCtDeptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtDeptoModel>(jsonResult.ToString());
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

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvctdepto";
            string Method = "gethvctdeptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvCtDeptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtDeptoModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvctdepto";
            string Method = "gethvctdeptoid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvCtDeptoModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvCtDeptoModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(HvCtDeptoModel ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "hvctdepto";
            string Method = "gethvctdeptodelete";
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