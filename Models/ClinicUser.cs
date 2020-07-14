using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class ClinicUser
    {
        public ClinicUser()
        {
            Clinic = new HashSet<Clinic>();
            TClinicUser = new HashSet<TClinicUser>();
        }

        public int ClinicUserId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public int ClinicUserType { get; set; }
        public string Address1 { get; set; }
        public int Status { get; set; }
        public int Province { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Address2 { get; set; }
        public string Pin { get; set; }
        public string Firstname { get; set; }
        public string Password { get; set; }
        public int AgreeToTerms { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateActivated { get; set; }
        public int? DiabetesId { get; set; }
        public string PhysicianLastNameforCsn { get; set; }
        public string AdminInfo { get; set; }

        public ClinicUserType ClinicUserTypeNavigation { get; set; }
        public Province ProvinceNavigation { get; set; }
        public Status StatusNavigation { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
        public ICollection<TClinicUser> TClinicUser { get; set; }
    }
}
