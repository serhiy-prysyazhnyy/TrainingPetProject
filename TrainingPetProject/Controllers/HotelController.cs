using System.Collections.Generic;
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
    public class HotelController : Controller
    {
        PetProjContex db = new PetProjContex();

        private readonly IUnitOfWork _unitOfWork;

        public HotelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Hotel/
        public ActionResult Index()
        {          
            var dbModels = _unitOfWork.HotelRepository.GetItems();

            List<HotelViewModel> viewModel = Mapper.Map<List<Hotel>, List<HotelViewModel>>(dbModels.ToList());

            return View(viewModel);
        }

        // GET: /Hotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = _unitOfWork.HotelRepository.GetItemById(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            HotelViewModel viewModel = Mapper.Map<Hotel, HotelViewModel>(dbModel);

            return View(viewModel);
        }

        // GET: /Hotel/Create
        public ActionResult Create()
        {
            ViewBag.LocationsId = new SelectList(db.Locations, "Id", "Country");
            return View();
        }

        // POST: /Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Stars,HotelName,LocationsId")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationsId = new SelectList(db.Locations, "Id", "Country", hotel.LocationId);
            return View(hotel);
        }

        // GET: /Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationsId = new SelectList(db.Locations, "Id", "Country", hotel.LocationId);
            return View(hotel);
        }

        // POST: /Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Stars,HotelName,LocationsId")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationsId = new SelectList(db.Locations, "Id", "Country", hotel.LocationId);
            return View(hotel);
        }    
    }
}
