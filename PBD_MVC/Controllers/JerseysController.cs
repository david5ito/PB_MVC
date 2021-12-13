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
    public class JerseysController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Jerseys
        public ActionResult Index()
        {
            var jersey = db.Jersey.Include(j => j.Equipo).Include(j => j.Usuario).Include(j => j.Usuario1);
            return View(jersey.ToList());
        }

        // GET: Jerseys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jersey jersey = db.Jersey.Find(id);
            if (jersey == null)
            {
                return HttpNotFound();
            }
            return View(jersey);
        }

        // GET: Jerseys/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Jerseys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJersey,numero,nombre,tipografia,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Jersey jersey)
        {
            if (ModelState.IsValid)
            {
                db.Jersey.Add(jersey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", jersey.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jersey.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jersey.idUsuarioModifica);
            return View(jersey);
        }

        // GET: Jerseys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jersey jersey = db.Jersey.Find(id);
            if (jersey == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", jersey.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jersey.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jersey.idUsuarioModifica);
            return View(jersey);
        }

        // POST: Jerseys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJersey,numero,nombre,tipografia,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Jersey jersey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jersey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", jersey.idEquipo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jersey.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jersey.idUsuarioModifica);
            return View(jersey);
        }

        // GET: Jerseys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jersey jersey = db.Jersey.Find(id);
            if (jersey == null)
            {
                return HttpNotFound();
            }
            return View(jersey);
        }

        // POST: Jerseys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jersey jersey = db.Jersey.Find(id);
            db.Jersey.Remove(jersey);
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
