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
    public class HotelSucursalsController : Controller
    {
        private ProyectoFutbolEntities1 db = new ProyectoFutbolEntities1();

        // GET: HotelSucursals
        public ActionResult Index()
        {
            var hotelSucursal = db.HotelSucursal.Include(h => h.Hotel).Include(h => h.Sucursal).Include(h => h.Usuario).Include(h => h.Usuario1);
            return View(hotelSucursal.ToList());
        }

        // GET: HotelSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelSucursal hotelSucursal = db.HotelSucursal.Find(id);
            if (hotelSucursal == null)
            {
                return HttpNotFound();
            }
            return View(hotelSucursal);
        }

        // GET: HotelSucursals/Create
        public ActionResult Create()
        {
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre");
            return View();
        }

        // POST: HotelSucursals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHotelSucursal,idHotel,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] HotelSucursal hotelSucursal)
        {
            if (ModelState.IsValid)
            {
                db.HotelSucursal.Add(hotelSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre", hotelSucursal.idHotel);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", hotelSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", hotelSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", hotelSucursal.idUsuarioModifica);
            return View(hotelSucursal);
        }

        // GET: HotelSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelSucursal hotelSucursal = db.HotelSucursal.Find(id);
            if (hotelSucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre", hotelSucursal.idHotel);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", hotelSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", hotelSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", hotelSucursal.idUsuarioModifica);
            return View(hotelSucursal);
        }

        // POST: HotelSucursals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHotelSucursal,idHotel,idSucursal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] HotelSucursal hotelSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre", hotelSucursal.idHotel);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "nombre", hotelSucursal.idSucursal);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombre", hotelSucursal.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombre", hotelSucursal.idUsuarioModifica);
            return View(hotelSucursal);
        }

        // GET: HotelSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelSucursal hotelSucursal = db.HotelSucursal.Find(id);
            if (hotelSucursal == null)
            {
                return HttpNotFound();
            }
            return View(hotelSucursal);
        }

        // POST: HotelSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelSucursal hotelSucursal = db.HotelSucursal.Find(id);
            db.HotelSucursal.Remove(hotelSucursal);
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
