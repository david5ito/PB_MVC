using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBD_MVC.Models;

namespace PBD_MVC.Controllers
{
    public class DorsalsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Dorsals
        public ActionResult Index()
        {
            var dorsal = db.Dorsal.Include(d => d.Usuario).Include(d => d.Usuario1);
            return View(dorsal.ToList());
        }

        // GET: Dorsals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorsal dorsal = db.Dorsal.Find(id);
            if (dorsal == null)
            {
                return HttpNotFound();
            }
            return View(dorsal);
        }

        // GET: Dorsals/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Dorsals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDorsal,nombre,numero,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Dorsal dorsal)
        {
            if (ModelState.IsValid)
            {
                db.Dorsal.Add(dorsal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", dorsal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", dorsal.idUsuarioModifica);
            return View(dorsal);
        }

        // GET: Dorsals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorsal dorsal = db.Dorsal.Find(id);
            if (dorsal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", dorsal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", dorsal.idUsuarioModifica);
            return View(dorsal);
        }

        // POST: Dorsals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDorsal,nombre,numero,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Dorsal dorsal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dorsal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", dorsal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", dorsal.idUsuarioModifica);
            return View(dorsal);
        }

        // GET: Dorsals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dorsal dorsal = db.Dorsal.Find(id);
            if (dorsal == null)
            {
                return HttpNotFound();
            }
            return View(dorsal);
        }

        // POST: Dorsals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dorsal dorsal = db.Dorsal.Find(id);
            db.Dorsal.Remove(dorsal);
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
