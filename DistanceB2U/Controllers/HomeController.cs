using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DistanceB2U.Services;
using DistanceB2U.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistanceB2U.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class HomeController : Controller
  {

    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public IEnumerable<UserModel> Index()
    {
      return _userService.getUserInformation();
    }
  }
}
