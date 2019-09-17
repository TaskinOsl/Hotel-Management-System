using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IGlobalSettingDao : IBaseDao<Globalsetting, long>
    {
        
    }
    public class GlobalSettingDao:BaseDao<Globalsetting, long>,IGlobalSettingDao
    {
        public GlobalSettingDao()
        {
            
        }
    }
}
