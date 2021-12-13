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
    public class ViajeMedioTransportesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: ViajeMedioTransportes
        public ActionResult Index()
        {
            var viajeMedioTransporte = db.ViajeMedioTransporte.Include(v => v.MedioTransporte).Include(v => v.Usuario).Include(v => v.Usuario1).Include(v => v.Viaje);
            return View(viajeMedioTransporte.ToList());
        }

        // GET: ViajeMedioTransportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViajeMedioTransporte viajeMedioTransporte = db.ViajeMedioTransporte.Find(id);
            if (viajeMedioTransporte == null)
            {
                return HttpNotFound();
            }
            return View(viajeMedioTransporte);
        }

        // GET: ViajeMedioTransportes/Create
        public ActionResult Create()
        {
            ViewBag.idMedioTransporte = new SelectList(db.MedioTransporte, "idMedioTransporte", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idViaje = new SelectList(db.Viaje, "idViaje", "ciudadSalida");
            return View();
        }

        // POST: ViajeMedioTransportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idViajeMedioTransporte,idViaje,idMedioTransporte,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ViajeMedioTransporte viajeMedioTransporte)
        {
            if (ModelState.IsValid)
            {
                db.ViajeMedioTransporte.Add(viajeMedioTransporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMedioTransporte = new SelectList(db.MedioTransporte, "idMedioTransporte", "numero", viajeMedioTransporte.idMedioTransporte);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", viajeMedioTransporte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", viajeMedioTransporte.idUsuarioModifica);
            ViewBag.idViaje = new SelectList(db.Viaje, "idViaje", "ciudadSalida", viajeMedioTransporte.idViaje);
            return View(viajeMedioTransporte);
        }

        // GET: ViajeMedioTransportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViajeMedioTransporte viajeMedioTransporte = db.ViajeMedioTransporte.Find(id);
            if (viajeMedioTransporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedioTransporte = new SelectList(db.MedioTransporte, "idMedioTransporte", "numero", viajeMedioTransporte.idMedioTransporte);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", viajeMedioTransporte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", viajeMedioTransporte.idUsuarioModifica);
            ViewBag.idViaje = new SelectList(db.Viaje, "idViaje", "ciudadSalida", viajeMedioTransporte.idViaje);
            return View(viajeMedioTransporte);
        }

        // POST: ViajeMedioTransportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idViajeMedioTransporte,idViaje,idMedioTransporte,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ViajeMedioTransporte viajeMedioTransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajeMedioTransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMedioTransporte = new SelectList(db.MedioTransporte, "idMedioTransporte", "numero", viajeMedioTransporte.idMedioTransporte);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", viajeMedioTransporte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", viajeMedioTransporte.idUsuarioModifica);
            ViewBag.idViaje = new SelectList(db.Viaje, "idViaje", "ciudadSalida", viajeMedioTransporte.idViaje);
            return View(viajeMedioTransporte);
        }

        // GET: ViajeMedioTransportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViajeMedioTransporte viajeMedioTransporte = db.ViajeMedioTransporte.Find(id);
            if (viajeMedioTransporte == null)
            {
                return HttpNotFound();
            }
            return View(viajeMedioTransporte);
        }

        // POST: ViajeMedioTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViajeMedioTransporte viajeMedioTransporte = db.ViajeMedioTransporte.Find(id);
            db.ViajeMedioTransporte.Remove(viajeMedioTransporte);
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
