using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortKonnect.UserAccessManagement.Domain
{
    public class Address 
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
        [Column("CONTACTNUMBER")]
        public string ContactNumber { get; protected set; }
        [Column("EMAILID")]
        public string EmailId { get; protected set; }
        [Column("WEBSITE")]
        public string WebSite { get; protected set; }
        [Column("LOGOFILENAME")]
        public string LogoFileName { get; protected set; }
        [Column("LOGOPATH")]
        public string Logopath { get; protected set; }

        public Address()
        {

        }

        //TODO:  Need to change Country and State to be filled from Country /State standard data service. Presently it is a free text.
        public Address(string houseNo, string streetName, string areaName, string townOrCityName, string state, string country, string zipCode, string contactNumber, string emailId, string webSite,string fileName,string logoPath)
        {
            this.HouseNumber = houseNo;
            this.StreetName = streetName;
            this.AreaName = areaName;
            this.TownOrCity = townOrCityName;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;
            this.ContactNumber = contactNumber;
            this.EmailId = emailId;
            this.WebSite = webSite;
            this.LogoFileName = fileName;
            this.Logopath = logoPath;
        }
    }
}
