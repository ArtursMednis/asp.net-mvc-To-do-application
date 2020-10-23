using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using ToDo.Models;
using MongoDB.Bson;
using System.Security.Authentication;

namespace ToDo
{
    public class ToDoMongoCRUD
    {
        public static void insertInDB(TaskModelBase document)
        {
            MongoClient client = getClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelBase>(Resources.Constants.ToDoTaskTableName);
            collection.InsertOne(document);
        }

        public static TaskModel getDocumentById(string id)
        {
            var filter = Builders<TaskModelFromDB>.Filter.Eq("_id",new ObjectId(id));

            MongoClient client = getClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelFromDB>(Resources.Constants.ToDoTaskTableName);
            var document = collection.Find(filter).First();
            
            return document.TaskModel;
        }

        public static List<TaskModel> getFromDb()
        {
            MongoClient client = getClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelFromDB>(Resources.Constants.ToDoTaskTableName);
            List<TaskModelFromDB> modelListDb = collection.Find(new BsonDocument()).ToList();
            List<TaskModel> modelList = modelListDb.Select(modelDb => modelDb.TaskModel).ToList();
            return modelList;
        }

        public static void updateDocument(TaskModelBase document, string id)
        {
            var filter = Builders<TaskModelBase>.Filter.Eq("_id", new ObjectId(id));
            MongoClient client = getClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<TaskModelBase>(Resources.Constants.ToDoTaskTableName);

            collection.ReplaceOne(filter, document);
        }

        public static void deleteDocument(string id)
        {
            var filter = Builders<object>.Filter.Eq("_id", new ObjectId(id));
            MongoClient client = getClient();
            IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
            var collection = db.GetCollection<object>(Resources.Constants.ToDoTaskTableName);

            collection.DeleteOne(filter);
        }
        private static MongoClient getClient()
        {
            MongoClientSettings settings = new MongoClientSettings();
            int port = Int32.Parse(Resources.Constants.DBPort);
            settings.Server = new MongoServerAddress(Resources.Constants.DBHost, port);
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
            settings.RetryWrites = false;

            MongoIdentity identity = new MongoInternalIdentity(Resources.Constants.ToDoDBName, Resources.Constants.DBUser);
            
            MongoIdentityEvidence evidence = new PasswordEvidence(Resources.Constants.DBPaswd);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            MongoClient dbClient = new MongoClient(settings);
            return dbClient;
        }

        

        private static MongoClient getClientLocal()
        {
            return new MongoClient();
        }
    }
}