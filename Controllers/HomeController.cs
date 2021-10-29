using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalkersWebApp.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace WalkersWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Walkers is a leading international law firm. We advise on the laws of Bermuda, the British Virgin Islands, the Cayman Islands, Guernsey, Ireland and Jersey.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Walkers Global";

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

        [HttpPost]
        [Route("Execute")]
        public ActionResult Execute(int inputVal)
        {

            ResultView resView = new ResultView
            {
                val = GetData(inputVal)
            };

            if (resView == null)
            {
                return HttpNotFound();
            }

            ViewBag.Results = resView.val;
    
            return View(resView);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public List<string> GetData(int value)
        {
            var results = new List<string>();
            
            int num = 0;
            if (value > 0 && value < 201)
            {
                for (int i = 0; i < value; i++)
                {
                    string amend = "";
                    num = num + 1;

                   

                    results.Add(amend);
                }
            }     
            else
            {
                string validation = "Please enter integer value between 1 and 200";
                results.Add(validation);
            }

            return results;
        }


        [HttpGet]
        [Route("ExecuteLogic")]
        public List<string> ExecuteLogic(int intVal)
        {
            List<string> result;
            
                result = GetData(intVal);         



            return result;

        }
    }
}
