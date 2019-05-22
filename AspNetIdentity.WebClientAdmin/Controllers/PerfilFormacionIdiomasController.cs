using AspNetIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspNetIdentity.WebClientAdmin.Controllers
{
    [Authorize]
    public class PerfilFormacionIdiomasController : BaseController
    {
        public JsonResult ListIdioma()
        {
            IEnumerable<PerfilCtIdiomasModel> PerfilCtIdiomas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilCtIdiomas");
                var responseTask = client.GetAsync("PerfilCtIdiomas");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PerfilCtIdiomasModel>>();
                    readTask.Wait();
                    PerfilCtIdiomas = readTask.Result;
                }
                else
                {
                    PerfilCtIdiomas = Enumerable.Empty<PerfilCtIdiomasModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return Json(PerfilCtIdiomas.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_IDIOMA.ToString() }).ToList());
        }

        public JsonResult ListIdiomaNivel()
        {
            IEnumerable<PerfilCtIdiomasNivelModel> PerfilCtIdiomasNivel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilCtIdiomasNivel");
                var responseTask = client.GetAsync("PerfilCtIdiomasNivel");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PerfilCtIdiomasNivelModel>>();
                    readTask.Wait();
                    PerfilCtIdiomasNivel = readTask.Result;
                }
                else
                {
                    PerfilCtIdiomasNivel = Enumerable.Empty<PerfilCtIdiomasNivelModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return Json(PerfilCtIdiomasNivel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_IDIOM_NIVEL.ToString() }).ToList());
        }

        public ActionResult Index(int IdP)
        {
            IEnumerable<PerfilFormacionIdiomasModel> ObjData = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var responseTask = client.GetAsync("PerfilFormacionIdiomas?IdP=" + IdP.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PerfilFormacionIdiomasModel>>();
                    readTask.Wait();
                    ObjData = readTask.Result;
                }
                else
                {
                    ObjData = Enumerable.Empty<PerfilFormacionIdiomasModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(ObjData);
        }

        public ActionResult Crear(int IdTable, int IdTable2)
        {
            PerfilFormacionIdiomasModel ObjData = new PerfilFormacionIdiomasModel();
            ObjData.ID_PERFIL = IdTable;
            ObjData.ID_IDIOMA = IdTable2;
            return View(ObjData);
        }

        [HttpPost]
        public ActionResult Crear(PerfilFormacionIdiomasModel ObjData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var postTask = client.PostAsJsonAsync<PerfilFormacionIdiomasModel>("PerfilFormacionIdiomas", ObjData);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PerfilFormacionIdiomasModel>();
                    readTask.Wait();
                    PerfilFormacionIdiomasModel objresult = readTask.Result;
                    return RedirectToAction("Index", new { IdP = objresult.ID_PERFIL });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return View(ObjData);
                }
            }
        }

        public ActionResult Edit(int IdTable)
        {
            PerfilFormacionIdiomasModel ObjData = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var responseTask = client.GetAsync("PerfilFormacionIdiomas?id=" + IdTable.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PerfilFormacionIdiomasModel>();
                    readTask.Wait();
                    ObjData = readTask.Result;
                }
            }
            return PartialView(ObjData);
        }
        [HttpPost]

        public ActionResult Edit(PerfilFormacionIdiomasModel ObjData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var putTask = client.PutAsJsonAsync<PerfilFormacionIdiomasModel>("PerfilFormacionIdiomas", ObjData);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PerfilFinalidadModel>();
                    readTask.Wait();
                    PerfilFinalidadModel objresult = readTask.Result;
                    return RedirectToAction("Index", new { IdP = objresult.ID_PERFIL });
                }
            }
            return PartialView(ObjData);
        }

        public JsonResult EditJson(PerfilFormacionIdiomasModel ObjData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var putTask = client.PutAsJsonAsync<PerfilFormacionIdiomasModel>("PerfilFormacionIdiomas", ObjData);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json("Index");
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
        }

        public ActionResult Detail(int IdTable)
        {
            PerfilFormacionIdiomasModel ObjData = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var responseTask = client.GetAsync("PerfilFormacionIdiomas?id=" + IdTable.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PerfilFormacionIdiomasModel>();
                    readTask.Wait();
                    ObjData = readTask.Result;
                }
            }

            return PartialView(ObjData);
        }

        public ActionResult Delete(int IdTable)
        {
            PerfilFormacionIdiomasModel ObjData = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                //HTTP GET
                var responseTask = client.GetAsync("PerfilFormacionIdiomas?id=" + IdTable.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PerfilFormacionIdiomasModel>();
                    readTask.Wait();
                    ObjData = readTask.Result;
                }
            }
            return PartialView(ObjData);
        }

        [HttpPost]
        public ActionResult Delete(PerfilFormacionIdiomasModel ObjData, int IdTable)
        {
            ObjData.ID_FORMA_IDIOM = IdTable;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"] + "PerfilFormacionIdiomas");
                var deleteTask = client.DeleteAsync("PerfilFormacionIdiomas/" + ObjData.ID_FORMA_IDIOM.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}