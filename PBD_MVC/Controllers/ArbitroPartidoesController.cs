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
    public class ArbitroPartidoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: ArbitroPartidoes
        public ActionResult Index()
        {
            var arbitroPartido = db.ArbitroPartido.Include(a => a.Arbitro).Include(a => a.Partido).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(arbitroPartido.ToList());
        }

        // GET: ArbitroPartidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbitroPartido arbitroPartido = db.ArbitroPartido.Find(id);
            if (arbitroPartido == null)
            {
                return HttpNotFound();
            }
            return View(arbitroPartido);
        }

        // GET: ArbitroPartidoes/Create
        public ActionResult Create()
        {
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre");
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ArbitroPartidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArbitroPartido,idArbitro,idPartido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ArbitroPartido arbitroPartido)
        {
            if (ModelState.IsValid)
            {
                db.ArbitroPartido.Add(arbitroPartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre", arbitroPartido.idArbitro);
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", arbitroPartido.idPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroPartido.idUsuarioModifica);
            return View(arbitroPartido);
        }

        // GET: ArbitroPartidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbitroPartido arbitroPartido = db.ArbitroPartido.Find(id);
            if (arbitroPartido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre", arbitroPartido.idArbitro);
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", arbitroPartido.idPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroPartido.idUsuarioModifica);
            return View(arbitroPartido);
        }

        // POST: ArbitroPartidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArbitroPartido,idArbitro,idPartido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ArbitroPartido arbitroPartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbitroPartido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre", arbitroPartido.idArbitro);
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", arbitroPartido.idPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroPartido.idUsuarioModifica);
            return View(arbitroPartido);
        }

        // GET: ArbitroPartidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbitroPartido arbitroPartido = db.ArbitroPartido.Find(id);
            if (arbitroPartido == null)
            {
                return HttpNotFound();
            }
            return View(arbitroPartido);
        }

        // POST: ArbitroPartidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArbitroPartido arbitroPartido = db.ArbitroPartido.Find(id);
            db.ArbitroPartido.Remove(arbitroPartido);
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
