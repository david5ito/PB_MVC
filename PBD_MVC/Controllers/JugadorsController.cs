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
    public class JugadorsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: Jugadors
        public ActionResult Index()
        {
            var jugador = db.Jugador.Include(j => j.Contrato).Include(j => j.Dorsal).Include(j => j.Equipo).Include(j => j.Manager).Include(j => j.Nacionalidad).Include(j => j.Usuario).Include(j => j.Usuario1);
            return View(jugador.ToList());
        }

        // GET: Jugadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // GET: Jugadors/Create
        public ActionResult Create()
        {
            ViewBag.idContrato = new SelectList(db.Contrato, "idContrato", "idContrato");
            ViewBag.idDorsal = new SelectList(db.Dorsal, "idDorsal", "nombre");
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre");
            ViewBag.idManager = new SelectList(db.Manager, "idManager", "nombre");
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: Jugadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJugador,nombre,apellidoPaterno,apellidoMaterno,idNacionalidad,idManager,idContrato,idDorsal,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Jugador.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idContrato = new SelectList(db.Contrato, "idContrato", "idContrato", jugador.idContrato);
            ViewBag.idDorsal = new SelectList(db.Dorsal, "idDorsal", "nombre", jugador.idDorsal);
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", jugador.idEquipo);
            ViewBag.idManager = new SelectList(db.Manager, "idManager", "nombre", jugador.idManager);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "numero", jugador.idNacionalidad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugador.idUsuarioModifica);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.idContrato = new SelectList(db.Contrato, "idContrato", "idContrato", jugador.idContrato);
            ViewBag.idDorsal = new SelectList(db.Dorsal, "idDorsal", "nombre", jugador.idDorsal);
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", jugador.idEquipo);
            ViewBag.idManager = new SelectList(db.Manager, "idManager", "nombre", jugador.idManager);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "numero", jugador.idNacionalidad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugador.idUsuarioModifica);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJugador,nombre,apellidoPaterno,apellidoMaterno,idNacionalidad,idManager,idContrato,idDorsal,idEquipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idContrato = new SelectList(db.Contrato, "idContrato", "idContrato", jugador.idContrato);
            ViewBag.idDorsal = new SelectList(db.Dorsal, "idDorsal", "nombre", jugador.idDorsal);
            ViewBag.idEquipo = new SelectList(db.Equipo, "idEquipo", "nombre", jugador.idEquipo);
            ViewBag.idManager = new SelectList(db.Manager, "idManager", "nombre", jugador.idManager);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "numero", jugador.idNacionalidad);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", jugador.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", jugador.idUsuarioModifica);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jugador jugador = db.Jugador.Find(id);
            db.Jugador.Remove(jugador);
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
