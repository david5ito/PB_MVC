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
    public class TemporadasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Temporadas
        public ActionResult Index()
        {
            var temporada = db.Temporada.Include(t => t.Liga).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(temporada.ToList());
        }

        // GET: Temporadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = db.Temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // GET: Temporadas/Create
        public ActionResult Create()
        {
            ViewBag.idLiga = new SelectList(db.Liga, "idLiga", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTemporada,nombre,fechaInicio,fechaTermino,idLiga,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Temporada.Add(temporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLiga = new SelectList(db.Liga, "idLiga", "numero", temporada.idLiga);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", temporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", temporada.idUsuarioModifica);
            return View(temporada);
        }

        // GET: Temporadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = db.Temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLiga = new SelectList(db.Liga, "idLiga", "numero", temporada.idLiga);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", temporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", temporada.idUsuarioModifica);
            return View(temporada);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTemporada,nombre,fechaInicio,fechaTermino,idLiga,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLiga = new SelectList(db.Liga, "idLiga", "numero", temporada.idLiga);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", temporada.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", temporada.idUsuarioModifica);
            return View(temporada);
        }

        // GET: Temporadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = db.Temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temporada temporada = db.Temporada.Find(id);
            db.Temporada.Remove(temporada);
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
