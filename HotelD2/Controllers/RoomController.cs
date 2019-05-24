using HotelD2.Models;
using HotelD2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelD2.Controllers
{
    public class RoomController : Controller
    {
        private RoomModel roomModel = new RoomModel();

        public ActionResult Index()
        {
            ViewBag.rooms = roomModel.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add", new Room());
        }

        [HttpPost]
        public ActionResult Add( Room room)
        {
            roomModel.create(room);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            roomModel.delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View("Edit", roomModel.findOne(id));
        }

        [HttpPost]
        public ActionResult Edit(Room room, FormCollection fc)
        {
            string id = fc["Id"];
            var currentRoom = roomModel.findOne(id);

            currentRoom.Category = room.Category;
            currentRoom.Price = room.Price;
            currentRoom.Description = room.Description;
            currentRoom.Available = room.Available;

            roomModel.update(currentRoom);

            return RedirectToAction("Index");
        }
    }
}