using AutoMapper;
using BookStore.Application.DTO;
using BookStore.Core.Entities;

namespace BookStore.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookRequestDto, Book>();
        CreateMap<Book, BookResponseDto>();
        // CreateMap<UserRequestDto, User>();
        // CreateMap<User, UserResponseDto>();
    }
}