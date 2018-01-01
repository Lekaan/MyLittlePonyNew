using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLittlePonyNew.Models;
using MyLittlePonyNew.Repositories;
using MyLittlePonyNew.ViewModel;
using Microsoft.AspNetCore.Http;

namespace MyLittlePonyNew.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult GetWithAuthor()
        {
            var viewModel = new IndexViewModel();
            viewModel.AuthorName = HttpContext.Request.Form["txtAuthor"];
            HttpContext.Session.SetString("username", viewModel.AuthorName);
            if (string.IsNullOrEmpty(viewModel.AuthorName))
            {
                viewModel.BlogPosts = BlogPostRepository.Instance.GetAllPosts();
                return View("Index", viewModel);
            }

            viewModel.BlogPosts = BlogPostRepository.Instance.ReturnPostByAuthor(viewModel.AuthorName);
            return View("Index", viewModel);
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                viewModel.BlogPosts = BlogPostRepository.Instance.GetAllPosts();
                return View(viewModel);
            }
            viewModel.AuthorName = HttpContext.Session.GetString("username");
            viewModel.BlogPosts = BlogPostRepository.Instance.ReturnPostByAuthor(viewModel.AuthorName);
            return View("Index", viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
