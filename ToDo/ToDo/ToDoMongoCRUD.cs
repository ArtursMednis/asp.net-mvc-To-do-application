using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using ToDo.Models;
using MongoDB.Bson;

namespace ToDo
{
    public class ToDoMongoCRUD
    {
        public static void insertInDB(TaskModelBase document)
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelBase>(Resources.Constants.ToDoTaskTableName);
            collection.InsertOne(document);
        }

        public static TaskModel getDocumentById(string id)
        {
            var filter = Builders<TaskModelFromDB>.Filter.Eq("_id",new ObjectId(id));

            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelFromDB>(Resources.Constants.ToDoTaskTableName);
            var document = collection.Find(filter).First();
            
            return document.TaskModel;
        }

        public static List<TaskModel> getFromDb()
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelFromDB>(Resources.Constants.ToDoTaskTableName);
            List<TaskModelFromDB> modelListDb = collection.Find(new BsonDocument()).ToList();
            List<TaskModel> modelList = modelListDb.Select(modelDb => modelDb.TaskModel).ToList();
            return modelList;
        }

        public static void updateDocument(TaskModelBase document, string id)
        {
            var filter = Builders<TaskModelBase>.Filter.Eq("_id", new ObjectId(id));
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelBase>(Resources.Constants.ToDoTaskTableName);

            collection.ReplaceOne(filter, document);
        }

        public static void deleteDocument(string id)
        {
            var filter = Builders<object>.Filter.Eq("_id", new ObjectId(id));
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<object>(Resources.Constants.ToDoTaskTableName);

            collection.DeleteOne(filter);
        }
    }
}