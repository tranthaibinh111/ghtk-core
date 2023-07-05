#region DotNet
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace GhtkCore.Utils
{
  public class QueryHelpers
  {
    public static string stringify(Dictionary<string, dynamic> query)
    {
      try
      {
        // Trường hợp query rỗng
        if (query.Count == 0) return String.Empty;

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

        // Trường hợp parameters rỗng
        if (parameters.Any()) return String.Empty;

        return String.Join('&', parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);

        throw;
      }
    }
  }
}

