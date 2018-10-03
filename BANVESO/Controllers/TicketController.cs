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
    public class TicketController : Controller
    {
        private LotteryEntities db = new LotteryEntities();

        // GET: Ticket
        public ActionResult Index()
        {
            return View(db.LOAIVESOes.ToList());
        }

        // GET: Ticket/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIVESO lOAIVESO = db.LOAIVESOes.Find(id);
            if (lOAIVESO == null)
            {
                return HttpNotFound();
            }
            return View(lOAIVESO);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiVS,TenLoaiVS")] LOAIVESO lOAIVESO)
        {
            if (ModelState.IsValid)
            {
                db.LOAIVESOes.Add(lOAIVESO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIVESO);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIVESO lOAIVESO = db.LOAIVESOes.Find(id);
            if (lOAIVESO == null)
            {
                return HttpNotFound();
            }
            return View(lOAIVESO);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiVS,TenLoaiVS")] LOAIVESO lOAIVESO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIVESO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIVESO);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIVESO lOAIVESO = db.LOAIVESOes.Find(id);
            if (lOAIVESO == null)
            {
                return HttpNotFound();
            }
            return View(lOAIVESO);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAIVESO lOAIVESO = db.LOAIVESOes.Find(id);
            db.LOAIVESOes.Remove(lOAIVESO);
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
