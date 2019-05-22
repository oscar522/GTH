using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class HvActitudesController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListCtActitudes()
        {
            string Id = "0";
            string Controller = "hvctactitudes";
            string Method = "gethvctactitudes";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtActitudesModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtActitudesModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_ACTITUDES.ToString() }).ToList());
        }

        public async Task<ActionResult> Index(int IdP)
        {
            string Id = IdP.ToString();
            string Controller = "hvactitudes";
            string Method = "gethvactitudesidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvActitudesModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvActitudesModel>>(jsonResult.ToString());
            return PartialView(processModel);// ----------- //
        }

        public ActionResult Crear(int IdTable)
        {
            HvActitudesModel ObjData = new HvActitudesModel();
            ObjData.ID_DATOS_BASICOS = IdTable;
            return PartialView(ObjData);// ----------- //
        }

        [HttpPost]
        public async Task<ActionResult> Crear(HvActitudesModel ObjData)
        {
            string Id = "0";
            string Controller = "hvactitudes";
            string Method = "hvactitudescreate";
            HvActitudesModel processModel = new HvActitudesModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvActitudesModel>(jsonResult.ToString());
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
            //return RedirectToAction("Index", new { IdP = processModel.ID_DATOS_BASICOS });
            return RedirectToAction("../HvDatosBasicos/Detail", new { IdTable = processModel.ID_DATOS_BASICOS });// ----------- //
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvactitudes";
            string Method = "gethvactitudesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvActitudesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvActitudesModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> EditJson(HvActitudesModel ObjData)
        {
            string Id = "0";
            string Controller = "hvactitudes";
            string Method = "hvactitudesupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvActitudesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvActitudesModel>(jsonResult.ToString());
                    if (processModel.ID_ACTITUDES.Equals(""))
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
            string Controller = "hvactitudes";
            string Method = "gethvactitudesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvActitudesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvActitudesModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvactitudes";
            string Method = "gethvactitudesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvActitudesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvActitudesModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]

        public async Task<ActionResult>  Delete(HvActitudesModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvactitudes";
            string Method = "gethvactitudesdelete";
            string result = await employeeProvider.Delete(Controller, Method, Id); // ----------- //
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