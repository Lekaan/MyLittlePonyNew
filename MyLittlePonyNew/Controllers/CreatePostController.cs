using Microsoft.AspNetCore.Mvc;
using MyLittlePonyNew.Models;
using MyLittlePonyNew.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyLittlePonyNew.Controllers
{
    public class CreatePostController : Controller
    {
        public IActionResult Index()
        {
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                return Redirect("/");
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewPost()
        {
            string title = HttpContext.Request.Form["txtTitle"];
            string content = HttpContext.Request.Form["txtContent"];
            string author = HttpContext.Session.GetString("username");

            BlogPostRepository.Instance.CreatePost(title, content, author);

            return Redirect("/");
        }
    }
}
