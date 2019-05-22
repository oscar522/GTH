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
    public class PerfilController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListSubArea()
        {
            string Id = "0";
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubarea";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilCtSubAreaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilCtSubAreaModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.DESCRIPCION, Value = x.ID_CT_SUB_AREA.ToString() }).ToList());
        }

        public async Task<ActionResult> ListSubAreaId(string IdP)
        {
            string Id = IdP;
            string Controller = "perfilctsubarea";
            string Method = "getperfilctsubarearea";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilCtSubAreaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilCtSubAreaModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.DESCRIPCION, Value = x.ID_CT_SUB_AREA.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "perfil";
            string Method = "getperfil";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilModel>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PerfilModel ObjData)
        {
            string Id = "0";
            string Controller = "perfil";
            string Method = "perfilcreate";
            PerfilModel processModel = new PerfilModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilModel>(jsonResult.ToString());
                    if (processModel.NOMBRE.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int IdTable)
        {

            string Id = IdTable.ToString();
            string Controller = "perfil";
            string Method = "getperfilid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PerfilModel ObjData)
        {
            string Id = "0";
            string Controller = "perfil";
            string Method = "perfilupdate";
            PerfilModel processModel = new PerfilModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilModel>(jsonResult.ToString());
                    if (processModel.NOMBRE.Equals(""))
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

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfil";
            string Method = "getperfilid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilModel>(jsonResult.ToString());
            return View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfil";
            string Method = "getperfilid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilModel>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(PerfilModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfil";
            string Method = "getperfildelete";
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