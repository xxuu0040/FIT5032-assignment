using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment1.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assignment1.Controllers
{
    public class BookingsController : Controller
    {
        private Hotel_Model1 db = new Hotel_Model1();

        // GET: Bookings
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var bookings = db.Bookings.Where(s => s.User_id == userId).Include(b => b.Feedback).Include(b => b.Room);

            return View(bookings.ToList());
        }

        public ActionResult Calendar()
        {
            var userId = User.Identity.GetUserId();
            var bookings = db.Bookings.Where(s => s.User_id == userId).Include(b => b.Feedback).Include(b => b.Room);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create(int hotel_id, int room_id)
        {
            Booking booking = new Booking(); 
            booking.Hotel_id = hotel_id;
            booking.Room_id = room_id;
            //var booking = db.Bookings.Include(b => b.Room.Hotel).Where(b => b.Hotel_id == hotel_id && b.Room_id == room_id);
            //booking.Room.Hotel.Hotel_name = new SelectListItem(db.Bookings)
            ViewBag.Booking_id = new SelectList(db.Feedbacks, "Booking_id", "Hotel_name");
            ViewBag.Room_id = new SelectList(db.Rooms, "Room_id", "Room_type");
            ViewBag.Hotel_id = new SelectList(db.Hotels, "Hotel_id", "Hotel_name");
            return View(booking);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Booking_id,Hotel_id,Room_id,Checkin_date,Checkout_date,User_id")] Booking booking)
        {
           
            booking.User_id = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(booking);
            

            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Booking_id = new SelectList(db.Feedbacks, "Booking_id", "Hotel_name", booking.Booking_id);
            ViewBag.Room_id = new SelectList(db.Rooms, "Room_id", "Room_type", booking.Room_id);
            return View(booking);
        }

        //public ActionResult Create(String date){
            //if (null == date)
                //return RedirectToAction("Index");
            //Booking b = new Booking();
            //DateTime convertedDate = DateTime.Parse(date);
            //b.Checkin_date = convertedDate;
            //return View();}

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Booking_id = new SelectList(db.Feedbacks, "Booking_id", "Hotel_name", booking.Booking_id);
            ViewBag.Room_id = new SelectList(db.Rooms, "Room_id", "Room_type", booking.Room_id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_id,Room_id,Hotel_id,Checkin_date,Checkout_date,User_id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Booking_id = new SelectList(db.Feedbacks, "Booking_id", "Hotel_name", booking.Booking_id);
            ViewBag.Room_id = new SelectList(db.Rooms, "Room_id", "Room_type", booking.Room_id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
