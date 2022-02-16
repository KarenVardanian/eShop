using System;
using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class UserController : ControllerBase
{
	public UserController()
	{
	}

    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public UserController(
        ILogger<UserController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }
}
