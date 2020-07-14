using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Clinic
    {
        public Clinic()
        {
            Flag = new HashSet<Flag>();
            TClinicHours = new HashSet<TClinicHours>();
            TClinicPractitioner = new HashSet<TClinicPractitioner>();
            TClinicPractitionerCopy = new HashSet<TClinicPractitionerCopy>();
            TClinicUser = new HashSet<TClinicUser>();
            TLanguages = new HashSet<TLanguages>();
            TServices = new HashSet<TServices>();
        }

        public int ClinicId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Phone2 { get; set; }
        public int? ShowAcceptingNew { get; set; }
        public int Status { get; set; }
        public string Phone1 { get; set; }
        public string Name { get; set; }
        public int PhysicalCity { get; set; }
        public string Description { get; set; }
        public int? MailingCity { get; set; }
        public string MailingPostalCode { get; set; }
        public int? IsEmail1Primary { get; set; }
        public string Fax { get; set; }
        public DateTime? DateModified { get; set; }
        public double? Longitude { get; set; }
        public string Website { get; set; }
        public string Email1 { get; set; }
        public string PhysicalPostalCode { get; set; }
        public double? Latitude { get; set; }
        public int? AcceptingNew { get; set; }
        public int? ServiceType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public int? Lhinname { get; set; }
        public string Email2 { get; set; }
        public string ClinicAdminEmail { get; set; }
        public int? LastModifiedBy { get; set; }
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

        public ClinicUser LastModifiedByNavigation { get; set; }
        public Lhinname LhinnameNavigation { get; set; }
        public OntarioCity MailingCityNavigation { get; set; }
        public OntarioCity PhysicalCityNavigation { get; set; }
        public ServiceType ServiceTypeNavigation { get; set; }
        public Status StatusNavigation { get; set; }
        public ICollection<Flag> Flag { get; set; }
        public ICollection<TClinicHours> TClinicHours { get; set; }
        public ICollection<TClinicPractitioner> TClinicPractitioner { get; set; }
        public ICollection<TClinicPractitionerCopy> TClinicPractitionerCopy { get; set; }
        public ICollection<TClinicUser> TClinicUser { get; set; }
        public ICollection<TLanguages> TLanguages { get; set; }
        public ICollection<TServices> TServices { get; set; }
    }
}
