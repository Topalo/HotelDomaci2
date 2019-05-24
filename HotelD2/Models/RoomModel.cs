using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using HotelD2.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HotelD2.Models
{
    public class RoomModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Room> roomCollection;

        public RoomModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            roomCollection = db.GetCollection<Room>("Room");
        }
        //Find all
        public List<Room> findAll()
        {
            return roomCollection.AsQueryable<Room>().ToList();
        }
        //Find one 
        public Room findOne(string id)
        {
            var roomId = new ObjectId(id);

            return roomCollection.AsQueryable<Room>().SingleOrDefault(a => a.Id == roomId);
        }
        //Create one
        public void create(Room room)
        {
            roomCollection.InsertOne(room);
        }
        //Update
        public void update(Room room)
        {
            roomCollection.UpdateOne(Builders<Room>.Filter.Eq("_id", room.Id),
                Builders<Room>.Update
                .Set("category", room.Category)
                .Set("price", room.Price)
                .Set("description", room.Description)
                .Set("available", room.Available)
                );
        }
        //Delete
        public void delete(string id)
        {
            roomCollection.DeleteOne(Builders<Room>.Filter.Eq("_id", ObjectId.Parse(id)));
        }
    }
}