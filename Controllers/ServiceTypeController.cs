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
    public class ServiceTypeController : ControllerBase
    {
        private readonly OMSDStagingSTI_CustomContext aOmsdCustomConext;


        public ServiceTypeController(OMSDStagingSTI_CustomContext aContext)
        {
            aOmsdCustomConext = aContext;
        }


        [HttpGet("[action]")]
        public IEnumerable<ServiceTypeViewModel> GetServiceTypes()
        {
            IList<ServiceTypeViewModel> aList = new List<ServiceTypeViewModel>();
            using (aOmsdCustomConext)
            {
                var serviceTypes = aOmsdCustomConext.ServiceType.ToList();
                foreach (var aServiceType in serviceTypes)
                {
                    ServiceTypeViewModel aServiceTypeViewModel = new ServiceTypeViewModel();
                    aServiceTypeViewModel.ServiceTypeId = aServiceType.ServiceTypeId;
                    aServiceTypeViewModel.Editstate = aServiceType.Editstate;
                    aServiceTypeViewModel.Sublistingid = aServiceType.Sublistingid;
                    aServiceTypeViewModel.Datecreated = aServiceType.Datecreated;
                    aServiceTypeViewModel.Name = aServiceType.Name;
                    aServiceTypeViewModel.Image = aServiceType.Image;
                    aServiceTypeViewModel.SortOrder = aServiceType.SortOrder;
                    aList.Add(aServiceTypeViewModel);
                }
                return aList;
            }
        }


        [HttpPost("[action]")]
        public IEnumerable<ServiceTypeViewModel> SearchServiceTypes([FromBody]String searchKeyWord)
        {
            int searchKeyWordInt;
            if (!int.TryParse(searchKeyWord, out searchKeyWordInt)) searchKeyWordInt = -999;

            IList<ServiceTypeViewModel> aList = new List<ServiceTypeViewModel>();
            var aServiceTypesList = aOmsdCustomConext.ServiceType
                .Where(x => x.Name.Contains(searchKeyWord) ||
                            (x.ServiceTypeId == searchKeyWordInt)
                            ).ToList();
            if (aServiceTypesList != null && aServiceTypesList.Count > 0)
            {
                foreach (var aServiceType in aServiceTypesList)
                {
                    ServiceTypeViewModel aServiceTypeViewModel = new ServiceTypeViewModel();
                    aServiceTypeViewModel.ServiceTypeId = aServiceType.ServiceTypeId;
                    aServiceTypeViewModel.Editstate = aServiceType.Editstate;
                    aServiceTypeViewModel.Sublistingid = aServiceType.Sublistingid;
                    aServiceTypeViewModel.Datecreated = aServiceType.Datecreated;
                    aServiceTypeViewModel.Name = aServiceType.Name;
                    aServiceTypeViewModel.Image = aServiceType.Image;
                    aServiceTypeViewModel.SortOrder = aServiceType.SortOrder;
                    aList.Add(aServiceTypeViewModel);
                }
            }
            return aList;
        }

        [HttpGet("[action]/{id}")]
        public ServiceTypeViewModel GetServiceType(Int32 id)
        {
            using (aOmsdCustomConext)
            {
                try
                {
                    var aServiceType = aOmsdCustomConext.ServiceType.SingleOrDefault(y => y.ServiceTypeId == id);

                    ServiceTypeViewModel aServiceTypeViewModel = new ServiceTypeViewModel();
                    aServiceTypeViewModel.ServiceTypeId = aServiceType.ServiceTypeId;
                    aServiceTypeViewModel.Editstate = aServiceType.Editstate;
                    aServiceTypeViewModel.Sublistingid = aServiceType.Sublistingid;
                    aServiceTypeViewModel.Datecreated = aServiceType.Datecreated;
                    aServiceTypeViewModel.Name = aServiceType.Name;
                    aServiceTypeViewModel.Image = aServiceType.Image;
                    aServiceTypeViewModel.SortOrder = aServiceType.SortOrder;

                    return aServiceTypeViewModel;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [HttpPut("[action]")]
        public ServiceTypeViewModel UpdateServiceType([FromBody]ServiceTypeViewModel aServiceTypeViewModel)
        {
            using (aOmsdCustomConext)
            {
                try
                {

                    bool serviceTypeExist = aOmsdCustomConext.ServiceType.Any(c => (c.ServiceTypeId == aServiceTypeViewModel.ServiceTypeId));
                    if (!serviceTypeExist)
                    {
                        aServiceTypeViewModel.ServiceTypeId = -1;
                        return aServiceTypeViewModel;
                    }


                    var aServiceType = aOmsdCustomConext.ServiceType.Find(aServiceTypeViewModel.ServiceTypeId);
                    aServiceType.Name = aServiceTypeViewModel.Name;
                    aServiceType.Image = aServiceTypeViewModel.Image;
                    aOmsdCustomConext.SaveChanges();

                    return aServiceTypeViewModel;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }


        [HttpPost("[action]")]
        public ServiceTypeViewModel AddServiceType([FromBody]ServiceTypeViewModel aServiceTypeViewModel)
        {

            ServiceType aServiceType = new ServiceType();
            aServiceType.Name = aServiceTypeViewModel.Name;
            aServiceType.Image = aServiceTypeViewModel.Image;
            aServiceType.Editstate = -4;
            aServiceType.Sublistingid = 0;
            aServiceType.Datecreated = DateTime.Now;
            aServiceType.SortOrder = 100;

            aOmsdCustomConext.ServiceType.Add(aServiceType);
            aOmsdCustomConext.SaveChanges();
            return aServiceTypeViewModel;

        }


        [HttpDelete("[action]/{aServiceTypeId}")]
        public void DeleteServiceType(Int32 aServiceTypeId)
        {
            using (aOmsdCustomConext)
            {
                bool serviceTypeExist = aOmsdCustomConext.ServiceType.Any(c => (c.ServiceTypeId == aServiceTypeId));
                if (!serviceTypeExist)
                {
                    return;
                }
                var aDeleteServiceType = aOmsdCustomConext.ServiceType.Find(aServiceTypeId);
                aOmsdCustomConext.ServiceType.Remove(aDeleteServiceType);
                aOmsdCustomConext.SaveChanges();
            }
        }






    }

}