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

    public IList<UserModel> getUsers()
    {
      IList<UserModel> res = new List<UserModel>();
      var client = new RestClient(Environment.GetEnvironmentVariable("BASE_ENDPOINT"));
      var request = new RestRequest("users", Method.GET);
      var response = client.Execute(request);
      var data = response.Content;
      IList<UserModel> list = SimpleJson.DeserializeObject<IList<UserModel>>(data);
      return list;
    }

    public UserModel getUserInformation(string user)
    {
      var client = new RestClient(Environment.GetEnvironmentVariable("BASE_ENDPOINT"));
      var request = new RestRequest("users", Method.GET);
      request.AddParameter("id", user);
      var response = client.Execute(request);
      var data = response.Content;

      IList<UserModel> list = SimpleJson.DeserializeObject<IList<UserModel>>(data);
      if (list.Count > 0)
      {
        UserModel aUser = list[0];
        return aUser;
      }
      else
        return new UserModel() { id = "0", following=null };


    }

    public int getDistanceBetweenFromTo(string from , string to)
    {
      Boolean findTo = true;
      int step = 0;
      while(findTo)
      {
        UserModel userFrom = this.getUserInformation(from);
        if (userFrom.following==null)
          return 0;

        step += keepSearching(to, userFrom.following);
        if (step == 1)
        {
          findTo = false;
        }
        else
        {


          foreach (string item in userFrom.following)
          {
            userFrom = this.getUserInformation(item);
            if (userFrom.following == null)
              return 0;
            step += keepSearching(to, userFrom.following);
            
            if (step == 1)
            {
              findTo = false;
              break;
            }
          }
          

        }

      }
      return step;
    }

    public int keepSearching(string user, IEnumerable<string> followings)
    {
      int result = 0;
      foreach (string item in followings)
      {
        if (item.Equals(user))
        {
          result = 1;
        }
      }
      return result;
    }
  }

  public interface IUserService
  {
    public IList<UserModel> getUsers();
    public UserModel getUserInformation(string user);
    public int getDistanceBetweenFromTo(string from, string to);
    
  }
}
