#region DotNet
using System.Dynamic;
#endregion

namespace GhtkCore.Interfaces.Models.Common
{
  public interface ICreationModel
  {
    ExpandoObject generateGhtk();
  }
}

