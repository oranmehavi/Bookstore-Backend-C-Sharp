using AutoMapper;
using Bookstore_Backend_C_.Models;

namespace Bookstore_Backend_C_.Data
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<NewBookModel, BookModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
