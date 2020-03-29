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
    public class TeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teams
        [Authorize(Roles = "Admins")]
        [Route("Teams/Index")]
        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        // GET: Teams/Details/5
        [Authorize(Roles = "Admins")]
        [Route("Teams/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        [Authorize(Roles = "Admins")]
        [Route("Teams/Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Teams/Create")]
        public ActionResult Create(Team team, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/imgs/teame"), image.FileName); // لتخزين مسار الصورة فى مجلد ع السيرفر
                image.SaveAs(path);  // لتخزين مسار الصورة فى مجلد ع السيرفر
                team.image = image.FileName;
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        [Route("Teams/Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Teams/Edit/{id}")]
        public ActionResult Edit(Team team, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                string oldPath = Path.Combine(Server.MapPath("~/imgs/teame"), team.image);

                if (image != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/imgs/teame"), image.FileName); // لتخزين مسار الصورة فى مجلد ع السيرفر
                    image.SaveAs(path);  // لتخزين مسار الصورة فى مجلد ع السيرفر
                    team.image = image.FileName;
                }

                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        [Route("Teams/Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Teams/Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
