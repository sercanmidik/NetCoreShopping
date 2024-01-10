﻿using BusinessLayer.Abstract;
using DtoLayer.OrderDtos;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;
		public OrderController(IOrderService orderService, UserManager<AppUser> userManager)
		{
			_orderService = orderService;
			_userManager = userManager;
		}

		
    }
}
