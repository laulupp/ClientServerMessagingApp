using AuthService.Api.Models;
using AuthService.Persistence.Models;
using AuthService.Persistence.Repositories.Interfaces;
using AuthService.Services.Interfaces;
using AutoMapper;
using static AuthService.Exceptions.CustomExceptions;

namespace AuthService.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncryptionService _passwordEncryptionService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public UserService(
        IUserRepository userRepository,
        IPasswordEncryptionService passwordEncryptionService,
        ITokenService tokenService,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordEncryptionService = passwordEncryptionService;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
    {
        var user = await _userRepository.GetByUsernameAsync(loginDTO.Username);

        if (user == null)
            throw new UserNotFoundException("User not found.");

        if (!_passwordEncryptionService.VerifyPassword(loginDTO.Password, user.HashedPassword))
            throw new InvalidPasswordException("Invalid password.");

        var response = _mapper.Map<LoginResponseDTO>(user);
        response.Token = _tokenService.GenerateEncryptedToken(user);

        return response;
    }

    public async Task<LoginResponseDTO> RegisterAsync(UserDTO userDTO)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(userDTO.Username);
        if (existingUser != null)
            throw new UserAlreadyExistsException("User already exists.");

        var user = _mapper.Map<User>(userDTO);
        user.HashedPassword = _passwordEncryptionService.EncryptPassword(userDTO.Password);

        await _userRepository.AddAsync(user);

        var response = _mapper.Map<LoginResponseDTO>(user);
        response.Token = _tokenService.GenerateEncryptedToken(user);

        return response;
    }
}
