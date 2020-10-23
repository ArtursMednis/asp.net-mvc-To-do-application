using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoAPIController : ApiController
    {
        public IHttpActionResult Get()
        {
            var allTasks = ToDoMongoCRUD.getFromDb();
            return Ok(allTasks);
        }

        public IHttpActionResult Get(string id)
        {
            try {
                var task = ToDoMongoCRUD.getDocumentById(id);
                return Ok(task);
            }
            catch
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post(TaskModelBase model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            model.Date = DateTime.SpecifyKind(model.Date, DateTimeKind.Utc);

            ToDoMongoCRUD.insertInDB(model);
            return Ok();
        }

        public IHttpActionResult Put(TaskModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            model.Date = DateTime.SpecifyKind(model.Date, DateTimeKind.Utc);
            try
            {
                ToDoMongoCRUD.updateDocument(model.TaskModelBase, model.ObjectId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        public IHttpActionResult Delete(string id)
        {
            try
            {
                ToDoMongoCRUD.deleteDocument(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
            
        }
        
    }
}