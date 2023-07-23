using AutoMapper;
using hospital.Models.HospitalDB;
using hospital.Models.HospitalDB.DTOS;

namespace hospital.Tools
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<TblMedico, MedicoView>();
        }


    }
}
