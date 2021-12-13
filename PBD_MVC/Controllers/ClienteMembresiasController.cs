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
    public class ClienteMembresiasController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: ClienteMembresias
        public ActionResult Index()
        {
            var clienteMembresia = db.ClienteMembresia.Include(c => c.Cliente).Include(c => c.Membresia).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(clienteMembresia.ToList());
        }

        // GET: ClienteMembresias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMembresia clienteMembresia = db.ClienteMembresia.Find(id);
            if (clienteMembresia == null)
            {
                return HttpNotFound();
            }
            return View(clienteMembresia);
        }

        // GET: ClienteMembresias/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            ViewBag.idMembresia = new SelectList(db.Membresia, "idMembresia", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: ClienteMembresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClienteMembresia,idCliente,idMembresia,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteMembresia clienteMembresia)
        {
            if (ModelState.IsValid)
            {
                db.ClienteMembresia.Add(clienteMembresia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteMembresia.idCliente);
            ViewBag.idMembresia = new SelectList(db.Membresia, "idMembresia", "nombre", clienteMembresia.idMembresia);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteMembresia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteMembresia.idUsuarioModifica);
            return View(clienteMembresia);
        }

        // GET: ClienteMembresias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMembresia clienteMembresia = db.ClienteMembresia.Find(id);
            if (clienteMembresia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteMembresia.idCliente);
            ViewBag.idMembresia = new SelectList(db.Membresia, "idMembresia", "nombre", clienteMembresia.idMembresia);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteMembresia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteMembresia.idUsuarioModifica);
            return View(clienteMembresia);
        }

        // POST: ClienteMembresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClienteMembresia,idCliente,idMembresia,fecha,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ClienteMembresia clienteMembresia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clienteMembresia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Cliente, "idCliente", "nombre", clienteMembresia.idCliente);
            ViewBag.idMembresia = new SelectList(db.Membresia, "idMembresia", "nombre", clienteMembresia.idMembresia);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", clienteMembresia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", clienteMembresia.idUsuarioModifica);
            return View(clienteMembresia);
        }

        // GET: ClienteMembresias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteMembresia clienteMembresia = db.ClienteMembresia.Find(id);
            if (clienteMembresia == null)
            {
                return HttpNotFound();
            }
            return View(clienteMembresia);
        }

        // POST: ClienteMembresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteMembresia clienteMembresia = db.ClienteMembresia.Find(id);
            db.ClienteMembresia.Remove(clienteMembresia);
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
