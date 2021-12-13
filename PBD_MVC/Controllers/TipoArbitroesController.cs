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
    public class TipoArbitroesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: TipoArbitroes
        public ActionResult Index()
        {
            var tipoArbitro = db.TipoArbitro.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoArbitro.ToList());
        }

        // GET: TipoArbitroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArbitro tipoArbitro = db.TipoArbitro.Find(id);
            if (tipoArbitro == null)
            {
                return HttpNotFound();
            }
            return View(tipoArbitro);
        }

        // GET: TipoArbitroes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: TipoArbitroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoArbitro,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoArbitro tipoArbitro)
        {
            if (ModelState.IsValid)
            {
                db.TipoArbitro.Add(tipoArbitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoArbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoArbitro.idUsuarioModifica);
            return View(tipoArbitro);
        }

        // GET: TipoArbitroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArbitro tipoArbitro = db.TipoArbitro.Find(id);
            if (tipoArbitro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoArbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoArbitro.idUsuarioModifica);
            return View(tipoArbitro);
        }

        // POST: TipoArbitroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoArbitro,numero,nombre,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoArbitro tipoArbitro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoArbitro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", tipoArbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", tipoArbitro.idUsuarioModifica);
            return View(tipoArbitro);
        }

        // GET: TipoArbitroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoArbitro tipoArbitro = db.TipoArbitro.Find(id);
            if (tipoArbitro == null)
            {
                return HttpNotFound();
            }
            return View(tipoArbitro);
        }

        // POST: TipoArbitroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoArbitro tipoArbitro = db.TipoArbitro.Find(id);
            db.TipoArbitro.Remove(tipoArbitro);
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
