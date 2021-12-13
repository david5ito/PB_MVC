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
    public class JugadorEntrenamientoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: JugadorEntrenamientoes
        public ActionResult Index()
        {
            var jugadorEntrenamiento = db.JugadorEntrenamiento.Include(j => j.Entrenamiento).Include(j => j.Jugador).Include(j => j.Usuario).Include(j => j.Usuario1);
            return View(jugadorEntrenamiento.ToList());
        }

        // GET: JugadorEntrenamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorEntrenamiento jugadorEntrenamiento = db.JugadorEntrenamiento.Find(id);
            if (jugadorEntrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(jugadorEntrenamiento);
        }

        // GET: JugadorEntrenamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre");
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: JugadorEntrenamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJugadorEntrenamiento,idJugador,idEntrenamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] JugadorEntrenamiento jugadorEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.JugadorEntrenamiento.Add(jugadorEntrenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", jugadorEntrenamiento.idEntrenamiento);
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorEntrenamiento.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorEntrenamiento.idUsuarioModifica);
            return View(jugadorEntrenamiento);
        }

        // GET: JugadorEntrenamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorEntrenamiento jugadorEntrenamiento = db.JugadorEntrenamiento.Find(id);
            if (jugadorEntrenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", jugadorEntrenamiento.idEntrenamiento);
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorEntrenamiento.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorEntrenamiento.idUsuarioModifica);
            return View(jugadorEntrenamiento);
        }

        // POST: JugadorEntrenamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJugadorEntrenamiento,idJugador,idEntrenamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] JugadorEntrenamiento jugadorEntrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugadorEntrenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEntrenamiento = new SelectList(db.Entrenamiento, "idEntrenamiento", "nombre", jugadorEntrenamiento.idEntrenamiento);
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorEntrenamiento.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorEntrenamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorEntrenamiento.idUsuarioModifica);
            return View(jugadorEntrenamiento);
        }

        // GET: JugadorEntrenamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorEntrenamiento jugadorEntrenamiento = db.JugadorEntrenamiento.Find(id);
            if (jugadorEntrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(jugadorEntrenamiento);
        }

        // POST: JugadorEntrenamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JugadorEntrenamiento jugadorEntrenamiento = db.JugadorEntrenamiento.Find(id);
            db.JugadorEntrenamiento.Remove(jugadorEntrenamiento);
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
