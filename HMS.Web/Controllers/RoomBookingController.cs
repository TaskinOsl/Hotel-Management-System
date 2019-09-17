using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.HMS.Entity;
using Model.HMS.ViewModel;
using NHibernate;
using Services.HMS;
using Services.HMS.Helper;

namespace Web.HMS.Controllers
{
    public class RoomBookingController : Controller
    {
        private readonly IHotelReservationService _hotelReservationService;
        private ISession _session;
        public RoomBookingController()
        {
            _session = NhSessionFactory.OpenSession();
            _hotelReservationService = new HotelReservationService(_session);
        }

        #region Booking

        [HttpGet]
        public ActionResult Booking(string message, int type = 0)
        {
            List<SelectListItem> billingTypes = new List<SelectListItem>();
            billingTypes.Add(new SelectListItem() { Text = "Cash", Value = "1" });
            billingTypes.Add(new SelectListItem() { Text = "Card", Value = "2" });

            ViewBag.billingTypes = new SelectList(billingTypes, "Value", "Text");

            IList<Roomtype> roomTypes = _hotelReservationService.LoadAllHotelTypes();
            ViewBag.roomTypes = new SelectList(roomTypes, "Id", "Name");
            ViewBag.roomTypeList = roomTypes;
            IList<Room> rooms = _hotelReservationService.LoadAllRooms();
            ViewBag.roomList = rooms;
            if (!String.IsNullOrEmpty(message) && type == 1)//success
            {
                ViewBag.SuccessMessage = message;
            }
            if (!String.IsNullOrEmpty(message) && type == 2)//failed
            {
                ViewBag.ErrorMessage = message;
            }
            return View();
        }

        public ActionResult SaveRoomBooking(string hotelReservationObj)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ReservationVm roomReservationVm = serializer.Deserialize<ReservationVm>(hotelReservationObj);

                Booking roomBooking = new Booking();
                roomBooking.Checkindate = roomReservationVm.CheckinDate;
                roomBooking.Checkoutdate = roomReservationVm.CheckoutDate;
                roomBooking.Noofadult = roomReservationVm.NoOfAdult;
                roomBooking.Noofchild = roomReservationVm.NoOfChild;

                Bookingdetail bookingDetail = new Bookingdetail();
                bookingDetail.Advanceamount = roomReservationVm.AdvanceAmount;
                bookingDetail.Billingtype = roomReservationVm.BillingType;
                bookingDetail.Contactno = roomReservationVm.ContactNumber;
                bookingDetail.Creditcardno = roomReservationVm.CreditCardNo;
                bookingDetail.Email = roomReservationVm.Email;
                bookingDetail.Firstname = roomReservationVm.FirstName;
                bookingDetail.Lastname = roomReservationVm.LastName;
                bookingDetail.Noofnight =
                    roomReservationVm.CheckoutDate.Subtract(roomReservationVm.CheckinDate).Days;
                bookingDetail.Status = Roomregisterdetail.EntityStatus.Booked;
                roomBooking.Bookingdetails.Add(bookingDetail);
                bookingDetail.Booking = roomBooking;

                Customer customer = new Customer();
                customer.Firstname = roomReservationVm.FirstName;
                customer.Lastname = roomReservationVm.LastName;
                customer.Dob = roomReservationVm.Dob;
                customer.Contactnumber = roomReservationVm.ContactNumber;
                customer.Email = roomReservationVm.Email;
                customer.Address = roomReservationVm.Address;
                customer.Nationality = roomReservationVm.Nationality;
                customer.Nid = roomReservationVm.Nid;
                customer.Passport = roomReservationVm.Passport;
                customer.Remarks = roomReservationVm.Remarks;

                IList<Roomhistory> roomHistories = new List<Roomhistory>();
                foreach (var roomId in roomReservationVm.RoomIds)
                {
                    Room room = _hotelReservationService.GetRoomById(Convert.ToInt64(roomId));
                    roomBooking.Rooms.Add(room);
                    Roomhistory roomHistory = new Roomhistory();
                    roomHistory.Arrivaldate = roomBooking.Checkindate;
                    roomHistory.Leavedate = roomBooking.Checkoutdate;
                    roomHistory.Booking = roomBooking;
                    roomHistory.Room = room;
                    roomHistories.Add(roomHistory);
                }
                _hotelReservationService.SaveBooking(roomBooking, bookingDetail, roomHistories, customer);
                return RedirectToAction("Booking", new { message = "Room Booked Successfully", type = 1 });
            }
            catch (Exception)
            {
                return RedirectToAction("Booking", new { message = "Failed to Booked Room", type = 2 });

            }
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ManageBooking(int draw, int start, int length)
        {
            try
            {
                IList<Booking> roomBookings = _hotelReservationService.LoadAllBooking();
                int count = roomBookings.Count;

                var data = new List<object>();
                int sl = start + 1;
                foreach (var roomBooking in roomBookings)
                {
                    var str = new List<string>();
                    str.Add(sl.ToString());
                    str.Add(roomBooking.Customer.Firstname);
                    str.Add(roomBooking.Customer.Contactnumber);
                    List<string> roomNo = roomBooking.Roomhistories.Select(x => x.Room.Roomno).ToList();
                    string allRooms = string.Join(",", roomNo);
                    str.Add(allRooms);
                    str.Add(Convert.ToDateTime(roomBooking.Checkindate).ToString("g"));
                    str.Add(Convert.ToDateTime(roomBooking.Checkoutdate).ToString("g"));

                    str.Add(LinkGenerator.GetDeleteLinkForModal(roomBooking.Id, "Cancel"));
                    //str.Add(LinkGenerator.GetGeneratedDetailsEditLink("BookingDetails", "EditBooking", "RoomBooking", roomBooking.Id)
                    //        + LinkGenerator.GetDeleteLink("BookingDelete", "RoomBooking", roomBooking.Id));
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

        public ActionResult CancelBooking(long id)
        {
            Booking booking = _hotelReservationService.GetRoomBookById(id);
            booking.Status = Model.HMS.Entity.Booking.EntityStatus.Cancelled;
            booking.Iscancel = true;
            _hotelReservationService.UpdateBooking(booking);
            return Json(new { isSuccess = true, Text = "Cancelled Successfully" });
        }

        #endregion

    }
}