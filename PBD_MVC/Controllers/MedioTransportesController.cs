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
    public class MedioTransportesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: MedioTransportes
        public ActionResult Index()
        {
            var medioTransporte = db.MedioTransporte.Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(medioTransporte.ToList());
        }

        // GET: MedioTransportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioTransporte medioTransporte = db.MedioTransporte.Find(id);
            if (medioTransporte == null)
            {
                return HttpNotFound();
            }
            return View(medioTransporte);
        }

        // GET: MedioTransportes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: MedioTransportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMedioTransporte,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MedioTransporte medioTransporte)
        {
            if (ModelState.IsValid)
            {
                db.MedioTransporte.Add(medioTransporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", medioTransporte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", medioTransporte.idUsuarioModifica);
            return View(medioTransporte);
        }

        // GET: MedioTransportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioTransporte medioTransporte = db.MedioTransporte.Find(id);
            if (medioTransporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", medioTransporte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", medioTransporte.idUsuarioModifica);
            return View(medioTransporte);
        }

        // POST: MedioTransportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMedioTransporte,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MedioTransporte medioTransporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medioTransporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", medioTransporte.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", medioTransporte.idUsuarioModifica);
            return View(medioTransporte);
        }

        // GET: MedioTransportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedioTransporte medioTransporte = db.MedioTransporte.Find(id);
            if (medioTransporte == null)
            {
                return HttpNotFound();
            }
            return View(medioTransporte);
        }

        // POST: MedioTransportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedioTransporte medioTransporte = db.MedioTransporte.Find(id);
            db.MedioTransporte.Remove(medioTransporte);
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
