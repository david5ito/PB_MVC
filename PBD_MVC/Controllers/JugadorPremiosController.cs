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
    public class JugadorPremiosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: JugadorPremios
        public ActionResult Index()
        {
            var jugadorPremio = db.JugadorPremio.Include(j => j.Jugador).Include(j => j.Premio).Include(j => j.Usuario).Include(j => j.Usuario1);
            return View(jugadorPremio.ToList());
        }

        // GET: JugadorPremios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorPremio jugadorPremio = db.JugadorPremio.Find(id);
            if (jugadorPremio == null)
            {
                return HttpNotFound();
            }
            return View(jugadorPremio);
        }

        // GET: JugadorPremios/Create
        public ActionResult Create()
        {
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre");
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: JugadorPremios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJugadorPremio,idJugador,idPremio,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] JugadorPremio jugadorPremio)
        {
            if (ModelState.IsValid)
            {
                db.JugadorPremio.Add(jugadorPremio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorPremio.idJugador);
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo", jugadorPremio.idPremio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPremio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPremio.idUsuarioModifica);
            return View(jugadorPremio);
        }

        // GET: JugadorPremios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorPremio jugadorPremio = db.JugadorPremio.Find(id);
            if (jugadorPremio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorPremio.idJugador);
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo", jugadorPremio.idPremio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPremio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPremio.idUsuarioModifica);
            return View(jugadorPremio);
        }

        // POST: JugadorPremios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJugadorPremio,idJugador,idPremio,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] JugadorPremio jugadorPremio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugadorPremio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", jugadorPremio.idJugador);
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo", jugadorPremio.idPremio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPremio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugadorPremio.idUsuarioModifica);
            return View(jugadorPremio);
        }

        // GET: JugadorPremios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JugadorPremio jugadorPremio = db.JugadorPremio.Find(id);
            if (jugadorPremio == null)
            {
                return HttpNotFound();
            }
            return View(jugadorPremio);
        }

        // POST: JugadorPremios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JugadorPremio jugadorPremio = db.JugadorPremio.Find(id);
            db.JugadorPremio.Remove(jugadorPremio);
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
