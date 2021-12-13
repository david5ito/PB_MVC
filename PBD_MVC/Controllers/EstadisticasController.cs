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
    public class EstadisticasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Estadisticas
        public ActionResult Index()
        {
            var estadistica = db.Estadistica.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estadistica.ToList());
        }

        // GET: Estadisticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadistica estadistica = db.Estadistica.Find(id);
            if (estadistica == null)
            {
                return HttpNotFound();
            }
            return View(estadistica);
        }

        // GET: Estadisticas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Estadisticas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstadistica,numGoles,numFaltas,tarjetasAmarillas,tarjetasRojas,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estadistica estadistica)
        {
            if (ModelState.IsValid)
            {
                db.Estadistica.Add(estadistica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadistica.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadistica.idUsuarioModifica);
            return View(estadistica);
        }

        // GET: Estadisticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadistica estadistica = db.Estadistica.Find(id);
            if (estadistica == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadistica.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadistica.idUsuarioModifica);
            return View(estadistica);
        }

        // POST: Estadisticas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstadistica,numGoles,numFaltas,tarjetasAmarillas,tarjetasRojas,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estadistica estadistica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadistica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadistica.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadistica.idUsuarioModifica);
            return View(estadistica);
        }

        // GET: Estadisticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estadistica estadistica = db.Estadistica.Find(id);
            if (estadistica == null)
            {
                return HttpNotFound();
            }
            return View(estadistica);
        }

        // POST: Estadisticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estadistica estadistica = db.Estadistica.Find(id);
            db.Estadistica.Remove(estadistica);
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
