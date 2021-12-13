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
    public class MembresiasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Membresias
        public ActionResult Index()
        {
            var membresia = db.Membresia.Include(m => m.Palco).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(membresia.ToList());
        }

        // GET: Membresias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia membresia = db.Membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            return View(membresia);
        }

        // GET: Membresias/Create
        public ActionResult Create()
        {
            ViewBag.idPalco = new SelectList(db.Palco, "idPalco", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Membresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMembresia,nombre,precio,idPalco,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Membresia membresia)
        {
            if (ModelState.IsValid)
            {
                db.Membresia.Add(membresia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPalco = new SelectList(db.Palco, "idPalco", "nombre", membresia.idPalco);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", membresia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", membresia.idUsuarioModifica);
            return View(membresia);
        }

        // GET: Membresias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia membresia = db.Membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPalco = new SelectList(db.Palco, "idPalco", "nombre", membresia.idPalco);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", membresia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", membresia.idUsuarioModifica);
            return View(membresia);
        }

        // POST: Membresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMembresia,nombre,precio,idPalco,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Membresia membresia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membresia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPalco = new SelectList(db.Palco, "idPalco", "nombre", membresia.idPalco);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", membresia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", membresia.idUsuarioModifica);
            return View(membresia);
        }

        // GET: Membresias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membresia membresia = db.Membresia.Find(id);
            if (membresia == null)
            {
                return HttpNotFound();
            }
            return View(membresia);
        }

        // POST: Membresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membresia membresia = db.Membresia.Find(id);
            db.Membresia.Remove(membresia);
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
