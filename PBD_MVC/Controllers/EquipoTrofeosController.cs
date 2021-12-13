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
    public class EquipoTrofeosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EquipoTrofeos
        public ActionResult Index()
        {
            var equipoTrofeo = db.EquipoTrofeo.Include(e => e.Equipo).Include(e => e.Trofeo).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoTrofeo.ToList());
        }

        // GET: EquipoTrofeos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoTrofeo equipoTrofeo = db.EquipoTrofeo.Find(id);
            if (equipoTrofeo == null)
            {
                return HttpNotFound();
            }
            return View(equipoTrofeo);
        }

        // GET: EquipoTrofeos/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idTrofeo = new SelectList(db.Trofeo, "idTrofeo", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoTrofeos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoTrofeo,idEquipo,idTrofeo,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoTrofeo equipoTrofeo)
        {
            if (ModelState.IsValid)
            {
                db.EquipoTrofeo.Add(equipoTrofeo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoTrofeo.idEquipo);
            ViewBag.idTrofeo = new SelectList(db.Trofeo, "idTrofeo", "numero", equipoTrofeo.idTrofeo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoTrofeo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoTrofeo.idUsuarioModifica);
            return View(equipoTrofeo);
        }

        // GET: EquipoTrofeos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoTrofeo equipoTrofeo = db.EquipoTrofeo.Find(id);
            if (equipoTrofeo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoTrofeo.idEquipo);
            ViewBag.idTrofeo = new SelectList(db.Trofeo, "idTrofeo", "numero", equipoTrofeo.idTrofeo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoTrofeo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoTrofeo.idUsuarioModifica);
            return View(equipoTrofeo);
        }

        // POST: EquipoTrofeos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoTrofeo,idEquipo,idTrofeo,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoTrofeo equipoTrofeo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoTrofeo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoTrofeo.idEquipo);
            ViewBag.idTrofeo = new SelectList(db.Trofeo, "idTrofeo", "numero", equipoTrofeo.idTrofeo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoTrofeo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoTrofeo.idUsuarioModifica);
            return View(equipoTrofeo);
        }

        // GET: EquipoTrofeos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoTrofeo equipoTrofeo = db.EquipoTrofeo.Find(id);
            if (equipoTrofeo == null)
            {
                return HttpNotFound();
            }
            return View(equipoTrofeo);
        }

        // POST: EquipoTrofeos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoTrofeo equipoTrofeo = db.EquipoTrofeo.Find(id);
            db.EquipoTrofeo.Remove(equipoTrofeo);
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
