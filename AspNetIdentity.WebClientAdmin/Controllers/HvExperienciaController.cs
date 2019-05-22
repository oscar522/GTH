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
    public class HvExperienciaController : WebClientAdmin.BaseController
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

        public async Task<ActionResult> ListEmpresa()
        {
            string Id = "0";
            string Controller = "hvctempresa";
            string Method = "gethvctempresa";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtEmpresaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtEmpresaModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_EMPRESA.ToString() }).ToList());
        }

        public async Task<ActionResult> ListCargo()
        {
            string Id = "0";
            string Controller = "hvctcargo";
            string Method = "gethvctcargo";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvCtCargoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtCargoModel>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_CARGO.ToString() }).ToList());
        }

        public async Task<ActionResult> Index(int IdP)
        {
            string Id = IdP.ToString();
            string Controller = "hvexperiencia";
            string Method = "gethvexperienciaidd";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<HvExperienciaModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvExperienciaModel>>(jsonResult.ToString());
            return PartialView(processModel);// ----------- //
        }

        public ActionResult Crear(int IdTable)
        {
            HvExperienciaModel ObjData = new HvExperienciaModel();
            ObjData.ID_DATOS_BASICOS = IdTable;
            return PartialView(ObjData);// ----------- //
        }

        [HttpPost]
        public async Task<ActionResult> Crear(HvExperienciaModel ObjData)
        {
            string Id = "0";
            string Controller = "hvexperiencia";
            string Method = "hvexperienciacreate";
            HvExperienciaModel processModel = new HvExperienciaModel();
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvExperienciaModel>(jsonResult.ToString());
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
            string Controller = "hvexperiencia";
            string Method = "gethvexperienciaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvExperienciaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvExperienciaModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]
        public async Task<ActionResult> EditJson(HvExperienciaModel ObjData)
        {
            string Id = "0";
            string Controller = "hvexperiencia";
            string Method = "hvexperienciaupdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    HvExperienciaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvExperienciaModel>(jsonResult.ToString());
                    if (processModel.ID_DATOS_BASICOS.Equals(""))
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
            string Controller = "hvexperiencia";
            string Method = "gethvexperienciaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvExperienciaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvExperienciaModel>(jsonResult.ToString());
            return PartialView(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvexperiencia";
            string Method = "gethvexperienciaid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            HvExperienciaModel processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<HvExperienciaModel>(jsonResult.ToString());
            return PartialView(processModel);
        }
        [HttpPost]

        public async Task<ActionResult> Delete(HvExperienciaModel ObjData, int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "hvexperiencia";
            string Method = "gethvexperienciadelete";
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
                return RedirectToAction("../HvDatosBasicos/Detail", new { IdTable = processModel });// ----------- //
            }
        }
    }
}