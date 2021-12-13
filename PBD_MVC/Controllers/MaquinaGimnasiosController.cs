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
    public class MaquinaGimnasiosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: MaquinaGimnasios
        public ActionResult Index()
        {
            var maquinaGimnasio = db.MaquinaGimnasio.Include(m => m.Gimnasio).Include(m => m.Maquina).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(maquinaGimnasio.ToList());
        }

        // GET: MaquinaGimnasios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaquinaGimnasio maquinaGimnasio = db.MaquinaGimnasio.Find(id);
            if (maquinaGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(maquinaGimnasio);
        }

        // GET: MaquinaGimnasios/Create
        public ActionResult Create()
        {
            ViewBag.idGimnasio = new SelectList(db.Gimnasio, "idGimnasio", "nombre");
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: MaquinaGimnasios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMaquinaGimnasio,idMaquina,idGimnasio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MaquinaGimnasio maquinaGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.MaquinaGimnasio.Add(maquinaGimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGimnasio = new SelectList(db.Gimnasio, "idGimnasio", "nombre", maquinaGimnasio.idGimnasio);
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo", maquinaGimnasio.idMaquina);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", maquinaGimnasio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", maquinaGimnasio.idUsuarioModifica);
            return View(maquinaGimnasio);
        }

        // GET: MaquinaGimnasios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaquinaGimnasio maquinaGimnasio = db.MaquinaGimnasio.Find(id);
            if (maquinaGimnasio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGimnasio = new SelectList(db.Gimnasio, "idGimnasio", "nombre", maquinaGimnasio.idGimnasio);
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo", maquinaGimnasio.idMaquina);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", maquinaGimnasio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", maquinaGimnasio.idUsuarioModifica);
            return View(maquinaGimnasio);
        }

        // POST: MaquinaGimnasios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMaquinaGimnasio,idMaquina,idGimnasio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MaquinaGimnasio maquinaGimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maquinaGimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGimnasio = new SelectList(db.Gimnasio, "idGimnasio", "nombre", maquinaGimnasio.idGimnasio);
            ViewBag.idMaquina = new SelectList(db.Maquina, "idMaquina", "codigo", maquinaGimnasio.idMaquina);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", maquinaGimnasio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", maquinaGimnasio.idUsuarioModifica);
            return View(maquinaGimnasio);
        }

        // GET: MaquinaGimnasios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaquinaGimnasio maquinaGimnasio = db.MaquinaGimnasio.Find(id);
            if (maquinaGimnasio == null)
            {
                return HttpNotFound();
            }
            return View(maquinaGimnasio);
        }

        // POST: MaquinaGimnasios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaquinaGimnasio maquinaGimnasio = db.MaquinaGimnasio.Find(id);
            db.MaquinaGimnasio.Remove(maquinaGimnasio);
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
