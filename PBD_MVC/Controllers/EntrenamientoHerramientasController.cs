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
    public class EntrenamientoHerramientasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EntrenamientoHerramientas
        public ActionResult Index()
        {
            var entrenamientoHerramienta = db.EntrenamientoHerramienta.Include(e => e.Entrenamiento).Include(e => e.Herramienta).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(entrenamientoHerramienta.ToList());
        }

        // GET: EntrenamientoHerramientas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoHerramienta entrenamientoHerramienta = db.EntrenamientoHerramienta.Find(id);
            if (entrenamientoHerramienta == null)
            {
                return HttpNotFound();
            }
            return View(entrenamientoHerramienta);
        }

        // GET: EntrenamientoHerramientas/Create
        public ActionResult Create()
        {
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre");
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EntrenamientoHerramientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEntrenamientoHerramienta,idEntrenamiento,idHerramienta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EntrenamientoHerramienta entrenamientoHerramienta)
        {
            if (ModelState.IsValid)
            {
                db.EntrenamientoHerramienta.Add(entrenamientoHerramienta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoHerramienta.idEntrenamiento);
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero", entrenamientoHerramienta.idHerramienta);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoHerramienta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoHerramienta.idUsuarioModifica);
            return View(entrenamientoHerramienta);
        }

        // GET: EntrenamientoHerramientas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoHerramienta entrenamientoHerramienta = db.EntrenamientoHerramienta.Find(id);
            if (entrenamientoHerramienta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoHerramienta.idEntrenamiento);
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero", entrenamientoHerramienta.idHerramienta);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoHerramienta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoHerramienta.idUsuarioModifica);
            return View(entrenamientoHerramienta);
        }

        // POST: EntrenamientoHerramientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEntrenamientoHerramienta,idEntrenamiento,idHerramienta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EntrenamientoHerramienta entrenamientoHerramienta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenamientoHerramienta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoHerramienta.idEntrenamiento);
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero", entrenamientoHerramienta.idHerramienta);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoHerramienta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoHerramienta.idUsuarioModifica);
            return View(entrenamientoHerramienta);
        }

        // GET: EntrenamientoHerramientas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoHerramienta entrenamientoHerramienta = db.EntrenamientoHerramienta.Find(id);
            if (entrenamientoHerramienta == null)
            {
                return HttpNotFound();
            }
            return View(entrenamientoHerramienta);
        }

        // POST: EntrenamientoHerramientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntrenamientoHerramienta entrenamientoHerramienta = db.EntrenamientoHerramienta.Find(id);
            db.EntrenamientoHerramienta.Remove(entrenamientoHerramienta);
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
