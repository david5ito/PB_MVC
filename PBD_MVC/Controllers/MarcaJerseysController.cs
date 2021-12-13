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
    public class MarcaJerseysController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: MarcaJerseys
        public ActionResult Index()
        {
            var marcaJersey = db.MarcaJersey.Include(m => m.Jersey).Include(m => m.Marca).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(marcaJersey.ToList());
        }

        // GET: MarcaJerseys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaJersey marcaJersey = db.MarcaJersey.Find(id);
            if (marcaJersey == null)
            {
                return HttpNotFound();
            }
            return View(marcaJersey);
        }

        // GET: MarcaJerseys/Create
        public ActionResult Create()
        {
            ViewBag.idJersey = new SelectList(db.Jersey, "idJersey", "numero");
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: MarcaJerseys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMarcaJersey,idMarca,idJersey,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MarcaJersey marcaJersey)
        {
            if (ModelState.IsValid)
            {
                db.MarcaJersey.Add(marcaJersey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJersey = new SelectList(db.Jersey, "idJersey", "numero", marcaJersey.idJersey);
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "numero", marcaJersey.idMarca);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", marcaJersey.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", marcaJersey.idUsuarioModifica);
            return View(marcaJersey);
        }

        // GET: MarcaJerseys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaJersey marcaJersey = db.MarcaJersey.Find(id);
            if (marcaJersey == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJersey = new SelectList(db.Jersey, "idJersey", "numero", marcaJersey.idJersey);
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "numero", marcaJersey.idMarca);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", marcaJersey.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", marcaJersey.idUsuarioModifica);
            return View(marcaJersey);
        }

        // POST: MarcaJerseys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMarcaJersey,idMarca,idJersey,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MarcaJersey marcaJersey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcaJersey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJersey = new SelectList(db.Jersey, "idJersey", "numero", marcaJersey.idJersey);
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "numero", marcaJersey.idMarca);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", marcaJersey.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", marcaJersey.idUsuarioModifica);
            return View(marcaJersey);
        }

        // GET: MarcaJerseys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaJersey marcaJersey = db.MarcaJersey.Find(id);
            if (marcaJersey == null)
            {
                return HttpNotFound();
            }
            return View(marcaJersey);
        }

        // POST: MarcaJerseys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarcaJersey marcaJersey = db.MarcaJersey.Find(id);
            db.MarcaJersey.Remove(marcaJersey);
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
