using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDB _db = new OdeToFoodDB();
        // can only be called using html.action as a child request
        // users cannot call this action from the browser
        /*[ChildActionOnly]
        public ActionResult BestReview()
        {
            /*var bestReview = from r in _reviews
                             orderby r.Rating descending
                             select r;

            return PartialView("_Review", bestReview.First());*/
            /*return View();
        }*/

        //
        // GET: /Reviews/

        public ActionResult Index([Bind(Prefix="id")] int restaurantId)
        {
            /*var model =
                from r in _reviews
                orderby r.Country
                select r;
            return View(model);*/

            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null){
                return View(restaurant);
            }

            return HttpNotFound();
        }

        //
        // GET: /Reviews/Details/5

        /*public ActionResult Details(int id)
        {
            return View();
        }*/

        //
        // GET: /Reviews/Create
        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        //
        // POST: /Reviews/Create

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            // if this is false, something with the binding went wrong
            // it checks for all the values in the post and dinds them to the review
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        //
        // GET: /Reviews/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        //
        // POST: /Reviews/Edit/5

        [HttpPost]
        // exclude works as a black list. using it assures that the action won't receive the field called reviewername
        // I can also create a personalized view model and it will only have the parameters I expect from the user
        //public ActionResult Edit([Bind(Exclude="ReviewerName")] RestaurantReview review)
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                // entry keeps track of a record. tells to _db that is not a new record
                // treat it as if I am adding new data inside
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        //
        // GET: /Reviews/Delete/5

        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        //
        // POST: /Reviews/Delete/5

        /*[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        /*
        static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview {
                Id = 1,
                Name = "Cinnamon Club",
                City = "London",
                Country = "UK",
                Rating = 10
            },
            new RestaurantReview {
                Id = 2,
                Name = "Marrakesh",
                City = "D.C",
                Country = "USA",
                Rating = 10
            },
            new RestaurantReview {
                Id = 3,
                Name = "The House of Elliot",
                City = "Ghent",
                Country = "Belgium",
                Rating = 10
            }
        };
        */

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
