using Api_Mongodb.Data.Collections;
using Api_Mongodb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api_Mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;
        public InfectedController(Data.MongoDB mongoDB)
        {
            mongoDB = _mongoDB;
            _infectedCollection = mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
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
        }
    }
}