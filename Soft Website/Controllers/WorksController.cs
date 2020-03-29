using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Soft_Website.Models;
using WebApplication1.Models;

namespace Soft_Website.Controllers
{
    [Authorize(Roles = "Admins")]
    public class WorksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Works
        [Route("Works/Index")]
        public ActionResult Index()
        {
            var obj = db.Works.Include(s => s.category);
            return View(db.Works.ToList());
        }

        // GET: Works/Details/5
        [Route("Works/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Works/Create
        [Route("Works/Create")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Works/Create")]
        public ActionResult Create(Work work, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), image.FileName); // لتخزين مسار الصورة فى مجلد ع السيرفر
                image.SaveAs(path);  // لتخزين مسار الصورة فى مجلد ع السيرفر
                work.image = image.FileName;
                db.Works.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", work.CategoryID);
            return View(work);

        }

        // GET: Works/Edit/5
        [Route("Works/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", work.CategoryID);
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Works/Edit/{id}")]
        public ActionResult Edit(Work work, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), work.image);

                if (image != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), image.FileName); // لتخزين مسار الصورة فى مجلد ع السيرفر
                    image.SaveAs(path);  // لتخزين مسار الصورة فى مجلد ع السيرفر
                    work.image = image.FileName;
                }

                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName", work.CategoryID);
            return View(work);
        }

        // GET: Works/Delete/5
        [Route("Works/Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Works/Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Works.Find(id);
            db.Works.Remove(work);
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
