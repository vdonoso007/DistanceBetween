using System;
using DistanceB2U.Models;
using RestSharp;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace DistanceB2U.Services
{
  public class UserService : IUserService
  {
    public UserService(){}

    public IList<UserModel> getUserInformation()
    {
      IList<UserModel> res = new List<UserModel>();
      var client = new RestClient(Environment.GetEnvironmentVariable("BASE_ENDPOINT"));
      var request = new RestRequest("users", Method.GET);
      var response = client.Execute(request);
      var data = response.Content;
      IList<UserModel> list = SimpleJson.DeserializeObject<IList<UserModel>>(data);
      return list;
    }
  }

  public interface IUserService
  {
    public IList<UserModel> getUserInformation();
    /*public IList<UserModel> getUserInformation();*/
  }
}
