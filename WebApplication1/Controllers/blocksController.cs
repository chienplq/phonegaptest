using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class blocksController : Controller
    {
        private blockChainEntities db = new blockChainEntities();

        // GET: blocks
        public ActionResult Index()
        {
            return View(db.blocks.ToList());
        }

        // GET: blocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            block block = db.blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // GET: blocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: blocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "index,previousHash,hash,timestamp,data")] block block)
        {
            if (ModelState.IsValid)
            {
                db.blocks.Add(block);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(block);
        }

        // GET: blocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            block block = db.blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // POST: blocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "index,previousHash,hash,timestamp,data")] block block)
        {
            if (ModelState.IsValid)
            {
                db.Entry(block).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(block);
        }

        // GET: blocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            block block = db.blocks.Find(id);
            if (block == null)
            {
                return HttpNotFound();
            }
            return View(block);
        }

        // POST: blocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            block block = db.blocks.Find(id);
            db.blocks.Remove(block);
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
