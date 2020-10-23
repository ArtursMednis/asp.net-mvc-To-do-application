using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        public ActionResult Index()
        {
            var allTasks = ToDoMongoCRUD.getFromDb();
            return View(allTasks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var model = new TaskModel();
                UpdateModel<TaskModel>(model);
                model.Date = DateTime.SpecifyKind(model.Date, DateTimeKind.Utc);

                ToDoMongoCRUD.insertInDB(model.TaskModelBase);
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                string exc = ex.ToString();
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var task = ToDoMongoCRUD.getDocumentById(id);
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var model = new TaskModel();
                UpdateModel<TaskModel>(model);

                model.Date = DateTime.SpecifyKind(model.Date, DateTimeKind.Utc);
                
                ToDoMongoCRUD.updateDocument(model.TaskModelBase, id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            ToDoMongoCRUD.deleteDocument(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
