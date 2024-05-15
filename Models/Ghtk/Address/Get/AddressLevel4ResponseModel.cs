#region DotNet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Package (third-party)
using Newtonsoft.Json;
#endregion

#region Common
// Interfaces
using GhtkCore.Interfaces.Models.Common;

// Models
using GhtkCore.Models.Common;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class AddressLevel4ResponseModel : ResponseModel, ISuccessResponse<IList<string>>, IErrorResponse
  {
    public IList<string> data { get; set; }
  }
}
