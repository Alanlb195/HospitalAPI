using AutoMapper;
using hospital.Models.DTOS;
using hospital.Models.HospitalDB;

namespace hospital.Tools
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<TblMedico, MedicoRequest>();
        }


    }
}
