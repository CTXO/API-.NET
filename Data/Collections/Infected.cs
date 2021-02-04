using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api_Mongodb.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime birthDate, string gender, double latitude, double longitude){
            this.birthDate = birthDate;
            this.gender = gender;
            this.location = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        public DateTime birthDate;
        public string gender;
        public GeoJson2DGeographicCoordinates location;
        
    }
}