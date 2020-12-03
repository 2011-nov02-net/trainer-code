using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleOrderApp.Domain;
using SimpleOrderApp.WebApp.ViewModels;

namespace SimpleOrderApp.WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class LocationsController : Controller
    {
        private readonly ILocationRepository _repository;

        public LocationsController(ILocationRepository repository)
        {
            _repository = repository;
        }

        // GET: Locations
        [Route("/all", Name = "locations-all")]
        //[Route("index/{email}/{quantity:int}")]
        [Route("")]
        public ActionResult Index()
        {
            var locations = _repository.GetAll().ToList();
            ViewData["LocationCount"] = locations.Count;
            return View(locations);
        }

        // GET: Locations/Details/asdf
        [Route("{id}")]
        public ActionResult Details(string id)
        {
            var location = _repository.GetAll().First(x => x.Name == id);
            return View(location);
        }

        // GET: Locations/Create
        [Route("")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationViewModel viewModel)
        //public ActionResult Create([Required, RegularExpression("[A-Z]")] string name)
        {
            try
            {
                // server-side validation does run automatically, but it doesn't
                //  throw exceptions or short-circuit the mvc pipeline. it just puts errors it sees
                //    into the "ModelState" object (property from the Controller base class)

                // you have to check modelstate yourself
                if (!ModelState.IsValid)
                {
                    // if modelstate contains errors when the view is rendered
                    // they will be put on the page by the div asp-validation-summary and/or span asp-validation-for tag helpers.
                    return View(viewModel);
                }

                var location = new Location(viewModel.Name, viewModel.Stock);
                _repository.Create(location);

                TempData["CreatedLocation"] = location.Name;

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // should log the exception
                ModelState.AddModelError("", "There was a problem creating the location");
                // this error should be more specific if possible, e.g. if i can tell it's because
                // of a duplicate name or something
                return View(viewModel);
            }
        }

        // GET: Locations/Edit/asdf

        [Route("{id}")]
        public ActionResult Edit(dynamic id)
        {
            // "dynamic" type effectively switches off the compile-time type checking.
            //dynamic x = new object();
            //x.adsf = 4;
            //var y = 123 * x.qwer;

            return View();
        }

        // POST: Locations/Edit/asdf
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // whenever a form is involved, usually at least 2 action methods are involved.
        // 1. regular action method, returning the view that will render the form.
        // 2. [HttpPost] action method (limited to HTTP POST method that forms use by default)
        //         receives the submitted form data.

        // GET: Locations/Delete/asdf
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            var location = _repository.GetAll().First(x => x.Name == id);
            return View(location);
        }

        // POST: Locations/Delete/asdf
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            // this action method and the other Delete one are distinguished to ASP.NET
            // by the [HttpPost] or lack thereof.
            // c# needs an extra unused parameter for one of them just so it can compile as a method
            try
            {
                _repository.Delete(id);

                //why a redirect instead of "return View("Index")"
                return RedirectToAction(nameof(Index));
                //var locations = _repository.GetAll();
                //return View("Index", locations);
            }
            catch
            {
                // (should definitely be logging that exception)
                // recover, put the user someplace that makes sense...
                //  in this case, just give him the same form again to try again.
                //   (consider putting an error message on the page for a good user experience)
                var location = _repository.GetAll().First(x => x.Name == id);
                return View(location);
            }
        }
    }
}
