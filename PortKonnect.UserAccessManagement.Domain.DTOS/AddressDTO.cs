using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class AddressDTO
    {
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string AreaName { get; set; }
        public string TownOrCity { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string WebSite { get; set; }
        public string LogoFileName { get; set; }
        public string LogoPath { get; set; }

        public AddressDTO()
        {
        }

        public AddressDTO(string houseNumber, string streetName, string areaName, string townOrCity, string state, string country, string zipCode, string contactNumber, string emailId, string webSite,string fileName,string logoPath)
        {
            HouseNumber = houseNumber;
            StreetName = streetName;
            AreaName = areaName;
            TownOrCity = townOrCity;
            State = state;
            Country = country;
            ZipCode = zipCode;
            ContactNumber = contactNumber;
            EmailId = emailId;
            WebSite = webSite;
            LogoFileName = fileName;
            LogoPath = logoPath;
        }
    }
}