#region DotNet
using System;
#endregion

namespace GhtkCore.Interfaces.Services
{
  public interface IService
  {
    string env { get; }
    string domain { get; }
  }
}

