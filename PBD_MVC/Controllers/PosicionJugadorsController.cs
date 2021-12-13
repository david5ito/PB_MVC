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
    public class PosicionJugadorsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: PosicionJugadors
        public ActionResult Index()
        {
            var posicionJugador = db.PosicionJugador.Include(p => p.Jugador).Include(p => p.Posicion).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(posicionJugador.ToList());
        }

        // GET: PosicionJugadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosicionJugador posicionJugador = db.PosicionJugador.Find(id);
            if (posicionJugador == null)
            {
                return HttpNotFound();
            }
            return View(posicionJugador);
        }

        // GET: PosicionJugadors/Create
        public ActionResult Create()
        {
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre");
            ViewBag.idPosicion = new SelectList(db.Posicion, "idPosicion", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: PosicionJugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPosicionJugador,idPosicion,idJugador,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PosicionJugador posicionJugador)
        {
            if (ModelState.IsValid)
            {
                db.PosicionJugador.Add(posicionJugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", posicionJugador.idJugador);
            ViewBag.idPosicion = new SelectList(db.Posicion, "idPosicion", "nombre", posicionJugador.idPosicion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", posicionJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", posicionJugador.idUsuarioModifica);
            return View(posicionJugador);
        }

        // GET: PosicionJugadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosicionJugador posicionJugador = db.PosicionJugador.Find(id);
            if (posicionJugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", posicionJugador.idJugador);
            ViewBag.idPosicion = new SelectList(db.Posicion, "idPosicion", "nombre", posicionJugador.idPosicion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", posicionJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", posicionJugador.idUsuarioModifica);
            return View(posicionJugador);
        }

        // POST: PosicionJugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPosicionJugador,idPosicion,idJugador,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PosicionJugador posicionJugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posicionJugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", posicionJugador.idJugador);
            ViewBag.idPosicion = new SelectList(db.Posicion, "idPosicion", "nombre", posicionJugador.idPosicion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", posicionJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", posicionJugador.idUsuarioModifica);
            return View(posicionJugador);
        }

        // GET: PosicionJugadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosicionJugador posicionJugador = db.PosicionJugador.Find(id);
            if (posicionJugador == null)
            {
                return HttpNotFound();
            }
            return View(posicionJugador);
        }

        // POST: PosicionJugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PosicionJugador posicionJugador = db.PosicionJugador.Find(id);
            db.PosicionJugador.Remove(posicionJugador);
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
