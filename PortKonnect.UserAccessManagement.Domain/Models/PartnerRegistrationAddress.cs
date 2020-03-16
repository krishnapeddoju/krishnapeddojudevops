using System.ComponentModel.DataAnnotations.Schema;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class PartnerRegistrationAddress
    {
        [Column("HOUSENUMBER")]
        public string HouseNumber { get; protected set; }
        [Column("STREETNAME")]
        public string StreetName { get; protected set; }
        [Column("AREANAME")]
        public string AreaName { get; protected set; }
        [Column("CITY")]
        public string TownOrCity { get; protected set; }
        [Column("STATE")]
        public string State { get; protected set; }
        [Column("COUNTRY")]
        public string Country { get; protected set; }
        [Column("ZIPCODE")]
        public string ZipCode { get; protected set; }
        [Column("EMAIL")]
        public string Email { get; protected set; }
        [Column("MOBILENUMBER")]
        public string MobileNumber { get; protected set; }
        [Column("LOGOFILENAME")]
        public string LogoFileName { get; protected set; }
        [Column("LOGOPATH")]
        public string Logopath { get; protected set; }

        public PartnerRegistrationAddress()
        {

        }

        public PartnerRegistrationAddress(string houseNo, string streetName, string areaName, string townOrCityName, string state, string country, string zipCode, string fileName, string logoPath, string email, string mobileNumber)
        {
            HouseNumber = houseNo.Trim();
            StreetName = streetName.Trim();
            AreaName = areaName.Trim();
            TownOrCity = townOrCityName.Trim();
            State = state;
            Country = country;
            ZipCode = zipCode;
            LogoFileName = fileName;
            Logopath = logoPath;
            Email = email;
            MobileNumber = mobileNumber;
        }

        public void UpdatePartnerRegistrationAddress(string houseNo, string streetName, string areaName, string townOrCityName, string state, string country, string zipCode, string fileName, string logoPath, string email, string mobileNumber)
        {
            HouseNumber = houseNo.Trim();
            StreetName = streetName.Trim();
            AreaName = areaName.Trim();
            TownOrCity = townOrCityName.Trim();
            State = state;
            Country = country;
            ZipCode = zipCode;
            LogoFileName = fileName;
            Logopath = logoPath;
            Email = email;
            MobileNumber = mobileNumber;
        }
    }
}
