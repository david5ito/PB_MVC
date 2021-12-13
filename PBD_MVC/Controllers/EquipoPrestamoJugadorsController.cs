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
    public class EquipoPrestamoJugadorsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EquipoPrestamoJugadors
        public ActionResult Index()
        {
            var equipoPrestamoJugador = db.EquipoPrestamoJugador.Include(e => e.Equipo).Include(e => e.PrestamoJugador).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(equipoPrestamoJugador.ToList());
        }

        // GET: EquipoPrestamoJugadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoPrestamoJugador equipoPrestamoJugador = db.EquipoPrestamoJugador.Find(id);
            if (equipoPrestamoJugador == null)
            {
                return HttpNotFound();
            }
            return View(equipoPrestamoJugador);
        }

        // GET: EquipoPrestamoJugadors/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idPrestamoJugador = new SelectList(db.PrestamoJugador, "idPrestamoJugador", "idPrestamoJugador");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EquipoPrestamoJugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipoPrestamoJugador,idEquipo,idPrestamoJugador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoPrestamoJugador equipoPrestamoJugador)
        {
            if (ModelState.IsValid)
            {
                db.EquipoPrestamoJugador.Add(equipoPrestamoJugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoPrestamoJugador.idEquipo);
            ViewBag.idPrestamoJugador = new SelectList(db.PrestamoJugador, "idPrestamoJugador", "idPrestamoJugador", equipoPrestamoJugador.idPrestamoJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoPrestamoJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoPrestamoJugador.idUsuarioModifica);
            return View(equipoPrestamoJugador);
        }

        // GET: EquipoPrestamoJugadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoPrestamoJugador equipoPrestamoJugador = db.EquipoPrestamoJugador.Find(id);
            if (equipoPrestamoJugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoPrestamoJugador.idEquipo);
            ViewBag.idPrestamoJugador = new SelectList(db.PrestamoJugador, "idPrestamoJugador", "idPrestamoJugador", equipoPrestamoJugador.idPrestamoJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoPrestamoJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoPrestamoJugador.idUsuarioModifica);
            return View(equipoPrestamoJugador);
        }

        // POST: EquipoPrestamoJugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipoPrestamoJugador,idEquipo,idPrestamoJugador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EquipoPrestamoJugador equipoPrestamoJugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoPrestamoJugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", equipoPrestamoJugador.idEquipo);
            ViewBag.idPrestamoJugador = new SelectList(db.PrestamoJugador, "idPrestamoJugador", "idPrestamoJugador", equipoPrestamoJugador.idPrestamoJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", equipoPrestamoJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", equipoPrestamoJugador.idUsuarioModifica);
            return View(equipoPrestamoJugador);
        }

        // GET: EquipoPrestamoJugadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoPrestamoJugador equipoPrestamoJugador = db.EquipoPrestamoJugador.Find(id);
            if (equipoPrestamoJugador == null)
            {
                return HttpNotFound();
            }
            return View(equipoPrestamoJugador);
        }

        // POST: EquipoPrestamoJugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoPrestamoJugador equipoPrestamoJugador = db.EquipoPrestamoJugador.Find(id);
            db.EquipoPrestamoJugador.Remove(equipoPrestamoJugador);
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
