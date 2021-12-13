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
    public class FichajesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Fichajes
        public ActionResult Index()
        {
            var fichaje = db.Fichaje.Include(f => f.Jugador).Include(f => f.Usuario).Include(f => f.Usuario1);
            return View(fichaje.ToList());
        }

        // GET: Fichajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichaje fichaje = db.Fichaje.Find(id);
            if (fichaje == null)
            {
                return HttpNotFound();
            }
            return View(fichaje);
        }

        // GET: Fichajes/Create
        public ActionResult Create()
        {
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Fichajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFichaje,precio,idJugador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Fichaje fichaje)
        {
            if (ModelState.IsValid)
            {
                db.Fichaje.Add(fichaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", fichaje.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", fichaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", fichaje.idUsuarioModifica);
            return View(fichaje);
        }

        // GET: Fichajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichaje fichaje = db.Fichaje.Find(id);
            if (fichaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", fichaje.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", fichaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", fichaje.idUsuarioModifica);
            return View(fichaje);
        }

        // POST: Fichajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFichaje,precio,idJugador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Fichaje fichaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", fichaje.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", fichaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", fichaje.idUsuarioModifica);
            return View(fichaje);
        }

        // GET: Fichajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fichaje fichaje = db.Fichaje.Find(id);
            if (fichaje == null)
            {
                return HttpNotFound();
            }
            return View(fichaje);
        }

        // POST: Fichajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fichaje fichaje = db.Fichaje.Find(id);
            db.Fichaje.Remove(fichaje);
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
