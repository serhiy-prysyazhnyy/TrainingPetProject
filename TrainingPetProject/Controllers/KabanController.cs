using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingPetProject.Web.DataAccess.Models;
using TrainingPetProject.Web.DataAccess.Context;

namespace TrainingPetProject.Web.Controllers
{
    public class KabanController : Controller
    {
        private PetProjContex db = new PetProjContex();

        // GET: /Kaban/
        public ActionResult Index()
        {
            return View(db.Kabans.ToList());
        }

        // GET: /Kaban/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaban kaban = db.Kabans.Find(id);
            if (kaban == null)
            {
                return HttpNotFound();
            }
            return View(kaban);
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
        public ActionResult Create([Bind(Include="Id,Name")] Kaban kaban)
        {
            if (ModelState.IsValid)
            {
                db.Kabans.Add(kaban);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaban);
        }

        // GET: /Kaban/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaban kaban = db.Kabans.Find(id);
            if (kaban == null)
            {
                return HttpNotFound();
            }
            return View(kaban);
        }

        // POST: /Kaban/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] Kaban kaban)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaban).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaban);
        }

        // GET: /Kaban/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaban kaban = db.Kabans.Find(id);
            if (kaban == null)
            {
                return HttpNotFound();
            }
            return View(kaban);
        }

        // POST: /Kaban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kaban kaban = db.Kabans.Find(id);
            db.Kabans.Remove(kaban);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
