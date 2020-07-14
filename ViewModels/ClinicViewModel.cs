using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSDAdmin.ViewModels
{
    public class ClinicViewModel
    {
        public ClinicViewModel()
        {
        }

        public int ClinicId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Phone2 { get; set; }
        public String ShowAcceptingNew { get; set; }
        public String Status { get; set; }
        public string Phone1 { get; set; }
        public string Name { get; set; }
        public String PhysicalCity { get; set; }
        public string Description { get; set; }
        public String MailingCity { get; set; }
        public string MailingPostalCode { get; set; }
        public String IsEmail1Primary { get; set; }
        public string Fax { get; set; }
        public DateTime? DateModified { get; set; }
        public double? Longitude { get; set; }
        public string Website { get; set; }
        public string Email1 { get; set; }
        public string PhysicalPostCode { get; set; }
        public string PostCode { get; set; }
        public double? Latitude { get; set; }
        public String AcceptingNew { get; set; }
        public String ServiceType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public String Lhinname { get; set; }
        public string Email2 { get; set; }
        public string ClinicAdminEmail { get; set; }
        public String LastModifiedBy { get; set; }
        public DateTime? DateActivated { get; set; }
        public string WaitTimeId { get; set; }
        public string WaitTimeInfo { get; set; }
        public string WebsiteFrench { get; set; }
        public string Hsphone2 { get; set; }
        public string CommunityAndAreasServed { get; set; }
        public string Hsphone1 { get; set; }
        public string DescriptionFrench { get; set; }
        public string Hsphone3 { get; set; }
        public int? DiabetesId { get; set; }
        public string HoursOfBusinessNotes { get; set; }
        public int? IsAvailableForHighRiskScreening { get; set; }
        public string HoursOfBusinessNotesForFrench { get; set; }
        public IList<ClinicHourViewModel> ClinicHours { get; set;}
        public IList<String> CityNames { get; set; }
    }
}
