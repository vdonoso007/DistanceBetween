using System;
using System.Collections.Generic;

namespace DistanceB2U.Models
{
  public class UserModel
  {
    public UserModel()
    { }
    public string user { get; set; }
    public IEnumerable<string> following { get; set; }
  }
}
