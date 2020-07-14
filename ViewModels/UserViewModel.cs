using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSDAdmin.ViewModels
{
    public class UserViewModel
    {
        public Int32 UserId { get; set; }
        public string Email { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
    }

    public struct UserType
    {
        public static readonly UserType ClinicUser = new UserType(1,"Clinic User");
        public static readonly UserType AdminUser = new UserType(3, "Admin");

        public int Id { get; private set; }
        public string Name { get; private set; }

        private UserType(int aUserTypeId, string aUserTypeValue)
        {
            Id = aUserTypeId;
            Name = aUserTypeValue;
        }
    }

    public struct Province
    {
        public static readonly Province Ontario = new Province(1, "Ontario");
        public static readonly Province Quebec = new Province(2, "Quebec");
        public static readonly Province NovaScotia = new Province(3, "Nova Scotia");
        public static readonly Province NewBrunswick = new Province(4, "New Brunswick");
        public static readonly Province Manitoba = new Province(4, "Manitoba");
        public static readonly Province BritishColumbia = new Province(6, "British Columbia");
        public static readonly Province PrinceEdwardIsland = new Province(7, "Prince Edward Island");
        public static readonly Province Saskatchewan = new Province(8, "Saskatchewan");
        public static readonly Province Alberta = new Province(9, "Alberta");
        public static readonly Province Newfoundland = new Province(10, "Newfoundland and Labrador");
        public static readonly Province NorthwestTerritories = new Province(11, "Northwest Territories");
        public static readonly Province Yukon = new Province(12, "Yukon");
        public static readonly Province Nunavut = new Province(13, "Nunavut");

        public int Id { get; private set; }
        public string Name { get; private set; }

        private Province(int aProvinceId, string aProvinceName)
        {
            this.Id = aProvinceId;
            this.Name = aProvinceName;
        }

        public static Province Find(int aProvinceID)
        {
            Province aProvince = Ontario;
            switch (aProvinceID)
            {
                case 1:
                    aProvince = Ontario;
                    break;
                case 2:
                    aProvince = Quebec;
                    break;
                case 3:
                    aProvince =NovaScotia;
                    break;
                case 4:
                    aProvince = NewBrunswick;
                    break;
                case 5:
                    aProvince = Manitoba;
                    break;
                case 6:
                    aProvince = BritishColumbia;
                    break;
                case 7:
                    aProvince = PrinceEdwardIsland;
                    break;
                case 8:
                    aProvince = Saskatchewan;
                    break;
                case 9:
                    aProvince = Alberta;
                    break;
                case 10:
                    aProvince = Newfoundland;
                    break;
                case 11:
                    aProvince = NorthwestTerritories;
                    break;
                case 12:
                    aProvince = Yukon;
                    break;
                case 13:
                    aProvince = Nunavut;
                    break;
            }

            return aProvince;

        }

        public static Province Find(string name)
        {
            Province aProvince = Ontario;
            switch (name.ToLower())
            {
                case "ontario":
                    aProvince = Ontario;
                    break;
                case "quebec":
                    aProvince = Quebec;
                    break;
                case "nova scotia":
                    aProvince = NovaScotia;
                    break;
                case "new brunswick":
                    aProvince = NewBrunswick;
                    break;
                case "manitoba":
                    aProvince = Manitoba;
                    break;
                case "british columbia":
                    aProvince = BritishColumbia;
                    break;
                case "prince edward island":
                    aProvince = PrinceEdwardIsland;
                    break;
                case "saskatchewan":
                    aProvince = Saskatchewan;
                    break;
                case "alberta":
                    aProvince = Alberta;
                    break;
                case "newfoundland and labrador":
                    aProvince = Newfoundland;
                    break;
                case "northwest territories":
                    aProvince = NorthwestTerritories;
                    break;
                case "yukon":
                    aProvince = Yukon;
                    break;
                case "nunavut":
                    aProvince = Nunavut;
                    break;
            }

            return aProvince;
        }
    }
}
