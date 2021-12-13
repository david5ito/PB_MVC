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
    public class TipoAsentamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: TipoAsentamientoes
        public ActionResult Index()
        {
            var tipoAsentamiento = db.TipoAsentamiento.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoAsentamiento.ToList());
        }

        // GET: TipoAsentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            if (tipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoAsentamiento);
        }

        // GET: TipoAsentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoAsentamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoAsentamiento,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAsentamiento tipoAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.TipoAsentamiento.Add(tipoAsentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioModifica);
            return View(tipoAsentamiento);
        }

        // GET: TipoAsentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            if (tipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioModifica);
            return View(tipoAsentamiento);
        }

        // POST: TipoAsentamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoAsentamiento,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoAsentamiento tipoAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAsentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoAsentamiento.idUsuarioModifica);
            return View(tipoAsentamiento);
        }

        // GET: TipoAsentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            if (tipoAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoAsentamiento);
        }

        // POST: TipoAsentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAsentamiento tipoAsentamiento = db.TipoAsentamiento.Find(id);
            db.TipoAsentamiento.Remove(tipoAsentamiento);
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
