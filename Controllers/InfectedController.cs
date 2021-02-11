using System;
using System.Timers;
using Api_Mongodb.Data.Collections;
using Api_Mongodb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api_Mongodb.Controllers
{
    [ApiController]
    [Route("infected")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;
        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }
        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDTO dto )
        {

           var infected = new Infected(dto.birthDate, dto.gender, dto.latitude, dto.longitude);
           _infectedCollection.InsertOne(infected);
           return StatusCode(201, "Infected added in the collection");
        }

        [HttpGet]
        public ActionResult getInfected() 
        {
            var infected_list = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            return Ok(infected_list);
        }
    }
}