using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mohmd.AspNetCore.PortableResolver.Sample.Models;
using Mohmd.AspNetCore.PortableResolver.Sample.Services;

namespace Mohmd.AspNetCore.PortableResolver.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChildService _childService;

        public HomeController(ChildService childService)
        {
            _childService = childService;
        }

        public IActionResult Index()
        {
            string child = _childService.Name;
            string parent = _childService.GetParentName();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
