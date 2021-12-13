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
    public class ViajesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Viajes
        public ActionResult Index()
        {
            var viaje = db.Viaje.Include(v => v.Equipo).Include(v => v.Hotel).Include(v => v.Usuario).Include(v => v.Usuario1);
            return View(viaje.ToList());
        }

        // GET: Viajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // GET: Viajes/Create
        public ActionResult Create()
        {
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Viajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idViaje,ciudadSalida,ciudadDestino,fecha,idHotel,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Viaje.Add(viaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", viaje.idEquipo);
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre", viaje.idHotel);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", viaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", viaje.idUsuarioModifica);
            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", viaje.idEquipo);
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre", viaje.idHotel);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", viaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", viaje.idUsuarioModifica);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idViaje,ciudadSalida,ciudadDestino,fecha,idHotel,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", viaje.idEquipo);
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre", viaje.idHotel);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", viaje.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", viaje.idUsuarioModifica);
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = db.Viaje.Find(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viaje viaje = db.Viaje.Find(id);
            db.Viaje.Remove(viaje);
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
