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
    public class EstadiosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Estadios
        public ActionResult Index()
        {
            var estadio = db.Estadio.Include(e => e.Asentamiento).Include(e => e.Ciudad).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estadio.ToList());
        }

        // GET: Estadios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadio estadio = db.Estadio.Find(id);
            if (estadio == null)
            {
                return HttpNotFound();
            }
            return View(estadio);
        }

        // GET: Estadios/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero");
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "num");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Estadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstadio,nombre,capacidad,calle,numExterior,cp,idAsentamiento,idCiudad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                db.Estadio.Add(estadio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", estadio.idAsentamiento);
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "num", estadio.idCiudad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadio.idUsuarioModifica);
            return View(estadio);
        }

        // GET: Estadios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadio estadio = db.Estadio.Find(id);
            if (estadio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", estadio.idAsentamiento);
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "num", estadio.idCiudad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadio.idUsuarioModifica);
            return View(estadio);
        }

        // POST: Estadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstadio,nombre,capacidad,calle,numExterior,cp,idAsentamiento,idCiudad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", estadio.idAsentamiento);
            ViewBag.idCiudad = new SelectList(db.Ciudad, "idCiudad", "num", estadio.idCiudad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadio.idUsuarioModifica);
            return View(estadio);
        }

        // GET: Estadios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadio estadio = db.Estadio.Find(id);
            if (estadio == null)
            {
                return HttpNotFound();
            }
            return View(estadio);
        }

        // POST: Estadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadio estadio = db.Estadio.Find(id);
            db.Estadio.Remove(estadio);
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
