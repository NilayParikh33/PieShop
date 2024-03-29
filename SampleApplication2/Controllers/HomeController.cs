﻿using Microsoft.AspNetCore.Mvc;
using SampleApplication2.Interface;
using SampleApplication2.ViewModels;

namespace SampleApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        //This method will give Pies which are BestOfTheWeek in the Application's Home Page.
        public IActionResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
