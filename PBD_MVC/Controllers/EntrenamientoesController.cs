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
    public class EntrenamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Entrenamientoes
        public ActionResult Index()
        {
            var entrenamiento = db.Entrenamiento.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(entrenamiento.ToList());
        }

        // GET: Entrenamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenamiento entrenamiento = db.Entrenamiento.Find(id);
            if (entrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(entrenamiento);
        }

        // GET: Entrenamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Entrenamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEntrenamiento,nombre,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Entrenamiento entrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entrenamiento.Add(entrenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamiento.idUsuarioModifica);
            return View(entrenamiento);
        }

        // GET: Entrenamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenamiento entrenamiento = db.Entrenamiento.Find(id);
            if (entrenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamiento.idUsuarioModifica);
            return View(entrenamiento);
        }

        // POST: Entrenamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEntrenamiento,nombre,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Entrenamiento entrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamiento.idUsuarioModifica);
            return View(entrenamiento);
        }

        // GET: Entrenamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenamiento entrenamiento = db.Entrenamiento.Find(id);
            if (entrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(entrenamiento);
        }

        // POST: Entrenamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrenamiento entrenamiento = db.Entrenamiento.Find(id);
            db.Entrenamiento.Remove(entrenamiento);
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
