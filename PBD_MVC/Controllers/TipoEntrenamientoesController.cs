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
    public class TipoEntrenamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: TipoEntrenamientoes
        public ActionResult Index()
        {
            var tipoEntrenamiento = db.TipoEntrenamiento.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoEntrenamiento.ToList());
        }

        // GET: TipoEntrenamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrenamiento tipoEntrenamiento = db.TipoEntrenamiento.Find(id);
            if (tipoEntrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrenamiento);
        }

        // GET: TipoEntrenamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoEntrenamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoEntrenamiento,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoEntrenamiento tipoEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.TipoEntrenamiento.Add(tipoEntrenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEntrenamiento.idUsuarioModifica);
            return View(tipoEntrenamiento);
        }

        // GET: TipoEntrenamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrenamiento tipoEntrenamiento = db.TipoEntrenamiento.Find(id);
            if (tipoEntrenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEntrenamiento.idUsuarioModifica);
            return View(tipoEntrenamiento);
        }

        // POST: TipoEntrenamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoEntrenamiento,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoEntrenamiento tipoEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEntrenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoEntrenamiento.idUsuarioModifica);
            return View(tipoEntrenamiento);
        }

        // GET: TipoEntrenamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntrenamiento tipoEntrenamiento = db.TipoEntrenamiento.Find(id);
            if (tipoEntrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntrenamiento);
        }

        // POST: TipoEntrenamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEntrenamiento tipoEntrenamiento = db.TipoEntrenamiento.Find(id);
            db.TipoEntrenamiento.Remove(tipoEntrenamiento);
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
