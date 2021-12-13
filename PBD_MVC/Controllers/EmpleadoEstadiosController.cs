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
    public class EmpleadoEstadiosController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: EmpleadoEstadios
        public ActionResult Index()
        {
            var empleadoEstadio = db.EmpleadoEstadio.Include(e => e.Empleado).Include(e => e.Estadio).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleadoEstadio.ToList());
        }

        // GET: EmpleadoEstadios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoEstadio empleadoEstadio = db.EmpleadoEstadio.Find(id);
            if (empleadoEstadio == null)
            {
                return HttpNotFound();
            }
            return View(empleadoEstadio);
        }

        // GET: EmpleadoEstadios/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre");
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: EmpleadoEstadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleadoEstadio,idEmpleado,idEstadio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoEstadio empleadoEstadio)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoEstadio.Add(empleadoEstadio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoEstadio.idEmpleado);
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", empleadoEstadio.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoEstadio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoEstadio.idUsuarioModifica);
            return View(empleadoEstadio);
        }

        // GET: EmpleadoEstadios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoEstadio empleadoEstadio = db.EmpleadoEstadio.Find(id);
            if (empleadoEstadio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoEstadio.idEmpleado);
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", empleadoEstadio.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoEstadio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoEstadio.idUsuarioModifica);
            return View(empleadoEstadio);
        }

        // POST: EmpleadoEstadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleadoEstadio,idEmpleado,idEstadio,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoEstadio empleadoEstadio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoEstadio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "nombre", empleadoEstadio.idEmpleado);
            ViewBag.idEstadio = new SelectList(db.Estadio, "idEstadio", "nombre", empleadoEstadio.idEstadio);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoEstadio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", empleadoEstadio.idUsuarioModifica);
            return View(empleadoEstadio);
        }

        // GET: EmpleadoEstadios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoEstadio empleadoEstadio = db.EmpleadoEstadio.Find(id);
            if (empleadoEstadio == null)
            {
                return HttpNotFound();
            }
            return View(empleadoEstadio);
        }

        // POST: EmpleadoEstadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoEstadio empleadoEstadio = db.EmpleadoEstadio.Find(id);
            db.EmpleadoEstadio.Remove(empleadoEstadio);
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
