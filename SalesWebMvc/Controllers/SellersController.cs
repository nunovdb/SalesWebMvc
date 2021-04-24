using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _selllerService;
        public SellersController(SellerService sellerService) 
        {
            _selllerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _selllerService.FindAll();
            return View(list);
        }

        //GET
        public IActionResult Create() 
        {
            return View();                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) 
        {
            _selllerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
