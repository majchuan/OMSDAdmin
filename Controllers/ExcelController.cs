using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSDAdmin.ViewModels;
using OMSDAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using System.IO;


namespace OMSDAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExcelController : ControllerBase
    {
        private readonly OMSDStagingSTI_CustomContext aOmsdCustomConext;
        public ExcelController(OMSDStagingSTI_CustomContext aContext)
        {
            aOmsdCustomConext = aContext;
        }

        [HttpGet("[action]")]
        public IActionResult Download()
        {

            using (aOmsdCustomConext)
            {
                var clinics = aOmsdCustomConext.Clinic.ToList();
                byte[] fileContents;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells[1, 1].LoadFromCollection(clinics, true);
                    fileContents = package.GetAsByteArray();
                }

                if (fileContents == null || fileContents.Length == 0)
                {
                    return NotFound();
                }

                return File(
                    fileContents: fileContents,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: "test.xlsx"
                );
            }
        }



        private const String queryString = @"
(select            0 as Clinic_id

                  ,0 as editstate

                  ,0 as sublistingid

                  ,0 as datecreated

                  ,'' as Phone2

                  ,0 as ShowAcceptingNew

                  ,'' as Status

                  ,'' as Phone1

                  ,'' as Name

                  ,'' as PhysicalCity

                  ,'' as Description

                  ,'' as MailingCity

                  ,'' as MailingPostalCode

                  ,0 as IsEmail1Primary

                  ,'' as Fax

                  ,0 as DateModified

                  ,0 as Longitude

                  ,'' as Website

                  ,'' as Email1

                  ,'' as PhysicalPostalCode

                  ,0 as Latitude

                  ,0 as AcceptingNew

                  ,'' as ServiceType

                  ,0 as CreatedDate

                  ,'' as MailingAddressLine1

                  ,'' as PhysicalAddressLine1

                  ,'' as PhysicalAddressLine2

                  ,'' as MailingAddressLine2

                  ,0 as LHINName

                  ,'' as Email2

                  ,'' as ClinicAdminEmail

                  ,0 as LastModifiedBy

                  ,0 as DateActivated

                  ,'' as WaitTimeID

                  ,'' as WaitTimeInfo

                  ,'' as Website_French

                  ,'' as HSphone2

                  ,'' as Community_And_Areas_Served

                  ,'' as HSphone1

                  ,'' as Description_French

                  ,'' as HSphone3

                  ,0 as diabetesID

                  ,'' as HoursOfBusinessNotes

                  ,0 as IsAvailableForHighRiskScreening

                  ,'' as HoursOfBusinessNotesForFrench 

                  ,'0' as Day1StartTime

                  ,'0' as Day1EndTime 

                  ,'0' as Day2StartTime

                  ,'0' as Day2EndTime

                  ,'0' as Day3StartTime

                  ,'0' as Day3EndTime

                  ,'0' as Day4StartTime

                  ,'0' as Day4EndTime

                  ,'0' as Day5StartTime

                  ,'0' as Day5EndTime

                  ,'0' as Day6StartTime

                  ,'0' as Day6EndTime

                  ,'0' as Day7StartTime

                  ,'0' as Day7EndTime

                  ,'0' as Day8StartTime

                  ,'0' as Day8EndTime
                  
                  from dbo.Clinic )
