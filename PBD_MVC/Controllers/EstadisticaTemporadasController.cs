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
    public class EstadisticaTemporadasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EstadisticaTemporadas
        public ActionResult Index()
        {
            var estadisticaTemporada = db.EstadisticaTemporada.Include(e => e.Equipo).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estadisticaTemporada.ToList());
        }

        // GET: EstadisticaTemporadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadisticaTemporada estadisticaTemporada = db.EstadisticaTemporada.Find(id);
            if (estadisticaTemporada == null)
            {
                return HttpNotFound();
            }
            return View(estadisticaTemporada);
        }

        // GET: EstadisticaTemporadas/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EstadisticaTemporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstadisticaTemporada,partidosGanados,partidosPerdidos,partidosEmpatados,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EstadisticaTemporada estadisticaTemporada)
        {
            if (ModelState.IsValid)
            {
                db.EstadisticaTemporada.Add(estadisticaTemporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", estadisticaTemporada.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadisticaTemporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadisticaTemporada.idUsuarioModifica);
            return View(estadisticaTemporada);
        }

        // GET: EstadisticaTemporadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadisticaTemporada estadisticaTemporada = db.EstadisticaTemporada.Find(id);
            if (estadisticaTemporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", estadisticaTemporada.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadisticaTemporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadisticaTemporada.idUsuarioModifica);
            return View(estadisticaTemporada);
        }

        // POST: EstadisticaTemporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstadisticaTemporada,partidosGanados,partidosPerdidos,partidosEmpatados,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EstadisticaTemporada estadisticaTemporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadisticaTemporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", estadisticaTemporada.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", estadisticaTemporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", estadisticaTemporada.idUsuarioModifica);
            return View(estadisticaTemporada);
        }

        // GET: EstadisticaTemporadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadisticaTemporada estadisticaTemporada = db.EstadisticaTemporada.Find(id);
            if (estadisticaTemporada == null)
            {
                return HttpNotFound();
            }
            return View(estadisticaTemporada);
        }

        // POST: EstadisticaTemporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadisticaTemporada estadisticaTemporada = db.EstadisticaTemporada.Find(id);
            db.EstadisticaTemporada.Remove(estadisticaTemporada);
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
