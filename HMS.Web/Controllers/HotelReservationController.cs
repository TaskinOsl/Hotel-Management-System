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
    [Authorize]
    public class HotelReservationController : Controller
    {
        private readonly IHotelReservationService _hotelReservationService;
        private ISession _session;
        public HotelReservationController()
        {
            _session = NhSessionFactory.OpenSession();
            _hotelReservationService = new HotelReservationService(_session);
        }

        #region Reservation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageReservation(int draw, int start, int length)
        {
            try
            {
                IList<Roomregister> roomregisters = _hotelReservationService.LoadAllReservation();
                int count = roomregisters.Count;

                var data = new List<object>();
                int sl = start + 1;
                foreach (var roomRegister in roomregisters)
                {
                    var str = new List<string>();
                    str.Add(sl.ToString());
                    str.Add(roomRegister.Customer.Firstname);
                    str.Add(roomRegister.Customer.Contactnumber);
                    List<string> roomNo = roomRegister.Roomhistories.Select(x => x.Room.Roomno).ToList();
                    string allRooms = string.Join(",", roomNo);
                    str.Add(allRooms);
                    str.Add(Convert.ToDateTime(roomRegister.Checkindate).ToString("g"));
                    str.Add(Convert.ToDateTime(roomRegister.Checkoutdate).ToString("g"));

                    str.Add(LinkGenerator.GetGeneratedDetailsEditLink("ReservationDetails", "EditReservaion", "HotelReservation", roomRegister.Id)
                            + LinkGenerator.GetInvoiceLink("InvoiceGenerate", "HotelReservation", roomRegister.Id));
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

        [HttpGet]
        public ActionResult DashBoard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Reservation(string message, int type = 0)
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
                ViewBag.SuccessMessage = message;
            if (!String.IsNullOrEmpty(message) && type == 2)//failed
                ViewBag.ErrorMessage = message;


            return View();
        }

        [HttpPost]
        public ActionResult SaveRoomReservation(string hotelReservationObj)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                ReservationVm roomReservationVm = serializer.Deserialize<ReservationVm>(hotelReservationObj);

                Roomregister roomRegister = new Roomregister();
                roomRegister.Checkindate = roomReservationVm.CheckinDate;
                roomRegister.Checkoutdate = roomReservationVm.CheckoutDate;
                roomRegister.Noofadult = roomReservationVm.NoOfAdult;
                roomRegister.Noofchild = roomReservationVm.NoOfChild;
                roomRegister.Status = Roomregister.EntityStatus.Reserved;

                Roomregisterdetail roomRegisterDetail = new Roomregisterdetail();
                roomRegisterDetail.Advanceamount = roomReservationVm.AdvanceAmount;
                roomRegisterDetail.Billingtype = roomReservationVm.BillingType;
                roomRegisterDetail.Contactno = roomReservationVm.ContactNumber;
                roomRegisterDetail.Creditcardno = roomReservationVm.CreditCardNo;
                roomRegisterDetail.Email = roomReservationVm.Email;
                roomRegisterDetail.Firstname = roomReservationVm.FirstName;
                roomRegisterDetail.Lastname = roomReservationVm.LastName;
                roomRegisterDetail.Noofnight =
                    roomReservationVm.CheckoutDate.Subtract(roomReservationVm.CheckinDate).Days;
                roomRegisterDetail.Status = Roomregisterdetail.EntityStatus.Reserved;
                roomRegister.Roomregisterdetails.Add(roomRegisterDetail);
                roomRegisterDetail.Roomregister = roomRegister;

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
                    roomRegister.Rooms.Add(room);
                    Roomhistory roomHistory = new Roomhistory();
                    roomHistory.Arrivaldate = roomRegister.Checkindate;
                    roomHistory.Leavedate = roomRegister.Checkoutdate;
                    roomHistory.Roomregister = roomRegister;
                    roomHistory.Room = room;
                    roomHistories.Add(roomHistory);
                }

                _hotelReservationService.SaveReservation(roomRegister, roomRegisterDetail, roomHistories, customer);
                return RedirectToAction("Reservation", new { message = "Room Reserved Successfully", type = 1 });
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditReservaion(long id)
        {
            try
            {
                Roomregister roomregister = _hotelReservationService.GetRoomRegisterById(id);
                ReservationVm reservationVm = CastToVm(roomregister);

                List<SelectListItem> billingTypes = new List<SelectListItem>();
                billingTypes.Add(new SelectListItem() { Text = "Cash", Value = "1" });
                billingTypes.Add(new SelectListItem() { Text = "Card", Value = "2" });

                ViewBag.billingTypes = new SelectList(billingTypes, "Value", "Text", reservationVm.BillingType.ToString());

                IList<Roomtype> roomTypes = _hotelReservationService.LoadAllHotelTypes();
                ViewBag.roomTypes = new SelectList(roomTypes, "Id", "Name");
                ViewBag.roomTypeList = roomTypes;
                IList<Room> rooms = _hotelReservationService.LoadAllRooms();
                ViewBag.roomList = rooms;

                return View(reservationVm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ReservationVm CastToVm(Roomregister roomregister)
        {
            ReservationVm reservationVm = new ReservationVm();
            reservationVm.Address = roomregister.Customer.Address;
            reservationVm.AdvanceAmount = (decimal)roomregister.Roomregisterdetails[0].Advanceamount;
            reservationVm.BillingType = (int)roomregister.Roomregisterdetails[0].Billingtype;
            reservationVm.CheckinDate = roomregister.Checkindate;
            reservationVm.CheckoutDate = roomregister.Checkoutdate;
            reservationVm.CreditCardNo = roomregister.Roomregisterdetails[0].Creditcardno;
            reservationVm.Dob = roomregister.Customer.Dob;
            reservationVm.Email = roomregister.Customer.Email;
            reservationVm.FirstName = roomregister.Customer.Firstname;
            reservationVm.LastName = roomregister.Customer.Lastname;
            reservationVm.Id = roomregister.Id;
            reservationVm.Nationality = roomregister.Customer.Nationality;
            reservationVm.Nid = roomregister.Customer.Nid;
            reservationVm.NoOfAdult = (int)roomregister.Noofadult;
            reservationVm.NoOfChild = (int)roomregister.Noofchild;
            reservationVm.Passport = roomregister.Customer.Passport;
            //reservationVm.Rooms = roomregister.Roomhistories;
            return reservationVm;
        }

        public ActionResult InvoiceGenerate(long id)
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

        #endregion

    }
}