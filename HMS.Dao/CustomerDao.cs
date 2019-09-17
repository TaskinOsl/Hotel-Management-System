using Dao.HMS.Base;
using Model.HMS.Entity;

namespace Dao.HMS
{
    public interface ICustomerDao : IBaseDao<Customer, long>
    {
        
    }
    public class CustomerDao:BaseDao<Customer, long>,ICustomerDao
    {
        public CustomerDao()
        {
            
        }
    }
}
