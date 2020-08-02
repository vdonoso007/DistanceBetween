using System;
using DistanceB2U.Models;
using RestSharp;
using Microsoft.AspNetCore.Hosting;

namespace DistanceB2U.Services
{
  public class UserService : IUserService
  {
    public UserService()
    {

    }

    public void getUserInformation2()
    {
      var client = new RestClient(Environment.GetEnvironmentVariable("BASE_ENDPOINT"));
      var request = new RestRequest("users", Method.GET);
      var response = client.Execute(request);


      
    }

    public UserModel getUserInformation()
    {
      var client = new RestClient(Environment.GetEnvironmentVariable("BASE_ENDPOINT"));
      var request = new RestRequest("users", Method.GET);
      var response = client.Execute(request);


      throw new NotImplementedException();
    }
  }

  public interface IUserService
  {
    public UserModel getUserInformation();
    public void getUserInformation2();
  }
}
