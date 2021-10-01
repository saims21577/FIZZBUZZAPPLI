using FizzBuzzApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string numbers)
        {
            List<ModelData> res = new List<ModelData>();
            string[] splitedNumbers = numbers.Split(',')
                                             .Select(x => x.Trim())
                                             .Where(x => !string.IsNullOrWhiteSpace(x))
                                             .ToArray();


            foreach (string num in splitedNumbers)
            {
                int numberToCheck = Convert.ToInt32(num);

                if (numberToCheck % 3 == 0 && numberToCheck % 5 == 0)
                {
                    res.Add(new ModelData() { Number = numberToCheck, Result = "FizzBuzz" });
                    continue;
                }
                else if (numberToCheck % 3 == 0)
                {
                    res.Add(new ModelData() { Number = numberToCheck, Result = "Fizz" });
                    continue;
                }
                else if (numberToCheck % 5 == 0)
                {
                    res.Add(new ModelData() { Number = numberToCheck, Result = "Buzz" });
                    continue;
                }
                else
                {
                    res.Add(new ModelData() { Number = numberToCheck, Result = "Divided " + numberToCheck + " by 3, Divided " + numberToCheck + " by 5." });
                    continue;
                }
            }

            return View("List", res);
        }


    }
}
