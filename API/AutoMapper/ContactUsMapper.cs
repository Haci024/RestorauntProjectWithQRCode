using AutoMapper;
using DTO.DTOS.ContactUsDTO;
using DTO.DTOS.ReservationDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class ContactUsMapper:Profile
    {
        public ContactUsMapper()
        {
            CreateMap<ContactUs, UpdateContactUsDTO>().ReverseMap();
            CreateMap<ContactUs, UpdateContactUsDTO>().ReverseMap();
            CreateMap<ContactUs, GetContactUsDTO>().ReverseMap();
            CreateMap<ContactUs, AddContactUsDTO>().ReverseMap();
        }
    }
}
