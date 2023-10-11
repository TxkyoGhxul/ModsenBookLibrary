using AutoMapper;
using ModsenBookLibrary.Domain.Models;
using ModsenBookLibrary.Presentation.Dtos;

namespace ModsenBookLibrary.Presentation.Mappers;
internal class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Book, BookListDto>();
        CreateMap<BookDistribution, BookDistributionDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<Role, RoleDto>();
        CreateMap<User, UserDto>();
    }
}
