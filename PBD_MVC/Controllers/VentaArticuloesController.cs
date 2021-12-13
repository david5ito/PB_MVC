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
    public class VentaArticuloesController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: VentaArticuloes
        public ActionResult Index()
        {
            var ventaArticulo = db.VentaArticulo.Include(v => v.Articulo).Include(v => v.Usuario).Include(v => v.Usuario1).Include(v => v.Venta);
            return View(ventaArticulo.ToList());
        }

        // GET: VentaArticuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            return View(ventaArticulo);
        }

        // GET: VentaArticuloes/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "idVenta");
            return View();
        }

        // POST: VentaArticuloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVentaArticulo,idVenta,idArticulo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] VentaArticulo ventaArticulo)
        {
            if (ModelState.IsValid)
            {
                db.VentaArticulo.Add(ventaArticulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "nombre", ventaArticulo.idArticulo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", ventaArticulo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", ventaArticulo.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "idVenta", ventaArticulo.idVenta);
            return View(ventaArticulo);
        }

        // GET: VentaArticuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "nombre", ventaArticulo.idArticulo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", ventaArticulo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", ventaArticulo.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "idVenta", ventaArticulo.idVenta);
            return View(ventaArticulo);
        }

        // POST: VentaArticuloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVentaArticulo,idVenta,idArticulo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] VentaArticulo ventaArticulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaArticulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "nombre", ventaArticulo.idArticulo);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", ventaArticulo.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", ventaArticulo.idUsuarioModifica);
            ViewBag.idVenta = new SelectList(db.Venta, "idVenta", "idVenta", ventaArticulo.idVenta);
            return View(ventaArticulo);
        }

        // GET: VentaArticuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            if (ventaArticulo == null)
            {
                return HttpNotFound();
            }
            return View(ventaArticulo);
        }

        // POST: VentaArticuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaArticulo ventaArticulo = db.VentaArticulo.Find(id);
            db.VentaArticulo.Remove(ventaArticulo);
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
