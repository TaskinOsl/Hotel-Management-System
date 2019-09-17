using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface IAdditionalServiceDao : IBaseDao<Additionalservice, long>
    {
        
    }
    public class AdditionalServiceDao:BaseDao<Additionalservice, long>,IAdditionalServiceDao
    {
        public AdditionalServiceDao()
        {
            
        }
    }
}
