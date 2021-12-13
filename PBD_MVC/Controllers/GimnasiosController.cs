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
    public class GimnasiosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Gimnasios
        public ActionResult Index()
        {
            var gimnasio = db.Gimnasio.Include(g => g.Asentamiento).Include(g => g.Usuario).Include(g => g.Usuario1);
            return View(gimnasio.ToList());
        }

        // GET: Gimnasios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            if (gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(gimnasio);
        }

        // GET: Gimnasios/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Gimnasios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGimnasio,nombre,calle,numExterior,cp,telefono,idAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Gimnasio gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Gimnasio.Add(gimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", gimnasio.idAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", gimnasio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", gimnasio.idUsuarioModifica);
            return View(gimnasio);
        }

        // GET: Gimnasios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            if (gimnasio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", gimnasio.idAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", gimnasio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", gimnasio.idUsuarioModifica);
            return View(gimnasio);
        }

        // POST: Gimnasios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGimnasio,nombre,calle,numExterior,cp,telefono,idAsentamiento,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Gimnasio gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "numero", gimnasio.idAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", gimnasio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", gimnasio.idUsuarioModifica);
            return View(gimnasio);
        }

        // GET: Gimnasios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            if (gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(gimnasio);
        }

        // POST: Gimnasios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gimnasio gimnasio = db.Gimnasio.Find(id);
            db.Gimnasio.Remove(gimnasio);
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
