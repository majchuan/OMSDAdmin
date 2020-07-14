using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OMSDAdmin.ViewModels;
using OMSDAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace OMSDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicHourController : Controller
    {
        private OMSDStagingSTI_CustomContext _aOMSDContext;
        private IList<ClinicHourViewModel> aClinicHourViewList = null;
        public ClinicHourController(OMSDStagingSTI_CustomContext dbContext)
        {
            _aOMSDContext = dbContext as OMSDStagingSTI_CustomContext;
        }

        [HttpGet("[action]/{id}")]
        public IEnumerable<ClinicHourViewModel> GetClinicHours(int id)
        {
            using (_aOMSDContext)
            {
                var aClinicHours = _aOMSDContext.TClinicHours.Where(x => x.Sublistingid == id).ToList();
                var aDaysOfTheWeek = _aOMSDContext.DaysOfTheWeek.ToList();
                SetClinicHourView(aClinicHours, aDaysOfTheWeek);
                return GetClinicHoursView();
            }
        }
        [HttpDelete("[action]/{id}")]
        public void DeleteClinicHours(int id)
        {
            using (_aOMSDContext)
            {
                var aClinicHour = _aOMSDContext.TClinicHours.Find(id);
                if (aClinicHour != null)
                {
                    _aOMSDContext.Remove(aClinicHour);
                    _aOMSDContext.SaveChanges();
                }
            }
        }

        [HttpPut("[action]")]
        public void UpdateClinicHour([FromBody]ClinicHourViewModel aClinicHourViewModel)
        {
            using (_aOMSDContext)
            {

                var aClinicHourList = _aOMSDContext.TClinicHours.Where(h => h.Sublistingid == aClinicHourViewModel.ClinicID).ToList();
                var dayOfWeekConfilct = false;
                foreach (var h in aClinicHourList)
                {
                    if (h.Day == aClinicHourViewModel.Day && h.TClinicHoursId != aClinicHourViewModel.TClinicHoursId)
                    {
                        dayOfWeekConfilct = true;
                    }
                }


                var aClinicHour = _aOMSDContext.TClinicHours.Find(aClinicHourViewModel.TClinicHoursId);
                if (aClinicHour != null && dayOfWeekConfilct == false)
                {
                    aClinicHour.Day = aClinicHourViewModel.Day;
                    aClinicHour.StartTime = aClinicHourViewModel.StartTime;
                    aClinicHour.EndTime = aClinicHourViewModel.EndTime;
                    _aOMSDContext.SaveChanges();
                }
            }
        }


        [HttpDelete("[action]/{clinicId}")]
        public void DeleteClinicClinicHours(int clinicId)
        {
            using (_aOMSDContext)
            {
                var aClinicHourList = _aOMSDContext.TClinicHours.Where(x => x.Sublistingid == clinicId).ToList();
                aClinicHourList.Clear();
                _aOMSDContext.SaveChanges();
            }
        }

        [HttpPost("[action]")]
        public void CreateClinicHour([FromBody] ClinicHourViewModel aClinicHourView)
        {
            try
            {
                using (_aOMSDContext)
                {
                    var aClinicHour = new TClinicHours();
                    aClinicHour.Sublistingid = aClinicHourView.ClinicID;
                    aClinicHour.Editstate = aClinicHourView.Editstate;
                    aClinicHour.Datecreated = aClinicHourView.Datecreated;
                    aClinicHour.StartTime = aClinicHourView.StartTime;
                    aClinicHour.EndTime = aClinicHourView.EndTime;
                    aClinicHour.Day = aClinicHourView.Day;

                    _aOMSDContext.Add<TClinicHours>(aClinicHour);
                    _aOMSDContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Add new clinic hours issue" + ex.Message);
            }
        }

        private void SetClinicHourView(IEnumerable<TClinicHours> aClinicHourList, IEnumerable<DaysOfTheWeek> aDaysOfTheWeeks )
        {
            aClinicHourViewList = new List<ClinicHourViewModel>();
            foreach(var aTClinicHour in aClinicHourList)
            {
                ClinicHourViewModel aClinicHourViewModel = new ClinicHourViewModel();
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

                aClinicHourViewList.Add(aClinicHourViewModel);

            }
        }

        private IEnumerable<ClinicHourViewModel> GetClinicHoursView()
        {
            return aClinicHourViewList;
        }
    }
}
