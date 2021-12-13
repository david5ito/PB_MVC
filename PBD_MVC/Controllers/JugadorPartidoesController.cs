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
    public class JugadorPartidoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: JugadorPartidoes
        public ActionResult Index()
        {
            var jugadorPartido = db.JugadorPartido.Include(j => j.Jugador).Include(j => j.Partido).Include(j => j.Usuario).Include(j => j.Usuario1);
            return View(jugadorPartido.ToList());
        }

        // GET: JugadorPartidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorPartido jugadorPartido = db.JugadorPartido.Find(id);
            if (jugadorPartido == null)
            {
                return HttpNotFound();
            }
            return View(jugadorPartido);
        }

        // GET: JugadorPartidoes/Create
        public ActionResult Create()
        {
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre");
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: JugadorPartidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJugadorPartido,idJugador,idPartido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] JugadorPartido jugadorPartido)
        {
            if (ModelState.IsValid)
            {
                db.JugadorPartido.Add(jugadorPartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorPartido.idJugador);
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", jugadorPartido.idPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPartido.idUsuarioModifica);
            return View(jugadorPartido);
        }

        // GET: JugadorPartidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorPartido jugadorPartido = db.JugadorPartido.Find(id);
            if (jugadorPartido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorPartido.idJugador);
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", jugadorPartido.idPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPartido.idUsuarioModifica);
            return View(jugadorPartido);
        }

        // POST: JugadorPartidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJugadorPartido,idJugador,idPartido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] JugadorPartido jugadorPartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugadorPartido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorPartido.idJugador);
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", jugadorPartido.idPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPartido.idUsuarioModifica);
            return View(jugadorPartido);
        }

        // GET: JugadorPartidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorPartido jugadorPartido = db.JugadorPartido.Find(id);
            if (jugadorPartido == null)
            {
                return HttpNotFound();
            }
            return View(jugadorPartido);
        }

        // POST: JugadorPartidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JugadorPartido jugadorPartido = db.JugadorPartido.Find(id);
            db.JugadorPartido.Remove(jugadorPartido);
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
