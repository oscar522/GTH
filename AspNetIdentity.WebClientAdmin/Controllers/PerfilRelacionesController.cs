using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class PerfilRelacionesController : WebClientAdmin.BaseController
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
            string Controller = "perfilrelaciones";
            string Method = "getperfilrelacionesidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilRelacionesModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilRelacionesModel>>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public ActionResult Crear(int IdTable)
        {
            PerfilRelacionesModel ObjData = new PerfilRelacionesModel();
            ObjData.ID_PERFIL = IdTable;
            return PartialView(ObjData);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PerfilRelacionesModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilrelaciones";
            string Method = "perfilrelacionescreate";
            PerfilRelacionesModel processModel = new PerfilRelacionesModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilRelacionesModel>(jsonResult.ToString());
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
            string Controller = "perfilrelaciones";
            string Method = "getperfilrelacionesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilRelacionesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilRelacionesModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> EditJson(PerfilRelacionesModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilrelaciones";
            string Method = "perfilrelacionesupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    PerfilRelacionesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilRelacionesModel>(jsonResult.ToString());
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
            string Controller = "perfilrelaciones";
            string Method = "getperfilrelacionesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilRelacionesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilRelacionesModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilrelaciones";
            string Method = "getperfilrelacionesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilRelacionesModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilRelacionesModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]

        public async Task<ActionResult> Delete(PerfilRelacionesModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilrelaciones";
            string Method = "getperfilrelacionesdelete";
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