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
    public class EntrenamientoMaquinasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EntrenamientoMaquinas
        public ActionResult Index()
        {
            var entrenamientoMaquina = db.EntrenamientoMaquina.Include(e => e.Entrenamiento).Include(e => e.Maquina).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(entrenamientoMaquina.ToList());
        }

        // GET: EntrenamientoMaquinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoMaquina entrenamientoMaquina = db.EntrenamientoMaquina.Find(id);
            if (entrenamientoMaquina == null)
            {
                return HttpNotFound();
            }
            return View(entrenamientoMaquina);
        }

        // GET: EntrenamientoMaquinas/Create
        public ActionResult Create()
        {
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre");
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EntrenamientoMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEntrenamientoMaquina,idEntrenamiento,idMaquina,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EntrenamientoMaquina entrenamientoMaquina)
        {
            if (ModelState.IsValid)
            {
                db.EntrenamientoMaquina.Add(entrenamientoMaquina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoMaquina.idEntrenamiento);
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo", entrenamientoMaquina.idMaquina);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoMaquina.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoMaquina.idUsuarioModifica);
            return View(entrenamientoMaquina);
        }

        // GET: EntrenamientoMaquinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoMaquina entrenamientoMaquina = db.EntrenamientoMaquina.Find(id);
            if (entrenamientoMaquina == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoMaquina.idEntrenamiento);
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo", entrenamientoMaquina.idMaquina);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoMaquina.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoMaquina.idUsuarioModifica);
            return View(entrenamientoMaquina);
        }

        // POST: EntrenamientoMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEntrenamientoMaquina,idEntrenamiento,idMaquina,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EntrenamientoMaquina entrenamientoMaquina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenamientoMaquina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", entrenamientoMaquina.idEntrenamiento);
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo", entrenamientoMaquina.idMaquina);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoMaquina.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", entrenamientoMaquina.idUsuarioModifica);
            return View(entrenamientoMaquina);
        }

        // GET: EntrenamientoMaquinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntrenamientoMaquina entrenamientoMaquina = db.EntrenamientoMaquina.Find(id);
            if (entrenamientoMaquina == null)
            {
                return HttpNotFound();
            }
            return View(entrenamientoMaquina);
        }

        // POST: EntrenamientoMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntrenamientoMaquina entrenamientoMaquina = db.EntrenamientoMaquina.Find(id);
            db.EntrenamientoMaquina.Remove(entrenamientoMaquina);
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