union (
            Select  

               [Clinic_id]

              ,[editstate]

              ,c.[sublistingid]

              ,[datecreated]

              ,[Phone2]

              ,[ShowAcceptingNew]

              ,(select s.Name from dbo.[Status] s WHERE s.Status_id = [Status] ) as [Status]

              ,[Phone1]

              ,[Name]

              ,(select oc.Name from dbo.OntarioCity oc where oc.OntarioCity_id = [PhysicalCity]) as PhysicalCity

              ,CAST(c.[Description] as NVARCHAR(MAX)) as Description

              ,(select oc.Name from dbo.OntarioCity oc where oc.OntarioCity_id = [MailingCity]) as MailingCity

              ,[MailingPostalCode]

              ,[IsEmail1Primary]

              ,[Fax]

              ,[DateModified]

              ,[Longitude]

              ,[Website]

              ,[Email1]

              ,[PhysicalPostalCode]

              ,[Latitude]

              ,[AcceptingNew]

              ,(select st.Name from dbo.ServiceType st where st.ServiceType_id = [ServiceType]) as ServiceType

              ,[CreatedDate]

              ,[MailingAddressLine1]

              ,[PhysicalAddressLine1]

              ,[PhysicalAddressLine2]

              ,[MailingAddressLine2]

              ,[LHINName]

              ,[Email2]

              ,[ClinicAdminEmail]

              ,[LastModifiedBy]

              ,[DateActivated]

              ,[WaitTimeID]

              ,[WaitTimeInfo]

              ,[Website_French]

              ,[HSphone2]

              ,CAST(c.[Community_And_Areas_Served] as NVARCHAR(MAX)) as Community_And_Areas_Served

              ,[HSphone1]

              ,CAST(c.[Description_French] as NVARCHAR(MAX)) as Description_French

              ,[HSphone3]

              ,[diabetesID]

              ,CAST(c.[HoursOfBusinessNotes] as NVARCHAR(MAX)) as HoursOfBusinessNotes

              ,[IsAvailableForHighRiskScreening]

              ,CAST(c.[HoursOfBusinessNotesForFrench] as NVARCHAR(MAX)) as HoursOfBusinessNotesForFrench

              ,Day1StartTime

              ,Day1EndTime 

              ,Day2StartTime

              ,Day2EndTime

              ,Day3StartTime

              ,Day3EndTime

              ,Day4StartTime

              ,Day4EndTime

              ,Day5StartTime

              ,Day5EndTime

              ,Day6StartTime

              ,Day6EndTime

              ,Day7StartTime

              ,Day7EndTime

              ,Day8StartTime

              ,Day8EndTime from dbo.Clinic c LEFT JOIN 

                (

                select sublistingid, 

                Day1StartTime, 

                Day1EndTime ,

                Day2StartTime,

                Day2EndTime,

                Day3StartTime,

                Day3EndTime,

                Day4StartTime,

                Day4EndTime,

                Day5StartTime,

                Day5EndTime,

                Day6StartTime,

                Day6EndTime,

                Day7StartTime,

                Day7EndTime,

                Day8StartTime,

                Day8EndTime from (

                select tc1.sublistingid, tc1.StartTime , tc1.DayStartTime, tc2.EndTime, tc2.DayEndTime from (

                select t1.sublistingid, t1.StartTime, 'Day'+cast(t1.Day as [varchar]) +'StartTime' as DayStartTime from dbo.t_ClinicHours t1 ) tc1

                INNER JOIN (select t2.sublistingid, t2.EndTime, 'Day' + CAST(t2.Day as [varchar]) +'EndTime' as DayEndTime from dbo.t_ClinicHours t2) tc2

                on tc1.sublistingid = tc2.sublistingid

                ) as source

                PIVOT (

                    max(StartTime) for DayStartTime in (Day1StartTime, Day2StartTime, Day3StartTime, Day4StartTime, Day5StartTime, Day6StartTime,Day7StartTime,Day8StartTime)

                ) as target1

                PIVOT (

                    max(EndTime) for DayEndTime in (Day1EndTime, Day2EndTime, Day3EndTime, Day4EndTime, Day5EndTime, Day6EndTime,Day7EndTime,Day8EndTime)

                ) as Target2

 

                ) as ch 

        on c.Clinic_id = ch.sublistingid
        where c.Status = 4
        
)
order by Clinic_id
;
        ";


        [HttpGet("[action]")]
        public async Task<IActionResult> Download2Async()
        {
            using (aOmsdCustomConext)
            {
                var clinics = aOmsdCustomConext.Clinic.ToList();
                var users = aOmsdCustomConext.ClinicUser.ToList();
                var cities = aOmsdCustomConext.OntarioCity.ToList();
                var serviceTypes = aOmsdCustomConext.ServiceType.ToList();
                var status = aOmsdCustomConext.Status.ToList();


                byte[] fileContents;

                var conn = aOmsdCustomConext.Database.GetDbConnection();
                await conn.OpenAsync();
                var command = conn.CreateCommand();
                const string query = queryString;
                command.CommandText = query;
                var reader = await command.ExecuteReaderAsync();



                while (await reader.ReadAsync())
                {
                    using (var package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Clinic");
                        worksheet.Cells[1, 1].LoadFromDataReader(reader,true);

                        for (int i = 2; i < clinics.Count + 2; i++)
                        {
                            worksheet.Cells[i, 4].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            worksheet.Column(4).Width = 18;

                            worksheet.Cells[i, 16].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            worksheet.Column(16).Width = 18;

                            worksheet.Cells[i, 24].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            worksheet.Column(24).Width = 18;

                            worksheet.Cells[i, 33].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                            worksheet.Column(33).Width = 18;

                        }


                        /*ExcelWorksheet usersWorksheet = package.Workbook.Worksheets.Add("ClinicUser");
                        usersWorksheet.Cells[1, 1].LoadFromCollection(users, true);*/

                        ExcelWorksheet citiesWorksheet = package.Workbook.Worksheets.Add("OntarioCity");
                        citiesWorksheet.Cells[1, 1].LoadFromCollection(cities, true);

                        ExcelWorksheet serviceTypesWorksheet = package.Workbook.Worksheets.Add("ServiceType");
                        serviceTypesWorksheet.Cells[1, 1].LoadFromCollection(serviceTypes, true);

                        ExcelWorksheet statusWorksheet = package.Workbook.Worksheets.Add("Status");
                        statusWorksheet.Cells[1, 1].LoadFromCollection(status, true);

                        fileContents = package.GetAsByteArray();
                    }

                    if (fileContents == null || fileContents.Length == 0)
                    {
                        return NotFound();
                    }

                    return File(
                        fileContents: fileContents,
                        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileDownloadName: "clinics.xlsx"
                    );
                }

                return Ok();
            }
        }

    }
}