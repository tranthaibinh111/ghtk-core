#region DotNet
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
#endregion

#region Interfaces
using GhtkCore.Interfaces.Services;
using GhtkCore.Models.Common;
#endregion

namespace GhtkCore.Services.Abstract
{
  public abstract class AbstractGhtkService : IService
  {
    #region Parameter
    protected readonly string token;

    protected readonly HttpClient _httpClient;
    #endregion

    #region Get
    public string env => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    /// <summary>
    /// https://docs.giaohangtietkiem.vn/?http#c-u-h-nh-chung
    /// </summary>
    public string domain
    {
      get
      {
        if (env == "Development")
          return "https://services-staging.ghtklab.com";
        else
          return "https://services.giaohangtietkiem.vn";
      }
    }
    #endregion

    public AbstractGhtkService(string token)
    {
      #region Token
      if (String.IsNullOrEmpty(token))
        throw new ArgumentException("GHTK token can not be null or empty");

      this.token = token;
      #endregion

      // HTTP Client
      _httpClient = new HttpClient();
    }

    ~AbstractGhtkService()
    {
      if (_httpClient != null)
        _httpClient.Dispose();
    }

    #region Protected
    /// <summary>
    /// Thiết lập Header
    /// </summary>
    protected void setHeaders()
    {
      _httpClient.DefaultRequestHeaders.Clear();
      _httpClient.DefaultRequestHeaders.Add("Token", token);
    }
    #endregion
  }
}

