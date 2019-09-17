using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model.HMS.Entity;
using Model.HMS.ViewModel;
using NHibernate;
using Services.HMS;
using Services.HMS.Helper;

namespace Web.HMS.Controllers
{
    [Authorize]
    public class HotelRoomController : Controller
    {
        private readonly IHotelReservationService _hotelReservationService;
        private ISession _session;
        public HotelRoomController()
        {
            _session = NhSessionFactory.OpenSession();
            _hotelReservationService = new HotelReservationService(_session);
        }

        #region Save

        public ActionResult AddRoomType()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult AddRoomType(Roomtype roomtype)
        {
            try
            {
                _hotelReservationService.SaveRoomType(roomtype);
                ViewBag.SuccessMessage = "Room Type Added Successfully";

            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Failed to Save!";
            }
            return View();
        }

        public ActionResult AddRoom()
        {
            try
            {
                ViewBag.roomTypes = new SelectList(_hotelReservationService.LoadAllRoomType(), "Id", "Name");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult AddRoom(RoomVm roomVm)
        {
            try
            {
                Roomtype roomtype = _hotelReservationService.GetRoomTypeById(roomVm.RoomTypeId);
                Room room = new Room();
                room.Roomno = roomVm.RoomNo;
                room.Noofadult = roomVm.NoOfAdult;
                room.Roomtype = roomtype;
                room.Description = roomVm.Description;
                room.Maxchild = roomVm.MaxChild;

                _hotelReservationService.SaveRoom(room);
                ViewBag.roomTypes = new SelectList(_hotelReservationService.LoadAllRoomType(), "Id", "Name");
                ViewBag.SuccessMessage = "Room Saved Successfully";
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Failed to Save!";
            }
            return View();
        }
        #endregion

        #region Update

        public ActionResult Edit(long id)
        {
            Roomtype roomtype = _hotelReservationService.GetRoomTypeById(id);
            return View(roomtype);
        }

        [HttpPost]
        public ActionResult Edit(Roomtype roomtype)
        {
            try
            {
                Roomtype roomtypeProxy = _hotelReservationService.GetRoomTypeById(roomtype.Id);
                roomtypeProxy.Name = roomtype.Name;
                roomtypeProxy.Description = roomtype.Description;
                roomtypeProxy.Ratepernight = roomtype.Ratepernight;
                _hotelReservationService.UpdateRoomType(roomtypeProxy);
                ViewBag.SuccessMessage = "Updated Successfully";
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Upgradation Failed";
            }
            return View(roomtype);
        }

        public ActionResult EditRoom(long id)
        {
            Room room = _hotelReservationService.GetRoomById(id);
            RoomVm roomVm = new RoomVm();
            roomVm.Id = id;
            roomVm.MaxChild = (int)room.Maxchild;
            roomVm.NoOfAdult = (int)room.Noofadult;
            roomVm.RoomNo = room.Roomno;
            roomVm.Description = room.Description;

            ViewBag.roomTypes = new SelectList(_hotelReservationService.LoadAllRoomType(), "Id", "Name", room.Roomtype.Id);
            return View(roomVm);
        }

        [HttpPost]
        public ActionResult EditRoom(RoomVm roomVm)
        {
            try
            {
                Roomtype roomtype = _hotelReservationService.GetRoomTypeById(roomVm.RoomTypeId);
                Room room = _hotelReservationService.GetRoomById(roomVm.Id);
                room.Roomno = roomVm.RoomNo;
                room.Noofadult = roomVm.NoOfAdult;
                room.Roomtype = roomtype;
                room.Description = roomVm.Description;
                room.Maxchild = roomVm.MaxChild;

                _hotelReservationService.UpdateRoom(room);
                ViewBag.roomTypes = new SelectList(_hotelReservationService.LoadAllRoomType(), "Id", "Name");
                ViewBag.SuccessMessage = "Room Updated Successfully";
                return View(new RoomVm());
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Upgradation Failed";
                throw;
            }

        }

        #endregion

        #region Delete

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Roomtype roomtype = _hotelReservationService.GetRoomTypeById(id);
            return View(roomtype);
        }

        [HttpPost]
        public ActionResult Delete(Roomtype roomtype)
        {
            try
            {
                Roomtype roomtypeProxy = _hotelReservationService.GetRoomTypeById(roomtype.Id);
                roomtypeProxy.Status = Roomtype.EntityStatus.Delete;
                foreach (var room in roomtypeProxy.Rooms)
                {
                    room.Status = Room.EntityStatus.Delete;
                }
                _hotelReservationService.UpdateRoomType(roomtypeProxy);
                ViewBag.SuccessMessage = "Deleted Successfully";
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Upgradation Failed";
            }
            return View(roomtype);
        }

        #endregion

        #region Load

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageRoomType(int draw, int start, int length)
        {
            try
            {
                IList<Roomtype> roomtypes = _hotelReservationService.LoadAllRoomType(draw, start, length);
                int count = _hotelReservationService.CountRoomType();

                var data = new List<object>();
                int sl = start + 1;
                foreach (var roomType in roomtypes)
                {
                    var str = new List<string>();
                    str.Add(sl.ToString());
                    var employeeStatus = "";
                    str.Add(roomType.Name);
                    str.Add(Convert.ToInt32(roomType.Ratepernight).ToString());

                    str.Add(LinkGenerator.GetGeneratedDetailsEditLink("Details", "Edit", "HotelRoom", roomType.Id)
                            + LinkGenerator.GetDeleteLink("Delete", "HotelRoom", roomType.Id));
                    data.Add(str);
                    sl++;
                }
                return Json(new
                {
                    draw = draw,
                    recordsTotal = count,
                    recordsFiltered = count,
                    start = start,
                    length = length,
                    data = data
                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult ManageRoom()
        {
            ViewBag.roomTypes = new SelectList(_hotelReservationService.LoadAllRoomType(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult ManageRoom(int draw, int start, int length, long roomTypeId = 0)
        {

            IList<Room> roomList = _hotelReservationService.LoadAllRooms(draw, start, length, roomTypeId);
            int count = _hotelReservationService.CountAllRooms(roomTypeId);

            var data = new List<object>();
            int sl = start + 1;
            foreach (var room in roomList)
            {
                var str = new List<string>();
                str.Add(sl.ToString());
                str.Add(room.Roomtype.Name);
                str.Add(room.Roomno);
                str.Add(Convert.ToInt32(room.Noofadult).ToString());
                str.Add(Convert.ToInt32(room.Maxchild).ToString());

                str.Add(LinkGenerator.GetGeneratedDetailsEditLink("RoomDetails", "EditRoom", "HotelRoom", room.Id)
                        + LinkGenerator.GetDeleteLink("RoomDelete", "HotelRoom", room.Id));
                data.Add(str);
                sl++;
            }
            return Json(new
            {
                draw = draw,
                recordsTotal = count,
                recordsFiltered = count,
                start = start,
                length = length,
                data = data
            });

            return View();
        }
        #endregion

    }
}