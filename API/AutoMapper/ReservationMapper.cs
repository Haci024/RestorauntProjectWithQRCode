using AutoMapper;
using Entities.Concrete;
using DTO.DTOS;
using DTO.DTOS.ReservationDTO;

namespace API.AutoMapper
{
    public class ReservationMapper:Profile
    {
        public ReservationMapper() {
        
            CreateMap<Reservation,ResultReservationDTO>().ReverseMap();
            CreateMap<Reservation,UpdateReservationDTO>().ReverseMap();
            CreateMap<Reservation, GetReservationDTO>().ReverseMap();
            CreateMap<Reservation, AddReservationDTO>().ReverseMap();
        }
    }
}
