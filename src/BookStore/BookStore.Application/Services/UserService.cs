using AutoMapper;
using BookStore.Infrastructure.Data;

namespace BookStore.Application.Services;

public class UserService
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, BookStoreDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    

    // public async Task<UserResponseDto> GetUserByEmailAsync(string email)
    // {
    //     var user = await _context.Users.FirstOrDefault(u => u.Email == email); 
    //     var userResponseDto = _mapper.Map<UserResponseDto>(user);
    //     
    //     return Task.FromResult(userResponseDto);
    // }
}