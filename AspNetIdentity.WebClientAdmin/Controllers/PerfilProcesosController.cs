using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class PerfilProcesosController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> Index(int IdP)
        {
            string Id = IdP.ToString();
            string Controller = "perfilprocesos";
            string Method = "getperfilprocesosidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilProcesosModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilProcesosModel>>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public ActionResult Crear(int IdTable)
        {
            PerfilProcesosModel ObjData = new PerfilProcesosModel();
            ObjData.ID_PERFIL = IdTable;
            return PartialView(ObjData);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PerfilProcesosModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilprocesos";
            string Method = "perfilprocesoscreate";
            PerfilProcesosModel processModel = new PerfilProcesosModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilProcesosModel>(jsonResult.ToString());
                    if (processModel.ID_PERFIL.Equals(""))
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
            return RedirectToAction("../Perfil/Edit", new { IdTable = processModel.ID_PERFIL });// ----------- //
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilprocesos";
            string Method = "getperfilprocesosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilProcesosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilProcesosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> EditJson(PerfilProcesosModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilprocesos";
            string Method = "perfilprocesosupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    PerfilProcesosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilProcesosModel>(jsonResult.ToString());
                    if (processModel.ID_PERFIL.Equals(""))
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
            string Controller = "perfilprocesos";
            string Method = "getperfilprocesosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilProcesosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilProcesosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilprocesos";
            string Method = "getperfilprocesosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilProcesosModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilProcesosModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]

        public async Task<ActionResult> Delete(PerfilProcesosModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilprocesos";
            string Method = "getperfilprocesosdelete";
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
                return RedirectToAction("../Perfil/Edit", new { IdTable = processModel });// ----------- //
            }
        }
    }
}