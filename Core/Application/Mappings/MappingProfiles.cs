using AutoMapper;

namespace Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<CreateCarCommandRequest, Car>();

            //CreateMap<Car, CarQueryDto>().
            //    ForMember(c => c.BodyType,
            //    m => m.MapFrom(
            //        c => c.BodyTypeId.ToString() != null ? c.BodyType.Name
            //    : "")).
            //    ForMember(c => c.Transmission, m => m.MapFrom(
            //        c => c.TransmissionId.ToString() != null ? c.Transmission.Type : "")).
            //        ForMember(c => c.Brand, m => m.MapFrom(
            //            c => c.BrandId.ToString() != null ? c.Brand.Name :
            //            ""));
        }
    }
}
