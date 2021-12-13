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
    public class ArbitroesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Arbitroes
        public ActionResult Index()
        {
            var arbitro = db.Arbitro.Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(arbitro.ToList());
        }

        // GET: Arbitroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbitro arbitro = db.Arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // GET: Arbitroes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Arbitroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArbitro,nombre,apellidoPaterno,apellidoMaterno,telefono,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                db.Arbitro.Add(arbitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitro.idUsuarioModifica);
            return View(arbitro);
        }

        // GET: Arbitroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbitro arbitro = db.Arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitro.idUsuarioModifica);
            return View(arbitro);
        }

        // POST: Arbitroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArbitro,nombre,apellidoPaterno,apellidoMaterno,telefono,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbitro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitro.idUsuarioModifica);
            return View(arbitro);
        }

        // GET: Arbitroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbitro arbitro = db.Arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // POST: Arbitroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arbitro arbitro = db.Arbitro.Find(id);
            db.Arbitro.Remove(arbitro);
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
