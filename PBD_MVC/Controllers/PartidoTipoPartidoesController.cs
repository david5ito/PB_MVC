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
    public class PartidoTipoPartidoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: PartidoTipoPartidoes
        public ActionResult Index()
        {
            var partidoTipoPartido = db.PartidoTipoPartido.Include(p => p.Partido).Include(p => p.TipoPartido).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(partidoTipoPartido.ToList());
        }

        // GET: PartidoTipoPartidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidoTipoPartido partidoTipoPartido = db.PartidoTipoPartido.Find(id);
            if (partidoTipoPartido == null)
            {
                return HttpNotFound();
            }
            return View(partidoTipoPartido);
        }

        // GET: PartidoTipoPartidoes/Create
        public ActionResult Create()
        {
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido");
            ViewBag.idTipoPartido = new SelectList(db.TipoPartido, "idTipoPartido", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: PartidoTipoPartidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartidoTipoPartido,idPartido,idTipoPartido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PartidoTipoPartido partidoTipoPartido)
        {
            if (ModelState.IsValid)
            {
                db.PartidoTipoPartido.Add(partidoTipoPartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", partidoTipoPartido.idPartido);
            ViewBag.idTipoPartido = new SelectList(db.TipoPartido, "idTipoPartido", "numero", partidoTipoPartido.idTipoPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partidoTipoPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partidoTipoPartido.idUsuarioModifica);
            return View(partidoTipoPartido);
        }

        // GET: PartidoTipoPartidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidoTipoPartido partidoTipoPartido = db.PartidoTipoPartido.Find(id);
            if (partidoTipoPartido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", partidoTipoPartido.idPartido);
            ViewBag.idTipoPartido = new SelectList(db.TipoPartido, "idTipoPartido", "numero", partidoTipoPartido.idTipoPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partidoTipoPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partidoTipoPartido.idUsuarioModifica);
            return View(partidoTipoPartido);
        }

        // POST: PartidoTipoPartidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartidoTipoPartido,idPartido,idTipoPartido,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PartidoTipoPartido partidoTipoPartido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partidoTipoPartido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", partidoTipoPartido.idPartido);
            ViewBag.idTipoPartido = new SelectList(db.TipoPartido, "idTipoPartido", "numero", partidoTipoPartido.idTipoPartido);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partidoTipoPartido.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partidoTipoPartido.idUsuarioModifica);
            return View(partidoTipoPartido);
        }

        // GET: PartidoTipoPartidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidoTipoPartido partidoTipoPartido = db.PartidoTipoPartido.Find(id);
            if (partidoTipoPartido == null)
            {
                return HttpNotFound();
            }
            return View(partidoTipoPartido);
        }

        // POST: PartidoTipoPartidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartidoTipoPartido partidoTipoPartido = db.PartidoTipoPartido.Find(id);
            db.PartidoTipoPartido.Remove(partidoTipoPartido);
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
