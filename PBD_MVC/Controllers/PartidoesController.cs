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
    public class PartidoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Partidoes
        public ActionResult Index()
        {
            var partido = db.Partido.Include(p => p.Equipo).Include(p => p.Equipo1).Include(p => p.Estadio).Include(p => p.Estadistica).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(partido.ToList());
        }

        // GET: Partidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: Partidoes/Create
        public ActionResult Create()
        {
            ViewBag.idEquipoLocal = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idEquipoVisitante = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre");
            ViewBag.idEstadistica = new SelectList(db.Estadistica, "idEstadistica", "idEstadistica");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Partidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartido,fecha,idEquipoLocal,idEquipoVisitante,idEstadio,idEstadistica,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Partido.Add(partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipoLocal = new SelectList(db.Equipo, "idEquipo", "nombre", partido.idEquipoLocal);
            ViewBag.idEquipoVisitante = new SelectList(db.Equipo, "idEquipo", "nombre", partido.idEquipoVisitante);
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", partido.idEstadio);
            ViewBag.idEstadistica = new SelectList(db.Estadistica, "idEstadistica", "idEstadistica", partido.idEstadistica);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partido.idUsuarioModifica);
            return View(partido);
        }

        // GET: Partidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipoLocal = new SelectList(db.Equipo, "idEquipo", "nombre", partido.idEquipoLocal);
            ViewBag.idEquipoVisitante = new SelectList(db.Equipo, "idEquipo", "nombre", partido.idEquipoVisitante);
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", partido.idEstadio);
            ViewBag.idEstadistica = new SelectList(db.Estadistica, "idEstadistica", "idEstadistica", partido.idEstadistica);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partido.idUsuarioModifica);
            return View(partido);
        }

        // POST: Partidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartido,fecha,idEquipoLocal,idEquipoVisitante,idEstadio,idEstadistica,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipoLocal = new SelectList(db.Equipo, "idEquipo", "nombre", partido.idEquipoLocal);
            ViewBag.idEquipoVisitante = new SelectList(db.Equipo, "idEquipo", "nombre", partido.idEquipoVisitante);
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", partido.idEstadio);
            ViewBag.idEstadistica = new SelectList(db.Estadistica, "idEstadistica", "idEstadistica", partido.idEstadistica);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partido.idUsuarioModifica);
            return View(partido);
        }

        // GET: Partidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // POST: Partidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partido partido = db.Partido.Find(id);
            db.Partido.Remove(partido);
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
