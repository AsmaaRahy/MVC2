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

            return View();
        }



        public IActionResult Items()
        {
            var result = context.ToDoItems.ToList();
            ViewData["msg"] = Request.Cookies["name"];
            return View(result);
        }

        public IActionResult CreateNewInList()
        {
            return View();
        }
        public IActionResult SaveNewInList(ToDoItem toDoItem)
        {
            context.ToDoItems.Add(new Models.ToDoItem { Title = toDoItem.Title, Description = toDoItem.Description, Deadline = toDoItem.Deadline });
            context.SaveChanges();

            return RedirectToAction("Items");
        }

        public IActionResult Delete(int id)
        {
            var item = context.ToDoItems.Find(id);
            context.ToDoItems.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Items");
        }

        public ActionResult Edit(int id)
        {
            var item = context.ToDoItems.Where(e=>e.Id== id);

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Models.ToDoItem toDoItem)
        {
           var item = context.ToDoItems.Find(toDoItem.Id);

            if (item is not null)
            {
                item.Title = toDoItem.Title;
                item.Description = toDoItem.Description;
                item.Deadline = toDoItem.Deadline;
                context.SaveChanges();

            }
            return RedirectToAction("Items");
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
