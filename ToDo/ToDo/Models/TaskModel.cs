using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace ToDo.Models
{
    public class TaskModelBase
    {
        [Display(Name = "Task title")]
        public string TaskTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public bool Done { get; set; }
    }
    

   
    public class TaskModel : TaskModelBase
    {
        public string ObjectId { get; set; }

        public TaskModelBase TaskModelBase
        {
            get
            {
                TaskModelBase model = new TaskModelBase();
                foreach (PropertyInfo property in typeof(TaskModelBase).GetProperties().Where(p => p.CanWrite))
                {
                    property.SetValue(model, property.GetValue(this, null), null);
                }
                return model;
            }
        }
    }

    [BsonIgnoreExtraElements]
    public class TaskModelFromDB : TaskModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public TaskModel TaskModel
        {
            get
            {
                TaskModel model = new TaskModel();
                foreach (PropertyInfo property in typeof(TaskModelBase).GetProperties().Where(p => p.CanWrite))
                {
                    property.SetValue(model, property.GetValue(this, null), null);
                }
                model.ObjectId = this._id.ToString();
                return model;
            }
        }
    }

}