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
    public class PartidoPatrocinadorsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: PartidoPatrocinadors
        public ActionResult Index()
        {
            var partidoPatrocinador = db.PartidoPatrocinador.Include(p => p.Partido).Include(p => p.Patrocinador).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(partidoPatrocinador.ToList());
        }

        // GET: PartidoPatrocinadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidoPatrocinador partidoPatrocinador = db.PartidoPatrocinador.Find(id);
            if (partidoPatrocinador == null)
            {
                return HttpNotFound();
            }
            return View(partidoPatrocinador);
        }

        // GET: PartidoPatrocinadors/Create
        public ActionResult Create()
        {
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido");
            ViewBag.idPatrocinador = new SelectList(db.Patrocinador, "idPatrocinador", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: PartidoPatrocinadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartidoPatrocinador,idPartido,idPatrocinador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PartidoPatrocinador partidoPatrocinador)
        {
            if (ModelState.IsValid)
            {
                db.PartidoPatrocinador.Add(partidoPatrocinador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", partidoPatrocinador.idPartido);
            ViewBag.idPatrocinador = new SelectList(db.Patrocinador, "idPatrocinador", "numero", partidoPatrocinador.idPatrocinador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partidoPatrocinador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partidoPatrocinador.idUsuarioModifica);
            return View(partidoPatrocinador);
        }

        // GET: PartidoPatrocinadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidoPatrocinador partidoPatrocinador = db.PartidoPatrocinador.Find(id);
            if (partidoPatrocinador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", partidoPatrocinador.idPartido);
            ViewBag.idPatrocinador = new SelectList(db.Patrocinador, "idPatrocinador", "numero", partidoPatrocinador.idPatrocinador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partidoPatrocinador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partidoPatrocinador.idUsuarioModifica);
            return View(partidoPatrocinador);
        }

        // POST: PartidoPatrocinadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartidoPatrocinador,idPartido,idPatrocinador,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] PartidoPatrocinador partidoPatrocinador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partidoPatrocinador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPartido = new SelectList(db.Partido, "idPartido", "idPartido", partidoPatrocinador.idPartido);
            ViewBag.idPatrocinador = new SelectList(db.Patrocinador, "idPatrocinador", "numero", partidoPatrocinador.idPatrocinador);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", partidoPatrocinador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", partidoPatrocinador.idUsuarioModifica);
            return View(partidoPatrocinador);
        }

        // GET: PartidoPatrocinadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartidoPatrocinador partidoPatrocinador = db.PartidoPatrocinador.Find(id);
            if (partidoPatrocinador == null)
            {
                return HttpNotFound();
            }
            return View(partidoPatrocinador);
        }

        // POST: PartidoPatrocinadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartidoPatrocinador partidoPatrocinador = db.PartidoPatrocinador.Find(id);
            db.PartidoPatrocinador.Remove(partidoPatrocinador);
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
