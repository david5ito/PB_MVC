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
    public class PremioTipoPremiosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: PremioTipoPremios
        public ActionResult Index()
        {
            var premioTipoPremio = db.PremioTipoPremio.Include(p => p.Premio).Include(p => p.TipoPremio).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(premioTipoPremio.ToList());
        }

        // GET: PremioTipoPremios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioTipoPremio premioTipoPremio = db.PremioTipoPremio.Find(id);
            if (premioTipoPremio == null)
            {
                return HttpNotFound();
            }
            return View(premioTipoPremio);
        }

        // GET: PremioTipoPremios/Create
        public ActionResult Create()
        {
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo");
            ViewBag.idTipoPremio = new SelectList(db.TipoPremio, "idTipoPremio", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: PremioTipoPremios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPremioTipoPremio,idPremio,idTipoPremio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PremioTipoPremio premioTipoPremio)
        {
            if (ModelState.IsValid)
            {
                db.PremioTipoPremio.Add(premioTipoPremio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo", premioTipoPremio.idPremio);
            ViewBag.idTipoPremio = new SelectList(db.TipoPremio, "idTipoPremio", "numero", premioTipoPremio.idTipoPremio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", premioTipoPremio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", premioTipoPremio.idUsuarioModifica);
            return View(premioTipoPremio);
        }

        // GET: PremioTipoPremios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioTipoPremio premioTipoPremio = db.PremioTipoPremio.Find(id);
            if (premioTipoPremio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo", premioTipoPremio.idPremio);
            ViewBag.idTipoPremio = new SelectList(db.TipoPremio, "idTipoPremio", "numero", premioTipoPremio.idTipoPremio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", premioTipoPremio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", premioTipoPremio.idUsuarioModifica);
            return View(premioTipoPremio);
        }

        // POST: PremioTipoPremios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPremioTipoPremio,idPremio,idTipoPremio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PremioTipoPremio premioTipoPremio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(premioTipoPremio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPremio = new SelectList(db.Premio, "idPremio", "codigo", premioTipoPremio.idPremio);
            ViewBag.idTipoPremio = new SelectList(db.TipoPremio, "idTipoPremio", "numero", premioTipoPremio.idTipoPremio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", premioTipoPremio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", premioTipoPremio.idUsuarioModifica);
            return View(premioTipoPremio);
        }

        // GET: PremioTipoPremios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioTipoPremio premioTipoPremio = db.PremioTipoPremio.Find(id);
            if (premioTipoPremio == null)
            {
                return HttpNotFound();
            }
            return View(premioTipoPremio);
        }

        // POST: PremioTipoPremios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PremioTipoPremio premioTipoPremio = db.PremioTipoPremio.Find(id);
            db.PremioTipoPremio.Remove(premioTipoPremio);
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
