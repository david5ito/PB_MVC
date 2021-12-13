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
    public class PrestamoJugadorsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: PrestamoJugadors
        public ActionResult Index()
        {
            var prestamoJugador = db.PrestamoJugador.Include(p => p.Jugador).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(prestamoJugador.ToList());
        }

        // GET: PrestamoJugadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamoJugador prestamoJugador = db.PrestamoJugador.Find(id);
            if (prestamoJugador == null)
            {
                return HttpNotFound();
            }
            return View(prestamoJugador);
        }

        // GET: PrestamoJugadors/Create
        public ActionResult Create()
        {
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: PrestamoJugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPrestamoJugador,fechaInicio,fechaTermino,idJugador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PrestamoJugador prestamoJugador)
        {
            if (ModelState.IsValid)
            {
                db.PrestamoJugador.Add(prestamoJugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", prestamoJugador.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", prestamoJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", prestamoJugador.idUsuarioModifica);
            return View(prestamoJugador);
        }

        // GET: PrestamoJugadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamoJugador prestamoJugador = db.PrestamoJugador.Find(id);
            if (prestamoJugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", prestamoJugador.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", prestamoJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", prestamoJugador.idUsuarioModifica);
            return View(prestamoJugador);
        }

        // POST: PrestamoJugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPrestamoJugador,fechaInicio,fechaTermino,idJugador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PrestamoJugador prestamoJugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamoJugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJugador = new SelectList(db.Jugador, "idJugador", "nombre", prestamoJugador.idJugador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", prestamoJugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", prestamoJugador.idUsuarioModifica);
            return View(prestamoJugador);
        }

        // GET: PrestamoJugadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamoJugador prestamoJugador = db.PrestamoJugador.Find(id);
            if (prestamoJugador == null)
            {
                return HttpNotFound();
            }
            return View(prestamoJugador);
        }

        // POST: PrestamoJugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrestamoJugador prestamoJugador = db.PrestamoJugador.Find(id);
            db.PrestamoJugador.Remove(prestamoJugador);
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
