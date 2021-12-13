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
    public class PalcoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Palcoes
        public ActionResult Index()
        {
            var palco = db.Palco.Include(p => p.Estadio).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(palco.ToList());
        }

        // GET: Palcoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palco palco = db.Palco.Find(id);
            if (palco == null)
            {
                return HttpNotFound();
            }
            return View(palco);
        }

        // GET: Palcoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Palcoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPalco,nombre,idEstadio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Palco palco)
        {
            if (ModelState.IsValid)
            {
                db.Palco.Add(palco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", palco.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", palco.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", palco.idUsuarioModifica);
            return View(palco);
        }

        // GET: Palcoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palco palco = db.Palco.Find(id);
            if (palco == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", palco.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", palco.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", palco.idUsuarioModifica);
            return View(palco);
        }

        // POST: Palcoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPalco,nombre,idEstadio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Palco palco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", palco.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", palco.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", palco.idUsuarioModifica);
            return View(palco);
        }

        // GET: Palcoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palco palco = db.Palco.Find(id);
            if (palco == null)
            {
                return HttpNotFound();
            }
            return View(palco);
        }

        // POST: Palcoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Palco palco = db.Palco.Find(id);
            db.Palco.Remove(palco);
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
