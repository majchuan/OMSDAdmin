using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OMSDAdmin.ViewModels;
using OMSDAdmin.Models;
using Microsoft.AspNetCore.Authorization;

namespace OMSDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DaysOfWeekController : Controller
    {
        private OMSDStagingSTI_CustomContext _OMSDContext;
        private IList<DaysOfWeekViewModel> aDaysOfWeekList; 
        public DaysOfWeekController(OMSDStagingSTI_CustomContext dbContext)
        {
            this._OMSDContext = dbContext;
        }

        [HttpGet("[action]")]
        public IEnumerable<DaysOfWeekViewModel> GetDaysOfWeeks()
        {
           
            using (_OMSDContext)
            {
                var aDaysOfTheWeekList = _OMSDContext.DaysOfTheWeek.ToList();
                SetDaysOfWeekViewModel(aDaysOfTheWeekList);
            }
            return GetDaysOfWeekViewModels(); ;
        }

        public void SetDaysOfWeekViewModel(List<DaysOfTheWeek> aList) 
        {
            aDaysOfWeekList = new List<DaysOfWeekViewModel>();
            foreach(var aDayOfWeek in aList)
            {
                DaysOfWeekViewModel aDayOfWeekViewModel = new DaysOfWeekViewModel();
                aDayOfWeekViewModel.DaysOfTheWeekId = aDayOfWeek.DaysOfTheWeekId;
                aDayOfWeekViewModel.Name = aDayOfWeek.Name;
                aDayOfWeekViewModel.Abbreviation = aDayOfWeek.Abbreviation;
                aDayOfWeekViewModel.Datecreated = aDayOfWeek.Datecreated;
                aDaysOfWeekList.Add(aDayOfWeekViewModel);
            }

        }

        public IEnumerable<DaysOfWeekViewModel> GetDaysOfWeekViewModels()
        {
            return aDaysOfWeekList;
        }
    }
}
