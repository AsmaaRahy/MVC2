using Microsoft.AspNetCore.Mvc;
using Task2MVC.Data;
using Task2MVC.Models;

namespace Task2MVC.Controllers
{

    public class ToDoItemsController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var result = context.ToDoItems.ToList();
            ViewData["msg"] = Request.Cookies["name"];
            return View(result);

        }



        //public IActionResult Items()
        //{
        //    var result = context.ToDoItems.ToList();
        //    ViewData["msg"] = Request.Cookies["name"];
        //    return View(result);
        //}

        public IActionResult CreateNewInList()
        {
            return View();
        }
        public IActionResult SaveNewInList(ToDoItem toDoItem)
        {
            context.ToDoItems.Add(new Models.ToDoItem { Title = toDoItem.Title, Description = toDoItem.Description, Deadline = toDoItem.Deadline });
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = context.ToDoItems.Find(id);
            context.ToDoItems.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ToDoItem todo=context.ToDoItems.Find(id);  
            return View(todo);
            
        }
      
        public ActionResult SaveEdit(ToDoItem toDoItem)
        {
            ToDoItem? ToDoItem = context.ToDoItems.Find(toDoItem.Id);

            ToDoItem.Title = toDoItem.Title;
            ToDoItem.Description = toDoItem.Description;
            ToDoItem.Deadline = toDoItem.Deadline;
            context.SaveChanges();

           
            return RedirectToAction("Index");
        }
        
        
        //public IActionResult Create(String name)
        //{
        //    Response.Cookies.Append("name", name);
        //    ViewData["name"] = name;
        //    var newUser = context.ToDoItems.ToList();



        //    return View("Create",newUser);




        //}


    }
}
