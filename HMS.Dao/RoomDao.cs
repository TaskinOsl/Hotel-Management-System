using System.Collections.Generic;
using Dao.HMS.Base;
using Model.HMS.Entity;
using NHibernate.Criterion;

namespace Dao.HMS
{
    public interface IRoomDao : IBaseDao<Room, long>
    {

        IList<Room> LoadAllRooms(int draw, int start, int length, long roomTypeId);
        int CountAllRooms(long roomTypeId);
    }
    public class RoomDao : BaseDao<Room, long>, IRoomDao
    {
        public RoomDao()
        {

        }

        public IList<Room> LoadAllRooms(int draw, int start, int length, long roomTypeId)
        {
            var criteria = Session.CreateCriteria<Room>();
            if (roomTypeId > 0)
            {
                criteria.CreateAlias("Roomtype", "rt").Add(Restrictions.Eq("rt.Id", roomTypeId));
            }
            criteria = criteria.Add(Restrictions.Eq("Status", Room.EntityStatus.Active));
            criteria = criteria.SetFirstResult(start).SetMaxResults(length);
            return criteria.List<Room>();
        }

        public int CountAllRooms(long roomTypeId)
        {
            var criteria = Session.CreateCriteria<Room>();
            if (roomTypeId > 0)
            {
                criteria.CreateAlias("Roomtype", "rt").Add(Restrictions.Eq("rt.Id", roomTypeId));
            }
            criteria = criteria.Add(Restrictions.Eq("Status", Room.EntityStatus.Active));
            return criteria.List<Room>().Count;
        }

    }
}
