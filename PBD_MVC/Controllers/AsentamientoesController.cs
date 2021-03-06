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
    public class AsentamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Asentamientoes
        public ActionResult Index()
        {
            var asentamiento = db.Asentamiento.Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(asentamiento.ToList());
        }

        // GET: Asentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // GET: Asentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Asentamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsentamiento,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Asentamiento.Add(asentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            return View(asentamiento);
        }

        // GET: Asentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            return View(asentamiento);
        }

        // POST: Asentamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsentamiento,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamiento.idUsuarioModifica);
            return View(asentamiento);
        }

        // GET: Asentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // POST: Asentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            db.Asentamiento.Remove(asentamiento);
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
