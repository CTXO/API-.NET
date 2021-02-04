using System;

namespace Api_Mongodb.Models
{
    public class InfectedDTO
    {
        public DateTime birthDate {get; set;}
        public string gender {get; set;}

        public double latitude{get; set;}
        public double longitude{get; set;}
    }
}