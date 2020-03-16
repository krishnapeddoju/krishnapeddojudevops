namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class PartnerRegistrationAddressDTO
    {
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string AreaName { get; set; }
        public string TownOrCity { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string LogoFileName { get; set; }
        public string LogoPath { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public PartnerRegistrationAddressDTO()
        {
        }

        public PartnerRegistrationAddressDTO(string houseNumber, string streetName, string areaName, string townOrCity, string state, string country, string zipCode, string fileName, string logoPath, string email, string mobileNumber)
        {
            HouseNumber = houseNumber;
            StreetName = streetName;
            AreaName = areaName;
            TownOrCity = townOrCity;
            State = state;
            Country = country;
            ZipCode = zipCode;
            LogoFileName = fileName;
            LogoPath = logoPath;
            Email = email;
            MobileNumber = mobileNumber;
        }
    }
}

