#region DotNet
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace GhtkCore.Utils
{
  public class QueryHelpers
  {
    public static string stringify(Dictionary<string, dynamic> query)
    {
      try
      {
        var parameters = new List<string>();

        foreach (var item in query)
        {
          var parameter = $"{item.Key}=";

          if (item.Value is string)
            parameter += item.Value;
          else if (item.Value is int)
            parameter += item.Value.ToString();
          else
            continue;

          parameters.Add(parameter);
        }

        return String.Join('&', parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);

        throw;
      }
    }
  }
}

