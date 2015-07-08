using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    // [Authorize]
    [Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        // all public methods can be called from the URL
        // do not put any method as public if I do not
        // expect it to be called from the URL

        // http://localhost:54180/cuisine?name=italian works too

        // ActionName
        // [ActionName("Find")] Alias given to actionresults
        // when we want to access it with a diferent name
        // than it is declared

        // AcceptVerbs
        // [HttpPost] | [HttpGet]
        // specify the type of request that this actionresult
        // can be access with
        // [HttpGet]
        // [Authorize(Roles="Admin")]
        // [Authorize]
        public ActionResult Search(string name = "french")
        {
            throw new Exception("Something terrible has happened");
            // render text. protect from malisious attacks
            var message = Server.HtmlEncode(name);
            // return Json(new { Message = message, Name = "Yahir" }, JsonRequestBehavior.AllowGet);
            // return File(Server.MapPath("~/Content/site.css"), "text/css");
            // return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            // return RedirectToAction("Index", "Home", new { name = name });
            // return RedirectPermanent("http://www.asp.net/");
            // return RedirectToAction("Index", "Home");
            return Content(message);
        }

        /*[HttpPost]
        public ActionResult Search()
        {
            return Content("Search!");
        }*/
    }
}
