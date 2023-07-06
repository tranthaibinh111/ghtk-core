#region DotNet
using System.Collections.Generic;
#endregion

#region Common
using GhtkCore.Interfaces.Models.Common;
#endregion

namespace GhtkCore.Interfaces.Models.Ghtk
{
  public interface IDeliveryCreationModel : ICreationModel
  {
    IOrderCreationModel order { get; set; }
    IList<IProductCreationModel> products { get; set; }
  }
}

