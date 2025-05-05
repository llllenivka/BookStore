using AutoMapper;
using BookStore.Application.DTO;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure;

namespace BookStore.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public UserService(IMapper mapper, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<IEnumerable<UserResponseDto>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }
    
    public async Task<UserResponseDto> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email); 
        var userResponseDto = _mapper.Map<UserResponseDto>(user);
        
        return userResponseDto;
    }
    
    public async Task<bool> Register(UserRequestDto newUser)
    {
        var hashed = _passwordHasher.GenerateHash(newUser.Password);
        // newUser.Password = hashed;
        var user = new User
        {
            Email = newUser.Email,
            PasswordHash = hashed,
            Role = newUser.Role,
            Username = newUser.Username,
            Id = Guid.NewGuid()
        };
        
        return await _userRepository.Register(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if(user == null) return null;
        
        var result = _passwordHasher.VerifyHash(password, _passwordHasher.GenerateHash(password));
        if(result == false) return null;
 
        return _jwtTokenGenerator.GenerateToken(user);
    }
}