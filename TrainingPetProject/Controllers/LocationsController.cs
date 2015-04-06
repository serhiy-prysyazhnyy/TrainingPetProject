using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using TrainingPetProject.DataAccess.Abstract;
using TrainingPetProject.DataAccess.Context;
using TrainingPetProject.DataAccess.Models;
using TrainingPetProject.Web.Models;

namespace TrainingPetProject.Web.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Locations/
        public ActionResult Index()
        {
            return View(_unitOfWork.LocationsRepository.GetItems());
        }

        // GET: /Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var dbModel = _unitOfWork.LocationsRepository.GetItemById(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            LocationsViewModel viewModel = Mapper.Map<Locations, LocationsViewModel>(dbModel);

            return View(viewModel);
        }

        // GET: /Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Country,City,DisplayName")] LocationsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tempMap = Mapper.Map<Locations>(viewModel);

                _unitOfWork.LocationsRepository.AddItem(tempMap);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: /Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var dbModel = _unitOfWork.LocationsRepository.GetItemById(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            LocationsViewModel viewModel = Mapper.Map<Locations, LocationsViewModel>(dbModel);

            return View(viewModel);
        }

        // POST: /Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Country,City,DisplayName")] LocationsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbModel = _unitOfWork.LocationsRepository.GetItemById(viewModel.Id);
                Mapper.Map(viewModel, dbModel);

                _unitOfWork.LocationsRepository.UpdateItem(dbModel);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: /Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var dbModel = _unitOfWork.LocationsRepository.GetItemById(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            LocationsViewModel viewModel = Mapper.Map<Locations, LocationsViewModel>(dbModel);

            return View(viewModel);
        }

        // POST: /Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            _unitOfWork.LocationsRepository.DeleteItem(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
