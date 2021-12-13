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
    public class EquipoFichajesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EquipoFichajes
        public ActionResult Index()
        {
            var equipoFichaje = db.EquipoFichaje.Include(e => e.Equipo).Include(e => e.Fichaje).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoFichaje.ToList());
        }

        // GET: EquipoFichajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoFichaje equipoFichaje = db.EquipoFichaje.Find(id);
            if (equipoFichaje == null)
            {
                return HttpNotFound();
            }
            return View(equipoFichaje);
        }

        // GET: EquipoFichajes/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idFichaje = new SelectList(db.Fichaje, "idFichaje", "idFichaje");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoFichajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoFichaje,idEquipo,idFichaje,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoFichaje equipoFichaje)
        {
            if (ModelState.IsValid)
            {
                db.EquipoFichaje.Add(equipoFichaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoFichaje.idEquipo);
            ViewBag.idFichaje = new SelectList(db.Fichaje, "idFichaje", "idFichaje", equipoFichaje.idFichaje);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoFichaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoFichaje.idUsuarioModifica);
            return View(equipoFichaje);
        }

        // GET: EquipoFichajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoFichaje equipoFichaje = db.EquipoFichaje.Find(id);
            if (equipoFichaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoFichaje.idEquipo);
            ViewBag.idFichaje = new SelectList(db.Fichaje, "idFichaje", "idFichaje", equipoFichaje.idFichaje);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoFichaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoFichaje.idUsuarioModifica);
            return View(equipoFichaje);
        }

        // POST: EquipoFichajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoFichaje,idEquipo,idFichaje,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoFichaje equipoFichaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoFichaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoFichaje.idEquipo);
            ViewBag.idFichaje = new SelectList(db.Fichaje, "idFichaje", "idFichaje", equipoFichaje.idFichaje);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoFichaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoFichaje.idUsuarioModifica);
            return View(equipoFichaje);
        }

        // GET: EquipoFichajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoFichaje equipoFichaje = db.EquipoFichaje.Find(id);
            if (equipoFichaje == null)
            {
                return HttpNotFound();
            }
            return View(equipoFichaje);
        }

        // POST: EquipoFichajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoFichaje equipoFichaje = db.EquipoFichaje.Find(id);
            db.EquipoFichaje.Remove(equipoFichaje);
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
