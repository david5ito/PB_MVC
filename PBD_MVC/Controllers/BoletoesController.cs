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
    public class BoletoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Boletoes
        public ActionResult Index()
        {
            var boleto = db.Boleto.Include(b => b.Estadio).Include(b => b.Usuario).Include(b => b.Usuario1).Include(b => b.Zona);
            return View(boleto.ToList());
        }

        // GET: Boletoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            return View(boleto);
        }

        // GET: Boletoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "numero");
            return View();
        }

        // POST: Boletoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBoleto,numBoleto,precio,idZona,idEstadio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                db.Boleto.Add(boleto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", boleto.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", boleto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", boleto.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "numero", boleto.idZona);
            return View(boleto);
        }

        // GET: Boletoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", boleto.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", boleto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", boleto.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "numero", boleto.idZona);
            return View(boleto);
        }

        // POST: Boletoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBoleto,numBoleto,precio,idZona,idEstadio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", boleto.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", boleto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", boleto.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "numero", boleto.idZona);
            return View(boleto);
        }

        // GET: Boletoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            return View(boleto);
        }

        // POST: Boletoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            db.Boleto.Remove(boleto);
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
