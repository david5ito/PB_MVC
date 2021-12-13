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
    public class EmpleadoTipoEmpleadoesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EmpleadoTipoEmpleadoes
        public ActionResult Index()
        {
            var empleadoTipoEmpleado = db.EmpleadoTipoEmpleado.Include(e => e.Empleado).Include(e => e.TipoEmpleado).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleadoTipoEmpleado.ToList());
        }

        // GET: EmpleadoTipoEmpleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTipoEmpleado empleadoTipoEmpleado = db.EmpleadoTipoEmpleado.Find(id);
            if (empleadoTipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(empleadoTipoEmpleado);
        }

        // GET: EmpleadoTipoEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre");
            ViewBag.idTipoEmpleado = new SelectList(db.TipoEmpleado, "idTipoEmpleado", "numero");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EmpleadoTipoEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleadoTipoEmpleado,idEmpleado,idTipoEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoTipoEmpleado empleadoTipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoTipoEmpleado.Add(empleadoTipoEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoTipoEmpleado.idEmpleado);
            ViewBag.idTipoEmpleado = new SelectList(db.TipoEmpleado, "idTipoEmpleado", "numero", empleadoTipoEmpleado.idTipoEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoTipoEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoTipoEmpleado.idUsuarioModifica);
            return View(empleadoTipoEmpleado);
        }

        // GET: EmpleadoTipoEmpleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTipoEmpleado empleadoTipoEmpleado = db.EmpleadoTipoEmpleado.Find(id);
            if (empleadoTipoEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoTipoEmpleado.idEmpleado);
            ViewBag.idTipoEmpleado = new SelectList(db.TipoEmpleado, "idTipoEmpleado", "numero", empleadoTipoEmpleado.idTipoEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoTipoEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoTipoEmpleado.idUsuarioModifica);
            return View(empleadoTipoEmpleado);
        }

        // POST: EmpleadoTipoEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleadoTipoEmpleado,idEmpleado,idTipoEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoTipoEmpleado empleadoTipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoTipoEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoTipoEmpleado.idEmpleado);
            ViewBag.idTipoEmpleado = new SelectList(db.TipoEmpleado, "idTipoEmpleado", "numero", empleadoTipoEmpleado.idTipoEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoTipoEmpleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoTipoEmpleado.idUsuarioModifica);
            return View(empleadoTipoEmpleado);
        }

        // GET: EmpleadoTipoEmpleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTipoEmpleado empleadoTipoEmpleado = db.EmpleadoTipoEmpleado.Find(id);
            if (empleadoTipoEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(empleadoTipoEmpleado);
        }

        // POST: EmpleadoTipoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoTipoEmpleado empleadoTipoEmpleado = db.EmpleadoTipoEmpleado.Find(id);
            db.EmpleadoTipoEmpleado.Remove(empleadoTipoEmpleado);
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
