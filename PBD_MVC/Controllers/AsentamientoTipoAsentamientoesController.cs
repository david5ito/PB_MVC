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
    public class AsentamientoTipoAsentamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: AsentamientoTipoAsentamientoes
        public ActionResult Index()
        {
            var asentamientoTipoAsentamiento = db.AsentamientoTipoAsentamiento.Include(a => a.Asentamiento).Include(a => a.TipoAsentamiento).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(asentamientoTipoAsentamiento.ToList());
        }

        // GET: AsentamientoTipoAsentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsentamientoTipoAsentamiento asentamientoTipoAsentamiento = db.AsentamientoTipoAsentamiento.Find(id);
            if (asentamientoTipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamientoTipoAsentamiento);
        }

        // GET: AsentamientoTipoAsentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero");
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: AsentamientoTipoAsentamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsentamientoTipoAsentamiento,idAsentamiento,idTipoAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AsentamientoTipoAsentamiento asentamientoTipoAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.AsentamientoTipoAsentamiento.Add(asentamientoTipoAsentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", asentamientoTipoAsentamiento.idAsentamiento);
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "numero", asentamientoTipoAsentamiento.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamientoTipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamientoTipoAsentamiento.idUsuarioModifica);
            return View(asentamientoTipoAsentamiento);
        }

        // GET: AsentamientoTipoAsentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsentamientoTipoAsentamiento asentamientoTipoAsentamiento = db.AsentamientoTipoAsentamiento.Find(id);
            if (asentamientoTipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", asentamientoTipoAsentamiento.idAsentamiento);
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "numero", asentamientoTipoAsentamiento.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamientoTipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamientoTipoAsentamiento.idUsuarioModifica);
            return View(asentamientoTipoAsentamiento);
        }

        // POST: AsentamientoTipoAsentamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsentamientoTipoAsentamiento,idAsentamiento,idTipoAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] AsentamientoTipoAsentamiento asentamientoTipoAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asentamientoTipoAsentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", asentamientoTipoAsentamiento.idAsentamiento);
            ViewBag.idTipoAsentamiento = new SelectList(db.TipoAsentamiento, "idTipoAsentamiento", "numero", asentamientoTipoAsentamiento.idTipoAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", asentamientoTipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", asentamientoTipoAsentamiento.idUsuarioModifica);
            return View(asentamientoTipoAsentamiento);
        }

        // GET: AsentamientoTipoAsentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsentamientoTipoAsentamiento asentamientoTipoAsentamiento = db.AsentamientoTipoAsentamiento.Find(id);
            if (asentamientoTipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamientoTipoAsentamiento);
        }

        // POST: AsentamientoTipoAsentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsentamientoTipoAsentamiento asentamientoTipoAsentamiento = db.AsentamientoTipoAsentamiento.Find(id);
            db.AsentamientoTipoAsentamiento.Remove(asentamientoTipoAsentamiento);
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
