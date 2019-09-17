using Dao.HMS.Mapping.Base;
using Model.HMS.Entity;

namespace Dao.HMS.Mapping {


    public class AdditionalserviceMap : BaseClassMap<Additionalservice, long>
    {
        
        public AdditionalserviceMap() {
			Table("AdditionalService");
			LazyLoad();
			
        }
    }
}
