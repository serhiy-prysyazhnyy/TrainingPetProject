using System.Net;
using System.Web.Mvc;
using AutoMapper;
using TrainingPetProject.DataAccess.Abstract;
using TrainingPetProject.DataAccess.Models;
using TrainingPetProject.Web.ViewModels;

namespace TrainingPetProject.Web.Controllers
{
    public class KabanController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public KabanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Kaban/
        public ActionResult Index()
        {
            return View(_unitOfWork.KabanRepository.GetItems());
        }

        // GET: /Kaban/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = _unitOfWork.KabanRepository.GetItemById(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            KabanViewModel viewModel = Mapper.Map<Kaban, KabanViewModel>(dbModel);

            return View(viewModel);
        }

        // GET: /Kaban/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Kaban/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] KabanViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var kbn = Mapper.Map<Kaban>(viewModel);

                _unitOfWork.KabanRepository.AddItem(kbn);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: /Kaban/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = _unitOfWork.KabanRepository.GetItemById(id);
            
            if (dbModel == null)
            {
                return HttpNotFound();
            }

            KabanViewModel viewModel = Mapper.Map<Kaban, KabanViewModel>(dbModel);

            return View(viewModel);
        }

        // POST: /Kaban/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] KabanViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbModel = _unitOfWork.KabanRepository.GetItemById(viewModel.Id);
                Mapper.Map(viewModel, dbModel);

                _unitOfWork.KabanRepository.UpdateItem(dbModel);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: /Kaban/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbModel = _unitOfWork.KabanRepository.GetItemById(id);

            if (dbModel == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<Kaban, KabanViewModel>(dbModel);

            return View(viewModel);
        }

        // POST: /Kaban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.KabanRepository.DeleteItem(id);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

    }
}
