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
    public class EntrenamientoTipoEntrenamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EntrenamientoTipoEntrenamientoes
        public ActionResult Index()
        {
            var entrenamientoTipoEntrenamiento = db.EntrenamientoTipoEntrenamiento.Include(e => e.Entrenamiento).Include(e => e.TipoEntrenamiento).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(entrenamientoTipoEntrenamiento.ToList());
        }

        // GET: EntrenamientoTipoEntrenamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoTipoEntrenamiento entrenamientoTipoEntrenamiento = db.EntrenamientoTipoEntrenamiento.Find(id);
            if (entrenamientoTipoEntrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(entrenamientoTipoEntrenamiento);
        }

        // GET: EntrenamientoTipoEntrenamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre");
            ViewBag.idTipoEntrenamiento = new SelectList(db.TipoEntrenamiento, "idTipoEntrenamiento", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EntrenamientoTipoEntrenamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEntrenamientoTipoEntrenamiento,idEntrenamiento,idTipoEntrenamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EntrenamientoTipoEntrenamiento entrenamientoTipoEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.EntrenamientoTipoEntrenamiento.Add(entrenamientoTipoEntrenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoTipoEntrenamiento.idEntrenamiento);
            ViewBag.idTipoEntrenamiento = new SelectList(db.TipoEntrenamiento, "idTipoEntrenamiento", "numero", entrenamientoTipoEntrenamiento.idTipoEntrenamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoTipoEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoTipoEntrenamiento.idUsuarioModifica);
            return View(entrenamientoTipoEntrenamiento);
        }

        // GET: EntrenamientoTipoEntrenamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoTipoEntrenamiento entrenamientoTipoEntrenamiento = db.EntrenamientoTipoEntrenamiento.Find(id);
            if (entrenamientoTipoEntrenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoTipoEntrenamiento.idEntrenamiento);
            ViewBag.idTipoEntrenamiento = new SelectList(db.TipoEntrenamiento, "idTipoEntrenamiento", "numero", entrenamientoTipoEntrenamiento.idTipoEntrenamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoTipoEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoTipoEntrenamiento.idUsuarioModifica);
            return View(entrenamientoTipoEntrenamiento);
        }

        // POST: EntrenamientoTipoEntrenamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEntrenamientoTipoEntrenamiento,idEntrenamiento,idTipoEntrenamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EntrenamientoTipoEntrenamiento entrenamientoTipoEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenamientoTipoEntrenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoTipoEntrenamiento.idEntrenamiento);
            ViewBag.idTipoEntrenamiento = new SelectList(db.TipoEntrenamiento, "idTipoEntrenamiento", "numero", entrenamientoTipoEntrenamiento.idTipoEntrenamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoTipoEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoTipoEntrenamiento.idUsuarioModifica);
            return View(entrenamientoTipoEntrenamiento);
        }

        // GET: EntrenamientoTipoEntrenamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoTipoEntrenamiento entrenamientoTipoEntrenamiento = db.EntrenamientoTipoEntrenamiento.Find(id);
            if (entrenamientoTipoEntrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(entrenamientoTipoEntrenamiento);
        }

        // POST: EntrenamientoTipoEntrenamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntrenamientoTipoEntrenamiento entrenamientoTipoEntrenamiento = db.EntrenamientoTipoEntrenamiento.Find(id);
            db.EntrenamientoTipoEntrenamiento.Remove(entrenamientoTipoEntrenamiento);
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
