using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.HMS.Entity;

namespace Model.HMS.ViewModel
{
    public class ReservationVm
    {
        public ReservationVm()
        {
            Rooms = new List<Room>();
        }
        public virtual long Id { get; set; }
        [Required]
        [Display(Name = "Checkin Date")]
        public virtual DateTime CheckinDate { get; set; }
        [Required]
        [Display(Name = "CheckOut Date")]
        public virtual DateTime CheckoutDate { get; set; }
        [Required]
        [Display(Name = "No Of Adult")]
        public virtual int NoOfAdult { get; set; }
        [Required]
        [Display(Name = "No Of Child")]
        public virtual int NoOfChild { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string Address { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        public virtual string ContactNumber { get; set; }
        [Display(Name = "NID")]

        public virtual string Nid { get; set; }
        public virtual string Passport { get; set; }
        public virtual string Email { get; set; }
        public virtual string Remarks { get; set; }

        [Display(Name = "Date Of Birth")]

        public virtual System.Nullable<System.DateTime> Dob { get; set; }
        [Required]
        public virtual string Nationality { get; set; }

        [Display(Name = "Billing Type")]

        public virtual int BillingType { get; set; }

        [Display(Name = "Advance Amount")]

        public virtual decimal AdvanceAmount { get; set; }

        [Display(Name = "Credit Card No")]

        public virtual string CreditCardNo { get; set; }

        [Display(Name = "Room Types")]

        public virtual int RoomTypes { get; set; }
        public virtual bool Iscancel { get; set; }
        public virtual List<string> RoomIds { get; set; }
        public virtual IList<Room> Rooms { get; set; }


    }
}
