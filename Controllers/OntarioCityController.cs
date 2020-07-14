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
    public class OntarioCityController : Controller
    {
        private readonly OMSDStagingSTI_CustomContext aOmsdCustomConext;
        private IList<CityViewModel> aCityViewModelList;

        public OntarioCityController(OMSDStagingSTI_CustomContext aContext)
        {
            aOmsdCustomConext = aContext;
        }

        [HttpGet("[action]")]
        public IEnumerable<CityViewModel> GetCities()
        {
            IList<CityViewModel> aList = new List<CityViewModel>();
            using (aOmsdCustomConext)
            {
                var cities = aOmsdCustomConext.OntarioCity.ToList();
                foreach (var aCity in cities)
                {
                    CityViewModel aCityViewModel = new CityViewModel();
                    aCityViewModel.OntarioCityId = aCity.OntarioCityId;
                    aCityViewModel.Editstate = aCity.Editstate;
                    aCityViewModel.Sublistingid = aCity.Sublistingid;
                    aCityViewModel.Datecreated = aCity.Datecreated;
                    aCityViewModel.Name = aCity.Name;
                    aCityViewModel.Lat = aCity.Lat;
                    aCityViewModel.Long = aCity.Long;
                    aCityViewModel.DiabetesId = aCity.DiabetesId;
                    aList.Add(aCityViewModel);
                }

                return aList;
            }

        }

        [HttpPost("[action]")]
        public IEnumerable<CityViewModel> SearchCities([FromBody]String searchKeyWord)
        {
            int searchKeyWordInt;
            if (!int.TryParse(searchKeyWord, out searchKeyWordInt)) searchKeyWordInt = -999;

            IList<CityViewModel> aList = new List<CityViewModel>();
            var aCitiesList = aOmsdCustomConext.OntarioCity
                .Where(x => x.Name.Contains(searchKeyWord) ||
                            (x.OntarioCityId == searchKeyWordInt) 
                            ).ToList();
            if (aCitiesList != null && aCitiesList.Count > 0)
            {
                foreach (var aCity in aCitiesList)
                {
                    CityViewModel aCityViewModel = new CityViewModel();
                    aCityViewModel.OntarioCityId = aCity.OntarioCityId;
                    aCityViewModel.Editstate = aCity.Editstate;
                    aCityViewModel.Sublistingid = aCity.Sublistingid;
                    aCityViewModel.Datecreated = aCity.Datecreated;
                    aCityViewModel.Name = aCity.Name;
                    aCityViewModel.Lat = aCity.Lat;
                    aCityViewModel.Long = aCity.Long;
                    aCityViewModel.DiabetesId = aCity.DiabetesId;
                    aList.Add(aCityViewModel);
                }
            }
            return aList;
        }

        [HttpGet("[action]/{id}")]
        public CityViewModel GetCity(Int32 id)
        {
            using (aOmsdCustomConext)
            {
                try
                {
                    var aCity = aOmsdCustomConext.OntarioCity.SingleOrDefault(y => y.OntarioCityId == id);

                    CityViewModel aCityViewModel = new CityViewModel();
                    aCityViewModel.OntarioCityId = aCity.OntarioCityId;
                    aCityViewModel.Editstate = aCity.Editstate;
                    aCityViewModel.Sublistingid = aCity.Sublistingid;
                    aCityViewModel.Datecreated = aCity.Datecreated;
                    aCityViewModel.Name = aCity.Name;
                    aCityViewModel.Lat = aCity.Lat;
                    aCityViewModel.Long = aCity.Long;
                    aCityViewModel.DiabetesId = aCity.DiabetesId;

                    return aCityViewModel;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [HttpPut("[action]")]
        public CityViewModel UpdateCity([FromBody]CityViewModel aCityViewModel)
        {
            using (aOmsdCustomConext)
            {
                try
                {

                    bool cityExist = aOmsdCustomConext.OntarioCity.Any(c => (c.OntarioCityId == aCityViewModel.OntarioCityId));
                    if (!cityExist)
                    {
                        aCityViewModel.OntarioCityId = -1;
                        return aCityViewModel;
                    }


                    var aCity = aOmsdCustomConext.OntarioCity.Find(aCityViewModel.OntarioCityId);
                    aCity.Name = aCityViewModel.Name;
                    aCity.Lat = aCityViewModel.Lat;
                    aCity.Long = aCityViewModel.Long;
                    aOmsdCustomConext.SaveChanges();

                    return aCityViewModel;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        [HttpPost("[action]")]
        public CityViewModel AddCity([FromBody]CityViewModel aCityViewModel)
        {

            OntarioCity aCity = new OntarioCity();
            aCity.Name = aCityViewModel.Name;
            aCity.Lat = aCityViewModel.Lat;
            aCity.Long = aCityViewModel.Long;
            aCity.Editstate = -4;
            aCity.Sublistingid = 0;
            aCity.Datecreated = DateTime.Now;


            aOmsdCustomConext.OntarioCity.Add(aCity);
            aOmsdCustomConext.SaveChanges();
            return aCityViewModel;

        }

        [HttpDelete("[action]/{aCityId}")]
        public void DeleteCity(Int32 aCityId)
        {
            using (aOmsdCustomConext)
            {
                bool cityExist = aOmsdCustomConext.OntarioCity.Any(c => (c.OntarioCityId == aCityId));
                if (!cityExist)
                {
                    return;
                }
                var aDeleteCity = aOmsdCustomConext.OntarioCity.Find(aCityId);
                aOmsdCustomConext.OntarioCity.Remove(aDeleteCity);
                aOmsdCustomConext.SaveChanges();
            }
        }

    }
}