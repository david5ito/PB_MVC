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
    public class TemporadaEstadisticaTemporadasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: TemporadaEstadisticaTemporadas
        public ActionResult Index()
        {
            var temporadaEstadisticaTemporada = db.TemporadaEstadisticaTemporada.Include(t => t.EstadisticaTemporada).Include(t => t.Temporada).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(temporadaEstadisticaTemporada.ToList());
        }

        // GET: TemporadaEstadisticaTemporadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporadaEstadisticaTemporada temporadaEstadisticaTemporada = db.TemporadaEstadisticaTemporada.Find(id);
            if (temporadaEstadisticaTemporada == null)
            {
                return HttpNotFound();
            }
            return View(temporadaEstadisticaTemporada);
        }

        // GET: TemporadaEstadisticaTemporadas/Create
        public ActionResult Create()
        {
            ViewBag.idEstadisticaTemporada = new SelectList(db.EstadisticaTemporada, "idEstadisticaTemporada", "idEstadisticaTemporada");
            ViewBag.idTemporada = new SelectList(db.Temporada, "idTemporada", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TemporadaEstadisticaTemporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTemporadaEstadisticaTemporada,idTemporada,idEstadisticaTemporada,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TemporadaEstadisticaTemporada temporadaEstadisticaTemporada)
        {
            if (ModelState.IsValid)
            {
                db.TemporadaEstadisticaTemporada.Add(temporadaEstadisticaTemporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstadisticaTemporada = new SelectList(db.EstadisticaTemporada, "idEstadisticaTemporada", "idEstadisticaTemporada", temporadaEstadisticaTemporada.idEstadisticaTemporada);
            ViewBag.idTemporada = new SelectList(db.Temporada, "idTemporada", "nombre", temporadaEstadisticaTemporada.idTemporada);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", temporadaEstadisticaTemporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", temporadaEstadisticaTemporada.idUsuarioModifica);
            return View(temporadaEstadisticaTemporada);
        }

        // GET: TemporadaEstadisticaTemporadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporadaEstadisticaTemporada temporadaEstadisticaTemporada = db.TemporadaEstadisticaTemporada.Find(id);
            if (temporadaEstadisticaTemporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadisticaTemporada = new SelectList(db.EstadisticaTemporada, "idEstadisticaTemporada", "idEstadisticaTemporada", temporadaEstadisticaTemporada.idEstadisticaTemporada);
            ViewBag.idTemporada = new SelectList(db.Temporada, "idTemporada", "nombre", temporadaEstadisticaTemporada.idTemporada);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", temporadaEstadisticaTemporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", temporadaEstadisticaTemporada.idUsuarioModifica);
            return View(temporadaEstadisticaTemporada);
        }

        // POST: TemporadaEstadisticaTemporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTemporadaEstadisticaTemporada,idTemporada,idEstadisticaTemporada,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TemporadaEstadisticaTemporada temporadaEstadisticaTemporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporadaEstadisticaTemporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadisticaTemporada = new SelectList(db.EstadisticaTemporada, "idEstadisticaTemporada", "idEstadisticaTemporada", temporadaEstadisticaTemporada.idEstadisticaTemporada);
            ViewBag.idTemporada = new SelectList(db.Temporada, "idTemporada", "nombre", temporadaEstadisticaTemporada.idTemporada);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", temporadaEstadisticaTemporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", temporadaEstadisticaTemporada.idUsuarioModifica);
            return View(temporadaEstadisticaTemporada);
        }

        // GET: TemporadaEstadisticaTemporadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporadaEstadisticaTemporada temporadaEstadisticaTemporada = db.TemporadaEstadisticaTemporada.Find(id);
            if (temporadaEstadisticaTemporada == null)
            {
                return HttpNotFound();
            }
            return View(temporadaEstadisticaTemporada);
        }

        // POST: TemporadaEstadisticaTemporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemporadaEstadisticaTemporada temporadaEstadisticaTemporada = db.TemporadaEstadisticaTemporada.Find(id);
            db.TemporadaEstadisticaTemporada.Remove(temporadaEstadisticaTemporada);
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
