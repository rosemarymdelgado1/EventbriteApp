﻿using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.ViewComponents
{
    public class CartList:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public CartList(ICartService cartSvc) => _cartSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {


            var vm = new Models.CartModels.Cart();
            try
            {
                vm = await _cartSvc.GetCart(user);

                
                return View(vm);
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit mode
                ViewBag.IsBasketInoperative = true;
                TempData["BasketInoperativeMsg"] = "Basket Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
            }

            return View(vm);
        }




    }
}
