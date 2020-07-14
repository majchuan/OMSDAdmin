using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OMSDAdmin.ViewModels;
using OMSDAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using System.Diagnostics;

namespace OMSDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly OMSDStagingSTI_CustomContext aOmsdCustomConext;
        private IList<ClinicHourViewModel> aClinicHourViewModelList;

        public HomeController(OMSDStagingSTI_CustomContext aContext)
        {
            aOmsdCustomConext = aContext;
        }

        [HttpGet("[action]")]
        public IEnumerable<ClinicViewModel> GetClinics()
        {
            IList<ClinicViewModel> aList = new List<ClinicViewModel>();
            using (aOmsdCustomConext)
            {
                var clinics = aOmsdCustomConext.Clinic
                    .Where(aClinic => aClinic.Status != 1)
                    .Include(aClinic => aClinic.PhysicalCityNavigation)
                    .Include(aClinic => aClinic.ServiceTypeNavigation).ToList();
                foreach (var aClinic in clinics)
                {
                    ClinicViewModel aClinicViewModel = new ClinicViewModel();
                    aClinicViewModel.ClinicId = aClinic.ClinicId;
                    aClinicViewModel.Name = aClinic.Name;
                    aClinicViewModel.PhysicalAddressLine1 = aClinic.PhysicalAddressLine1;
                    aClinicViewModel.PhysicalAddressLine2 = aClinic.PhysicalAddressLine2;
                    aClinicViewModel.PhysicalCity = aClinic.PhysicalCityNavigation.Name;
                    aClinicViewModel.PhysicalPostCode = aClinic.PhysicalPostalCode;
                    aClinicViewModel.Phone1 = aClinic.Phone1;
                    aClinicViewModel.Phone2 = aClinic.Phone2;
                    aClinicViewModel.Website = aClinic.Website;
                    aClinicViewModel.Email1 = aClinic.Email1;
                    aClinicViewModel.ServiceType = aClinic.ServiceTypeNavigation.Name;
                    aClinicViewModel.Description = aClinic.Description;
                    aClinicViewModel.DescriptionFrench = aClinic.DescriptionFrench;
                    aClinicViewModel.HoursOfBusinessNotes = aClinic.HoursOfBusinessNotes;
                    aClinicViewModel.HoursOfBusinessNotesForFrench = aClinic.HoursOfBusinessNotesForFrench;
                    aClinicViewModel.DateActivated = aClinic.DateActivated;
                    aClinicViewModel.CreatedDate = aClinic.CreatedDate;
                    aClinicViewModel.Datecreated = aClinic.Datecreated;
                    aClinicViewModel.DateModified = aClinic.DateModified;
                    aList.Add(aClinicViewModel);
                }

                return aList;
            }
           
        }

        [HttpPost("[action]")]
        public IEnumerable<ClinicViewModel> SearchClinics([FromBody]String searchKeyWord)
        {
            int searchKeyWordInt;
            if (!int.TryParse(searchKeyWord, out searchKeyWordInt)) searchKeyWordInt = -999;

            IList<ClinicViewModel> aList = new List<ClinicViewModel>();
            var aClinicsList = aOmsdCustomConext.Clinic.Include(x => x.PhysicalCityNavigation)
                .Include(y => y.ServiceTypeNavigation)
                .Where(aClinic => aClinic.Status != 1)
                .Where(x => x.Name.Contains(searchKeyWord) || 
                            x.PhysicalAddressLine1.Contains(searchKeyWord) ||
                            x.PhysicalAddressLine2.Contains(searchKeyWord) ||
                            (x.ClinicId == searchKeyWordInt) ||
                            x.Phone1.Contains(searchKeyWord) ||
                            x.Phone2.Contains(searchKeyWord) ||
                            x.MailingCityNavigation.Name.Contains(searchKeyWord) ||
                            x.MailingCityNavigation.Name.Contains(searchKeyWord) ||
                            x.MailingPostalCode.Contains(searchKeyWord) ||
                            x.PhysicalPostalCode.Contains(searchKeyWord) ||
                            x.Website.Contains(searchKeyWord) ||
                            x.WebsiteFrench.Contains(searchKeyWord) 
                            ).ToList();
            if (aClinicsList != null && aClinicsList.Count > 0)
            {
                foreach (var aClinic in aClinicsList)
                {
                    ClinicViewModel aClinicViewModel = new ClinicViewModel();
                    aClinicViewModel.ClinicId = aClinic.ClinicId;
                    aClinicViewModel.Name = aClinic.Name;
                    aClinicViewModel.PhysicalAddressLine1 = aClinic.PhysicalAddressLine1;
                    aClinicViewModel.PhysicalAddressLine2 = aClinic.PhysicalAddressLine2;
                    aClinicViewModel.PhysicalCity = aClinic.PhysicalCityNavigation.Name;
                    aClinicViewModel.PhysicalPostCode = aClinic.PhysicalPostalCode;
                    aClinicViewModel.Phone1 = aClinic.Phone1;
                    aClinicViewModel.Phone2 = aClinic.Phone2;
                    aClinicViewModel.Website = aClinic.Website;
                    aClinicViewModel.Email1 = aClinic.Email1;
                    aClinicViewModel.ServiceType = aClinic.ServiceTypeNavigation.Name;
                    aClinicViewModel.Description = aClinic.Description;
                    aClinicViewModel.DescriptionFrench = aClinic.DescriptionFrench;
                    aClinicViewModel.HoursOfBusinessNotes = aClinic.HoursOfBusinessNotes;
                    aClinicViewModel.HoursOfBusinessNotesForFrench = aClinic.HoursOfBusinessNotesForFrench;

                    aList.Add(aClinicViewModel);
                }
            }
            return aList;
        }

        [HttpGet("[action]/{id}")]
        public ClinicViewModel GetClinic(Int32 id)
        {
            using (aOmsdCustomConext)
            {
                try
                {
                    var aClinic = aOmsdCustomConext.Clinic.
                        Include(x => x.PhysicalCityNavigation).
                        Include(x => x.ServiceTypeNavigation).SingleOrDefault(y => y.ClinicId == id);
                    var aClinicHours = aOmsdCustomConext.TClinicHours.Where(x => x.Sublistingid == id).ToList();
               
                    SetClinicHourViewModel(aClinicHours);

                    ClinicViewModel aClinicViewModel = new ClinicViewModel();
                    if (aClinic.Status == 1)
                    {
                        aClinicViewModel.ClinicId = -1;
                        return aClinicViewModel;
                    }
                    aClinicViewModel.ClinicId = aClinic.ClinicId;
                    aClinicViewModel.Name = aClinic.Name;
                    aClinicViewModel.PhysicalAddressLine1 = aClinic.PhysicalAddressLine1;
                    aClinicViewModel.PhysicalAddressLine2 = aClinic.PhysicalAddressLine2;
                    aClinicViewModel.PhysicalCity = aClinic.PhysicalCityNavigation.Name;
                    aClinicViewModel.PhysicalPostCode = aClinic.PhysicalPostalCode;
                    aClinicViewModel.Phone1 = aClinic.Phone1;
                    aClinicViewModel.Phone2 = aClinic.Phone2;
                    aClinicViewModel.Website = aClinic.Website;
                    aClinicViewModel.WebsiteFrench = aClinic.WebsiteFrench;
                    aClinicViewModel.Email1 = aClinic.Email1;
                    aClinicViewModel.Email2 = aClinic.Email2;
                    aClinicViewModel.IsEmail1Primary = aClinic.IsEmail1Primary == 0 ? "No" : "Yes";
                    aClinicViewModel.AcceptingNew = aClinic.AcceptingNew == 0 ? "No" : "Yes";
                    aClinicViewModel.Longitude = aClinic.Longitude;
                    aClinicViewModel.Latitude = aClinic.Latitude;
                    aClinicViewModel.Fax = aClinic.Fax;
                    aClinicViewModel.MailingAddressLine1 = aClinic.MailingAddressLine1;
                    aClinicViewModel.MailingAddressLine2 = aClinic.MailingAddressLine2;
                    aClinicViewModel.MailingCity = aClinic.PhysicalCityNavigation.Name;
                    aClinicViewModel.ServiceType = aClinic.ServiceTypeNavigation.Name;
                    aClinicViewModel.CommunityAndAreasServed = aClinic.CommunityAndAreasServed;
                    aClinicViewModel.Description = aClinic.Description;
                    aClinicViewModel.DescriptionFrench = aClinic.DescriptionFrench;
                    aClinicViewModel.HoursOfBusinessNotes = aClinic.HoursOfBusinessNotes;
                    aClinicViewModel.HoursOfBusinessNotesForFrench = aClinic.HoursOfBusinessNotesForFrench;
                    aClinicViewModel.ClinicHours = GetClinicHourViewModel();
                    aClinicViewModel.DateActivated = aClinic.DateActivated;
                    aClinicViewModel.CreatedDate = aClinic.CreatedDate;
                    aClinicViewModel.Datecreated = aClinic.Datecreated;
                    aClinicViewModel.DateModified = aClinic.DateModified;
                    aClinicViewModel.ClinicAdminEmail = aClinic.ClinicAdminEmail;

                    return aClinicViewModel;
                }
                catch(Exception e)
                {
                    throw e;
                } 
            }
        }

        [HttpPut("[action]")]
        public ClinicViewModel UpdateClinic([FromBody]ClinicViewModel aClinicViewModel)
        {
            using (aOmsdCustomConext)
            {
                try
                {

                    bool clinicExist = aOmsdCustomConext.Clinic.Any(c => (c.ClinicId == aClinicViewModel.ClinicId));
                    if (!clinicExist){
                        aClinicViewModel.ClinicId = -1;
                        return aClinicViewModel;
                    }

                    bool cityExist = aOmsdCustomConext.OntarioCity.Any(x => (x.Name == aClinicViewModel.PhysicalCity));
                    bool serviceExist = aOmsdCustomConext.ServiceType.Any(x => x.Name == aClinicViewModel.ServiceType);
                    if (!cityExist) 
                    {
                        aClinicViewModel.PhysicalCity = "-1";
                    }
                    if (!serviceExist)
                    {
                        aClinicViewModel.ServiceType = "-1";
                    }
                    if ((!cityExist) || (!serviceExist))
                    {
                        return aClinicViewModel;
                    }

                    var aClinic = aOmsdCustomConext.Clinic.Find(aClinicViewModel.ClinicId);

                    if (aClinic.Status == 1)
                    {
                        aClinicViewModel.ClinicId = -1;
                        return aClinicViewModel;
                    }


                    var ontarioCityId = aOmsdCustomConext.OntarioCity.Where(x => (x.Name == aClinicViewModel.PhysicalCity)).FirstOrDefault().OntarioCityId;
                    var serviceType = aOmsdCustomConext.ServiceType.Where(x => x.Name == aClinicViewModel.ServiceType).FirstOrDefault().ServiceTypeId;
                    aClinic.Name = aClinicViewModel.Name;
                    aClinic.ClinicId = aClinicViewModel.ClinicId;
                    aClinic.Name = aClinicViewModel.Name;
                    aClinic.PhysicalAddressLine1 = aClinicViewModel.PhysicalAddressLine1;
                    aClinic.PhysicalAddressLine2 = aClinicViewModel.PhysicalAddressLine2;
                    aClinic.PhysicalCity = ontarioCityId;
                    aClinic.PhysicalPostalCode = aClinicViewModel.PhysicalPostCode;
                    aClinic.Phone1 = aClinicViewModel.Phone1;
                    aClinic.Phone2 = aClinicViewModel.Phone2;
                    aClinic.Website = aClinicViewModel.Website;
                    aClinic.WebsiteFrench = aClinicViewModel.WebsiteFrench;
                    aClinic.Email1 = aClinicViewModel.Email1;
                    aClinic.Email2 = aClinicViewModel.Email2;
                    aClinic.IsEmail1Primary = aClinicViewModel.IsEmail1Primary == "Yes" ? 1 : 0;
                    aClinic.AcceptingNew = aClinicViewModel.AcceptingNew == "Yes" ? 1 : 0;
                    aClinic.Longitude = aClinicViewModel.Longitude;
                    aClinic.Latitude = aClinicViewModel.Latitude;
                    aClinic.Fax = aClinicViewModel.Fax;
                    aClinic.MailingAddressLine1 = aClinicViewModel.MailingAddressLine1;
                    aClinic.MailingAddressLine2 = aClinicViewModel.MailingAddressLine2;
                    aClinic.MailingCity = ontarioCityId;
                    aClinic.ServiceType = serviceType;
                    aClinic.CommunityAndAreasServed = aClinicViewModel.CommunityAndAreasServed;
                    aClinic.Description = aClinicViewModel.Description;
                    aClinic.DescriptionFrench = aClinicViewModel.DescriptionFrench;
                    aClinic.HoursOfBusinessNotes = aClinicViewModel.HoursOfBusinessNotes;
                    aClinic.HoursOfBusinessNotesForFrench = aClinicViewModel.HoursOfBusinessNotesForFrench;
                    aClinic.DateModified = DateTime.Now;
                    aClinic.ClinicAdminEmail = aClinicViewModel.ClinicAdminEmail;
                    aOmsdCustomConext.SaveChanges();

                    return aClinicViewModel;
                }
                catch(Exception e)
                {
                    throw e;
                }

            }
        }

        [HttpPost("[action]")]
        public ClinicViewModel AddClinic([FromBody]ClinicViewModel aClinicViewModel)
        {

            bool cityExist = aOmsdCustomConext.OntarioCity.Any(x => (x.Name == aClinicViewModel.PhysicalCity));
            bool serviceExist = aOmsdCustomConext.ServiceType.Any(x => x.Name == aClinicViewModel.ServiceType);
            if (!cityExist)
            {
                aClinicViewModel.PhysicalCity = "-1";
            }
            if (!serviceExist)
            {
                aClinicViewModel.ServiceType = "-1";
            }
            if ((!cityExist) || (!serviceExist))
            {
                return aClinicViewModel;
            }

            var aClinic = CreateNewClinic(aClinicViewModel);
            aOmsdCustomConext.Clinic.Add(aClinic);
            aOmsdCustomConext.SaveChanges();
            return aClinicViewModel;

        }

        [HttpDelete("[action]/{aClinicId}")]
        public void DeleteClinic(Int32 aClinicId)
        {
            using (aOmsdCustomConext)
            {
                var aDeleteClinic = aOmsdCustomConext.Clinic.Find(aClinicId);
                aDeleteClinic.Status = 1;
                aOmsdCustomConext.SaveChanges();
            }
        }

        private void SetClinicHourViewModel(IList<TClinicHours> tClinicHours)
        {
            var aDaysOfTheWeeks = aOmsdCustomConext.DaysOfTheWeek;
            aClinicHourViewModelList = new List<ClinicHourViewModel>();
            foreach(var aTClinicHour in tClinicHours)
            {
                var aClinicHourViewModel = new ClinicHourViewModel();
                aClinicHourViewModel.TClinicHoursId = aTClinicHour.TClinicHoursId;
                aClinicHourViewModel.Editstate = aTClinicHour.Editstate;
                aClinicHourViewModel.ClinicID = aTClinicHour.Sublistingid;
                aClinicHourViewModel.Datecreated = aTClinicHour.Datecreated;
                aClinicHourViewModel.StartTime = aTClinicHour.StartTime;
                aClinicHourViewModel.EndTime = aTClinicHour.EndTime;
                aClinicHourViewModel.Day = aTClinicHour.Day;
                aClinicHourViewModel.DaysOfTheWeekId = aDaysOfTheWeeks.Where(x => x.DaysOfTheWeekId == aTClinicHour.Day).FirstOrDefault().DaysOfTheWeekId;
                aClinicHourViewModel.DaysOfTheWeekName = aDaysOfTheWeeks.Where(x => x.DaysOfTheWeekId == aTClinicHour.Day).FirstOrDefault().Name;
                aClinicHourViewModel.DaysOfTheWweekAbbre = aDaysOfTheWeeks.Where(x => x.DaysOfTheWeekId == aTClinicHour.Day).FirstOrDefault().Abbreviation;
                aClinicHourViewModelList.Add(aClinicHourViewModel);
            }

        }

        private IList<ClinicHourViewModel> GetClinicHourViewModel()
        {
            return aClinicHourViewModelList;
        }

        private Clinic CreateNewClinic(ClinicViewModel aClinicViewModel)
        {
            Clinic aClinic = new Clinic();
            var ontarioCityId = aOmsdCustomConext.OntarioCity.Where(x => (x.Name == aClinicViewModel.PhysicalCity)).FirstOrDefault().OntarioCityId;
            var serviceType = aOmsdCustomConext.ServiceType.Where(x => x.Name == aClinicViewModel.ServiceType).FirstOrDefault().ServiceTypeId;
            var status = aOmsdCustomConext.Status.Where(x => x.StatusId == 4).FirstOrDefault().StatusId;
            aClinic.Name = aClinicViewModel.Name;
            aClinic.PhysicalAddressLine1 = aClinicViewModel.PhysicalAddressLine1;
            aClinic.PhysicalAddressLine2 = aClinicViewModel.PhysicalAddressLine2;
            aClinic.PhysicalCity = ontarioCityId;
            aClinic.PhysicalPostalCode = aClinicViewModel.PhysicalPostCode;
            aClinic.Phone1 = aClinicViewModel.Phone1;
            aClinic.Phone2 = aClinicViewModel.Phone2;
            aClinic.Website = aClinicViewModel.Website;
            aClinic.WebsiteFrench = aClinicViewModel.WebsiteFrench;
            aClinic.Email1 = aClinicViewModel.Email1;
            aClinic.Email2 = aClinicViewModel.Email2;
            aClinic.IsEmail1Primary = aClinicViewModel.IsEmail1Primary == "Yes" ? 1 : 0;
            aClinic.AcceptingNew = aClinicViewModel.AcceptingNew == "Yes" ? 1 : 0;
            aClinic.Longitude = aClinicViewModel.Longitude;
            aClinic.Latitude = aClinicViewModel.Latitude;
            aClinic.Fax = aClinicViewModel.Fax;
            aClinic.MailingAddressLine1 = aClinicViewModel.MailingAddressLine1;
            aClinic.MailingAddressLine2 = aClinicViewModel.MailingAddressLine2;
            aClinic.MailingCity = ontarioCityId;
            aClinic.ServiceType = serviceType;
            aClinic.CommunityAndAreasServed = aClinicViewModel.CommunityAndAreasServed;
            aClinic.Description = aClinicViewModel.Description;
            aClinic.DescriptionFrench = aClinicViewModel.DescriptionFrench;
            aClinic.HoursOfBusinessNotes = aClinicViewModel.HoursOfBusinessNotes;
            aClinic.HoursOfBusinessNotesForFrench = aClinicViewModel.HoursOfBusinessNotesForFrench;
            aClinic.Status = status;
            aClinic.CreatedDate = DateTime.Now;
            aClinic.Datecreated = DateTime.Now;
            aClinic.ClinicAdminEmail = aClinicViewModel.ClinicAdminEmail;
            return aClinic;
        }

    }
}