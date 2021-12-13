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
    public class ArbitroTipoArbitroesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: ArbitroTipoArbitroes
        public ActionResult Index()
        {
            var arbitroTipoArbitro = db.ArbitroTipoArbitro.Include(a => a.Arbitro).Include(a => a.TipoArbitro).Include(a => a.Usuario).Include(a => a.Usuario1);
            return View(arbitroTipoArbitro.ToList());
        }

        // GET: ArbitroTipoArbitroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbitroTipoArbitro arbitroTipoArbitro = db.ArbitroTipoArbitro.Find(id);
            if (arbitroTipoArbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitroTipoArbitro);
        }

        // GET: ArbitroTipoArbitroes/Create
        public ActionResult Create()
        {
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre");
            ViewBag.idTipoArbitro = new SelectList(db.TipoArbitro, "idTipoArbitro", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ArbitroTipoArbitroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArbitroTipoArbitro,idArbitro,idTipoArbitro,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ArbitroTipoArbitro arbitroTipoArbitro)
        {
            if (ModelState.IsValid)
            {
                db.ArbitroTipoArbitro.Add(arbitroTipoArbitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre", arbitroTipoArbitro.idArbitro);
            ViewBag.idTipoArbitro = new SelectList(db.TipoArbitro, "idTipoArbitro", "numero", arbitroTipoArbitro.idTipoArbitro);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroTipoArbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroTipoArbitro.idUsuarioModifica);
            return View(arbitroTipoArbitro);
        }

        // GET: ArbitroTipoArbitroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbitroTipoArbitro arbitroTipoArbitro = db.ArbitroTipoArbitro.Find(id);
            if (arbitroTipoArbitro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre", arbitroTipoArbitro.idArbitro);
            ViewBag.idTipoArbitro = new SelectList(db.TipoArbitro, "idTipoArbitro", "numero", arbitroTipoArbitro.idTipoArbitro);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroTipoArbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroTipoArbitro.idUsuarioModifica);
            return View(arbitroTipoArbitro);
        }

        // POST: ArbitroTipoArbitroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArbitroTipoArbitro,idArbitro,idTipoArbitro,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ArbitroTipoArbitro arbitroTipoArbitro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbitroTipoArbitro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre", arbitroTipoArbitro.idArbitro);
            ViewBag.idTipoArbitro = new SelectList(db.TipoArbitro, "idTipoArbitro", "numero", arbitroTipoArbitro.idTipoArbitro);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroTipoArbitro.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", arbitroTipoArbitro.idUsuarioModifica);
            return View(arbitroTipoArbitro);
        }

        // GET: ArbitroTipoArbitroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArbitroTipoArbitro arbitroTipoArbitro = db.ArbitroTipoArbitro.Find(id);
            if (arbitroTipoArbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitroTipoArbitro);
        }

        // POST: ArbitroTipoArbitroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArbitroTipoArbitro arbitroTipoArbitro = db.ArbitroTipoArbitro.Find(id);
            db.ArbitroTipoArbitro.Remove(arbitroTipoArbitro);
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
