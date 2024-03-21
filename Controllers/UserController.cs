using Microsoft.AspNetCore.Mvc;
using Task2MVC.Data;

namespace Task2MVC.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {

            return View();
        }
    //    [HttpPost]
    //    public IActionResult Create(String name)
    //    {
    //        var newUser = context.ToDoItems.ToList();
    //        Response.Cookies.Append("name",name);
    //        ViewData["name"] = name;

    //        return View("Create","User");
          
           

            
    //    }
    }
}
