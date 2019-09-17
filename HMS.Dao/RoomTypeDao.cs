using System.Collections.Generic;
using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IRoomTypeDao : IBaseDao<Roomtype, long>
    {
        IList<Roomtype> LoadAllHotelTypes();

        IList<Roomtype> LoadAllRoomType(int draw, int start, int length);

        int CountRoomType();
    }
    public class RoomTypeDao : BaseDao<Roomtype, long>, IRoomTypeDao
    {
        public RoomTypeDao()
        {

        }

        public IList<Roomtype> LoadAllHotelTypes()
        {
            return Session.QueryOver<Roomtype>().Where(x => x.Status == Roomtype.EntityStatus.Active).List<Roomtype>();
        }

        public IList<Roomtype> LoadAllRoomType(int draw, int start, int length)
        {
            var criteria = Session.CreateCriteria<Roomtype>();
            return criteria.SetFirstResult(start).SetMaxResults(length).List<Roomtype>();
        }

        public int CountRoomType()
        {
            var criteria = Session.CreateCriteria<Roomtype>();
            return criteria.List<Roomtype>().Count;
        }
    }
}
