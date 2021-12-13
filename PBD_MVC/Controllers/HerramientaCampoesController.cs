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
    public class HerramientaCampoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: HerramientaCampoes
        public ActionResult Index()
        {
            var herramientaCampo = db.HerramientaCampo.Include(h => h.Campo).Include(h => h.Herramienta).Include(h => h.Usuario).Include(h => h.Usuario1);
            return View(herramientaCampo.ToList());
        }

        // GET: HerramientaCampoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerramientaCampo herramientaCampo = db.HerramientaCampo.Find(id);
            if (herramientaCampo == null)
            {
                return HttpNotFound();
            }
            return View(herramientaCampo);
        }

        // GET: HerramientaCampoes/Create
        public ActionResult Create()
        {
            ViewBag.idCampo = new SelectList(db.Campo, "idCampo", "nombre");
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: HerramientaCampoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHerramientaCampo,idHerramienta,idCampo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] HerramientaCampo herramientaCampo)
        {
            if (ModelState.IsValid)
            {
                db.HerramientaCampo.Add(herramientaCampo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCampo = new SelectList(db.Campo, "idCampo", "nombre", herramientaCampo.idCampo);
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero", herramientaCampo.idHerramienta);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", herramientaCampo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", herramientaCampo.idUsuarioModifica);
            return View(herramientaCampo);
        }

        // GET: HerramientaCampoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerramientaCampo herramientaCampo = db.HerramientaCampo.Find(id);
            if (herramientaCampo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCampo = new SelectList(db.Campo, "idCampo", "nombre", herramientaCampo.idCampo);
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero", herramientaCampo.idHerramienta);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", herramientaCampo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", herramientaCampo.idUsuarioModifica);
            return View(herramientaCampo);
        }

        // POST: HerramientaCampoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHerramientaCampo,idHerramienta,idCampo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] HerramientaCampo herramientaCampo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herramientaCampo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCampo = new SelectList(db.Campo, "idCampo", "nombre", herramientaCampo.idCampo);
            ViewBag.idHerramienta = new SelectList(db.Herramienta, "idHerramienta", "numero", herramientaCampo.idHerramienta);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", herramientaCampo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", herramientaCampo.idUsuarioModifica);
            return View(herramientaCampo);
        }

        // GET: HerramientaCampoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerramientaCampo herramientaCampo = db.HerramientaCampo.Find(id);
            if (herramientaCampo == null)
            {
                return HttpNotFound();
            }
            return View(herramientaCampo);
        }

        // POST: HerramientaCampoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HerramientaCampo herramientaCampo = db.HerramientaCampo.Find(id);
            db.HerramientaCampo.Remove(herramientaCampo);
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
