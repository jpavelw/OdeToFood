using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();

        public ActionResult Index(string searchTerm = null)
        {
            //var model = _db.Restaurants.ToList();

            /*var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = String.Format("{0}::{1} {2}", controller, action, id);

            ViewBag.Message = message;
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            */
            /*var model =
                from r in _db.Restaurants
                //orderby r.Name ascending
                //orderby r.Reviews.Count() descending
                orderby r.Reviews.Average(review => review.Rating) descending
                //select r;
                select new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                };*/
            var model =
                _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select(r => new RestaurantListViewModel {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                });

            return View(model);
        }

        public ActionResult About()
        {
            /*ViewBag.Message = "Your app description page.";
            ViewBag.Location = "Maryland, USA";*/
            var model = new AboutModel();
            model.Name = "Yahir";
            model.Location = "Santo Domingo, DR";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
