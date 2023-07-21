#region Package (third-party)
using AutoMapper;
#endregion

namespace GhtkCore.Models.Ghtk
{
  public class PostOfficeModel
  {
    public string warehouseCode { get; set; }
    public string contactName { get; set; }
    public string address { get; set; }
    public string province { get; set; }
    public string district { get; set; }
    public string ward { get; set; }
    public string street { get; set; }

    #region Map
    public static PostOfficeModel map(PersonalFilterModel source)
    {
      #region Config
      var config = new MapperConfiguration(cfg =>
        cfg.CreateMap<PersonalFilterModel, PersonalModel>()
      );
      var mapper = new Mapper(config);
      #endregion

      return mapper.Map<PersonalFilterModel, PostOfficeModel>(source);
    }
    #endregion
  }
}

