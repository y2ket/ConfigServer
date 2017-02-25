﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigServer.Sample.mvc.Models;

namespace ConfigServer.Sample.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly SampleConfig config;
        private readonly IEnumerable<OptionFromConfigSet> options;

        public HomeController(SampleConfig config, IEnumerable<OptionFromConfigSet> options)
        {
            this.config = config;
            this.options = options;
        }

        public IActionResult Index()
        {
            return View(new ConfigViewModel { Config = config, Options = options});
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        
    }

    public class ConfigViewModel
    {
        public SampleConfig Config { get; set; }
        public IEnumerable<OptionFromConfigSet> Options { get; set; }

    }
}
