using AutoMapper;
using BookStore.Api.Application.DTO;
using BookStore.Api.Domain.Entities;

namespace BookStore.Api.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookRequestDto, Book>();
        CreateMap<Book, BookResponseDto>();
    }
}