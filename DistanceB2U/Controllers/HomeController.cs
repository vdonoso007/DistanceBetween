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
  public class HomeController : Controller
  {

    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    [Route("[controller]/users")]
    public IEnumerable<UserModel> Index()
    {
      return _userService.getUsers();
    }

    [HttpGet]
    [Route("[controller]/user/{Id}")]
    public UserModel getUser(string Id)
    {
      return _userService.getUserInformation(Id);
    }

    [HttpGet]
    [Route("[controller]/users/distance/between/{userFrom}/{userTo}")]
    public int getDistanceBetween(string userFrom, string userTo)
    {
      return  _userService.getDistanceBetweenFromTo(userFrom, userTo);
    }


  }
}
