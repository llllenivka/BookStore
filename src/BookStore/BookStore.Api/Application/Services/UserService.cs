using AutoMapper;
using BookStore.Api.Infrastructure.Data;

namespace BookStore.Api.Application.Services;

public class UserService
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, BookStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    

    public Task<UserResponseDto> GetUserByEmailAsync(string email)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(user);
        
        return Task.FromResult(userResponseDto);
    }
}