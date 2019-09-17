using System.ComponentModel.DataAnnotations;

namespace Model.HMS.ViewModel
{
    public class RoomVm
    {
        public long Id { get; set; }
        [Display(Name = "Room No")]
        [Required]
        public virtual string RoomNo { get; set; }

        [Display(Name = "No Of Adult")]
        [Required]
        public virtual int NoOfAdult { get; set; }

        [Display(Name = "Max Child")]
        [Required]
        public virtual int MaxChild { get; set; }
        public virtual string Description { get; set; }

        [Display(Name = "Room Type")]
        [Required]
        public virtual long RoomTypeId { get; set; }
    }
}
