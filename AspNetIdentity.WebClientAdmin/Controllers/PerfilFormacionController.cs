using AspNetIdentity.WebClientAdmin.Providers;
using AspNetIdentity.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class PerfilFormacionController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListPerfilCtEscolaridad()
        {
            string Id = "0";
            string Controller = "perfilctescolaridad";
            string Method = "getperfilctescolaridad";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilCtEscolaridadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilCtEscolaridadModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_ESCOLARIDAD.ToString() }).ToList());
        }

        public async Task<ActionResult> ListPerfilCtEspecialidad()
        {
            string Id = "0";
            string Controller = "perfilctespecialidad";
            string Method = "getperfilctespecialidad";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilCtEspecialidadModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilCtEspecialidadModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_ESPECIALIDAD.ToString() }).ToList());
        }

        public async Task<ActionResult> Index(int IdP)
        {
            string Id = IdP.ToString();
            string Controller = "perfilformacion";
            string Method = "getperfilformacionidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<PerfilFormacionModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PerfilFormacionModel>>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public ActionResult Crear(int IdTable)
        {
            PerfilFormacionModel ObjData = new PerfilFormacionModel();
            ObjData.ID_PERFIL = IdTable;
            return PartialView(ObjData);
        }

        [HttpPost]
        public async Task<ActionResult> Crear(PerfilFormacionModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilformacion";
            string Method = "perfilformacioncreate";
            PerfilFormacionModel processModel = new PerfilFormacionModel();

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilFormacionModel>(jsonResult.ToString());
                    if (processModel.ID_PERFIL.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        PartialView(processModel);
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    PartialView(processModel);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                PartialView(processModel);
            }
            return RedirectToAction("../Perfil/Edit", new { IdTable = processModel.ID_PERFIL });//
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilformacion";
            string Method = "getperfilformacionid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilFormacionModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilFormacionModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditJson(PerfilFormacionModel ObjData)
        {
            string Id = "0";
            string Controller = "perfilformacion";
            string Method = "perfilformacionupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    PerfilFormacionModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilFormacionModel>(jsonResult.ToString());
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
            string Controller = "perfilformacion";
            string Method = "getperfilformacionid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilFormacionModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilFormacionModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilformacion";
            string Method = "getperfilformacionid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            PerfilFormacionModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PerfilFormacionModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(PerfilFormacionModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "perfilformacion";
            string Method = "getperfilformaciondelete";
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