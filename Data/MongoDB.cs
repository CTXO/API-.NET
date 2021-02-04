using System;
using Api_Mongodb.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Api_Mongodb.Data{
    public class MongoDB{
        public IMongoDatabase DB {get;}
        public MongoDB(IConfiguration confiiguration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(confiiguration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(confiiguration["DBname"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                
                throw new MongoException("It was not possible to connect to MongoDB", ex);
            }
            
        }

        public void MapClasses()
        {
            var conventionPack = new ConventionPack{ new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infected)))
            {
                BsonClassMap.RegisterClassMap<Infected>(i => 
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }

    }
}