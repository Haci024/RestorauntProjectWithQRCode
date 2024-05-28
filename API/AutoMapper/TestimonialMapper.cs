using AutoMapper;
using DTO.DTOS.TestimonialDTO;
using Entities.Concrete;

namespace API.AutoMapper
{
    public class TestimonialMapper:Profile
    {
        public TestimonialMapper()
        {
            CreateMap<Testimonial,AddTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();

        }
    }
}
