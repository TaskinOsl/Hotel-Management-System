using System;
using System.Collections.Generic;
using Dao.HMS;
using Model.HMS.Entity;
using NHibernate;
using Services.HMS.Base;

namespace Services.HMS
{
    public interface IHotelReservationService : IBaseService
    {

        IList<Roomtype> LoadAllHotelTypes();

        IList<Room> LoadAllRooms();

        void SaveRoomType(Roomtype roomtype);

        IList<Roomtype> LoadAllRoomType();

        IList<Roomtype> LoadAllRoomType(int draw, int start, int length);

        int CountRoomType();

        Roomtype GetRoomTypeById(long id);

        void UpdateRoomType(Roomtype roomtypeProxy);
        void SaveRoom(Room room);

        IList<Room> LoadAllRooms(int draw, int start, int length, long roomTypeId);

        int CountAllRooms(long roomTypeId);

        Room GetRoomById(long id);

        void UpdateRoom(Room room);

        void SaveReservation(Roomregister roomRegister, Roomregisterdetail roomRegisterDetail, IList<Roomhistory> roomHistories, Customer customer);

        IList<Roomregister> LoadAllReservation();
        Roomregister GetRoomRegisterById(long id);

        void SaveBooking(Booking roomBooking, Bookingdetail bookingDetail, IList<Roomhistory> roomHistories, Customer customer);

        IList<Booking> LoadAllBooking();

        Booking GetRoomBookById(long id);

        void UpdateBooking(Booking booking);
    }

    public class HotelReservationService : BaseService, IHotelReservationService
    {
        private readonly IRoomRegisterDao _roomRegisterDao;
        private readonly IRoomTypeDao _roomTypeDao;
        private readonly IRoomDao _roomDao;
        private readonly IRoomHistoryDao _roomHistoryDao;
        private readonly ICustomerDao _customerDao;
        private readonly IBookingDao _bookingDao;
        private ISession _session;

        public HotelReservationService(ISession session)
        {
            _session = session;
            _roomRegisterDao = new RoomRegisterDao() { Session = session };
            _roomTypeDao = new RoomTypeDao() { Session = session };
            _roomDao = new RoomDao() { Session = session };
            _roomHistoryDao = new RoomHistoryDao() { Session = session };
            _customerDao = new CustomerDao() { Session = session };
            _bookingDao = new BookingDao() { Session = session };
        }

        public IList<Roomtype> LoadAllHotelTypes()
        {
            return _roomTypeDao.LoadAllHotelTypes();
        }

        public IList<Room> LoadAllRooms()
        {
            return _roomDao.LoadAll();
        }

        public void SaveRoomType(Roomtype roomtype)
        {
            _roomTypeDao.Save(roomtype);
        }

        public IList<Roomtype> LoadAllRoomType()
        {
            return _roomTypeDao.LoadAll(Roomtype.EntityStatus.Active);
        }

        public IList<Roomtype> LoadAllRoomType(int draw, int start, int length)
        {
            return _roomTypeDao.LoadAllRoomType(draw, start, length);
        }

        public int CountRoomType()
        {
            return _roomTypeDao.CountRoomType();
        }

        public Roomtype GetRoomTypeById(long id)
        {
            return _roomTypeDao.LoadById(id);
        }

        public void UpdateRoomType(Roomtype roomtypeProxy)
        {
            ITransaction transaction = null;
            try
            {
                using (transaction = _session.BeginTransaction())
                {
                    _roomTypeDao.Update(roomtypeProxy);
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
        }

        public void SaveRoom(Room room)
        {
            try
            {
                _roomDao.Save(room);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Room> LoadAllRooms(int draw, int start, int length, long roomTypeId)
        {
            return _roomDao.LoadAllRooms(draw, start, length, roomTypeId);
            ;
        }

        public int CountAllRooms(long roomTypeId)
        {
            return _roomDao.CountAllRooms(roomTypeId);
        }

        public Room GetRoomById(long id)
        {
            return _roomDao.LoadById(id);
        }

        public void UpdateRoom(Room room)
        {
            ITransaction transaction = null;
            try
            {
                using (transaction = _session.BeginTransaction())
                {
                    _roomDao.Update(room);
                    transaction.Commit();
                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
        }

        public void SaveReservation(Roomregister roomRegister, Roomregisterdetail roomRegisterDetail,
            IList<Roomhistory> roomHistories, Customer customer)
        {
            ITransaction transaction = null;
            try
            {
                using (transaction = _session.BeginTransaction())
                {
                    _customerDao.Save(customer);
                    roomRegister.Customer = customer;
                    _roomRegisterDao.Save(roomRegister);
                    foreach (var roomhistory in roomHistories)
                    {
                        roomhistory.Roomregister = roomRegister;

                        _roomHistoryDao.Save(roomhistory);
                    }
                    transaction.Commit();

                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
        }

        public IList<Roomregister> LoadAllReservation()
        {
            return _roomRegisterDao.LoadAll();
        }

        public Roomregister GetRoomRegisterById(long id)
        {
            return _roomRegisterDao.LoadById(id);
        }

        public void SaveBooking(Booking roomBooking, Bookingdetail bookingDetail, IList<Roomhistory> roomHistories, Customer customer)
        {
            ITransaction transaction = null;
            try
            {
                using (transaction = _session.BeginTransaction())
                {
                    _customerDao.Save(customer);
                    roomBooking.Customer = customer;
                    _bookingDao.Save(roomBooking);
                    foreach (var roomhistory in roomHistories)
                    {
                        roomhistory.Booking = roomBooking;
                        _roomHistoryDao.Save(roomhistory);
                    }
                    transaction.Commit();

                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
        }

        public IList<Booking> LoadAllBooking()
        {
            return _bookingDao.LoadActiveBooking();
        }

        public Booking GetRoomBookById(long id)
        {
            return _bookingDao.LoadById(id);
        }

        public void UpdateBooking(Booking booking)
        {
            ITransaction transaction = null;
            try
            {
                using (transaction = _session.BeginTransaction())
                {
                    _bookingDao.Update(booking);
                    transaction.Commit();

                }
            }
            catch (Exception)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
        }
    }
}

