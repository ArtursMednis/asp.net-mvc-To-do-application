using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;

namespace ToDo.Models
{
    public class ToDoModel
    {
        public int id { get; set; }

        [Display(Name = "Task title")]
        public string TaskTitle { get; set; }

        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime Date { get; set; }
        public bool Done { get; set; }



        public static List<ToDoModel> getFromDB() {

            var testList = new List<ToDoModel>{
                            new ToDoModel() { id=1, TaskTitle = "darbs1", Description="apraksts1", Date=new DateTime() } ,
                            new ToDoModel() { id=2, TaskTitle = "darbs2", Description="apraksts2", Date=new DateTime(),Done=false } ,
                            new ToDoModel() { id=3, TaskTitle = "darbs3", Description="apraksts3", Date=new DateTime(),Done=true } ,
                            new ToDoModel() { id=4, TaskTitle = "darbs4", Description="apraksts4", Date=new DateTime() } ,
                            new ToDoModel() { id=5, TaskTitle = "darbs5", Description="apraksts5", Date=new DateTime()} ,
                            new ToDoModel() { id=6, TaskTitle = "darbs6", Description="apraksts6", Date=new DateTime(),Done=false }
                        };

            //return testList;
            return test1();
        }

        //public void insertInDB() {
        //    MongoClient client = new MongoClient();
        //    IMongoDatabase db = client.GetDatabase(Resources.Constants.ToDoDBName);
        //    var collection = db.GetCollection<T>(table);
        //    collection.InsertOne(record);
        //}

        //update 
        //delete

        static List<ToDoModel> test1()
        {
            List<ToDoModel> modList = new List<ToDoModel>();

            MongoClient dbClient = new MongoClient();

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                ToDoModel model1 = new ToDoModel() { id = 1, TaskTitle = "darbs1", Description = db.ToString(), Date = new DateTime() };
                modList.Add(model1);
            }
            return modList;
        }

    }
}