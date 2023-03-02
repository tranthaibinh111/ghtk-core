#region Package (third-party)
using AutoMapper;
#endregion

#region GHTK
// Paramters
using GhtkCore.Models.Ghtk;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class PersonalModel
  {
    public string warehouseCode { get; set; }
    public string contactName { get; set; }
    public string address { get; set; }
    public string province { get; set; }
    public string district { get; set; }
    public string ward { get; set; }
    public string street { get; set; }
    public string tel { get; set; }
    public string email { get; set; }

    #region Map
    public static PersonalModel map(PersonalFilterModel source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<PersonalFilterModel, PersonalModel>()
      );
      var mapper = new Mapper(config);
      #endregion

      return mapper.Map<PersonalFilterModel, PersonalModel>(source);
    }
    #endregion
  }
}

