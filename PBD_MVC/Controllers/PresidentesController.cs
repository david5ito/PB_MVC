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
    public class PresidentesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Presidentes
        public ActionResult Index()
        {
            var presidente = db.Presidente.Include(p => p.Equipo).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(presidente.ToList());
        }

        // GET: Presidentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presidente presidente = db.Presidente.Find(id);
            if (presidente == null)
            {
                return HttpNotFound();
            }
            return View(presidente);
        }

        // GET: Presidentes/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Presidentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPresidente,nombre,apellidoPaterno,apellidoMaterno,telefono,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Presidente presidente)
        {
            if (ModelState.IsValid)
            {
                db.Presidente.Add(presidente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", presidente.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", presidente.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", presidente.idUsuarioModifica);
            return View(presidente);
        }

        // GET: Presidentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presidente presidente = db.Presidente.Find(id);
            if (presidente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", presidente.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", presidente.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", presidente.idUsuarioModifica);
            return View(presidente);
        }

        // POST: Presidentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPresidente,nombre,apellidoPaterno,apellidoMaterno,telefono,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Presidente presidente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presidente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", presidente.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", presidente.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", presidente.idUsuarioModifica);
            return View(presidente);
        }

        // GET: Presidentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presidente presidente = db.Presidente.Find(id);
            if (presidente == null)
            {
                return HttpNotFound();
            }
            return View(presidente);
        }

        // POST: Presidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presidente presidente = db.Presidente.Find(id);
            db.Presidente.Remove(presidente);
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
