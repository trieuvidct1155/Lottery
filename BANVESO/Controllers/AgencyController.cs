using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BANVESO.Models;

namespace BANVESO.Controllers
{
    public class AgencyController : Controller
    {
        private LotteryEntities db = new LotteryEntities();

        // GET: Agency
        public ActionResult Agency()
        {
            var dAILIs = db.DAILIs;
            return View(dAILIs.ToList());
        }

        // GET: Agency/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAILI dAILI = db.DAILIs.Find(id);
            if (dAILI == null)
            {
                return HttpNotFound();
            }
            return View(dAILI);
        }

        // GET: Agency/Create
        public ActionResult Create()
        {
            ViewBag.MaDL = new SelectList(db.DANGKISOLUONGs, "MaDL", "SoLuongDK");
            return View();
        }

        // POST: Agency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDL,TenDL,DiaChi,Sdt")] DAILI dAILI)
        {
            if (ModelState.IsValid)
            {
                db.DAILIs.Add(dAILI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDL = new SelectList(db.DANGKISOLUONGs, "MaDL", "SoLuongDK", dAILI.MaDL);
            return View(dAILI);
        }

        // GET: Agency/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAILI dAILI = db.DAILIs.Find(id);
            if (dAILI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDL = new SelectList(db.DANGKISOLUONGs, "MaDL", "SoLuongDK", dAILI.MaDL);
            return View(dAILI);
        }

        // POST: Agency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDL,TenDL,DiaChi,Sdt")] DAILI dAILI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dAILI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDL = new SelectList(db.DANGKISOLUONGs, "MaDL", "SoLuongDK", dAILI.MaDL);
            return View(dAILI);
        }

        // GET: Agency/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAILI dAILI = db.DAILIs.Find(id);
            if (dAILI == null)
            {
                return HttpNotFound();
            }
            return View(dAILI);
        }

        // POST: Agency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DAILI dAILI = db.DAILIs.Find(id);
            db.DAILIs.Remove(dAILI);
            db.SaveChanges();
            return RedirectToAction("Agency");
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
