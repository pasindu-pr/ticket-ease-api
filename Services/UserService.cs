﻿using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketEase.Contracts;
using TicketEase.Dtos.Users;
using TicketEase.Entities;
using TicketEase.Responses;
using BCr = BCrypt.Net;

namespace TicketEase.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IRepository<User> _repository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, IRepository<User> repository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _repository = repository;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<ApiResponse> AddUserToAdminRole(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> AddUserToSellerRole(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> CreateTravellerAccount(CreateTravellerDto userDto)
        {
            ApiResponse apiResponse = new();
            try
            {
                User user = _mapper.Map<User>(userDto);
                var filterDefinition = new FilterDefinitionBuilder<User>();
                var filter = filterDefinition.Eq(u => u.NicNumber, user.NicNumber);
                IReadOnlyCollection<User> filteredUsers = await _repository.FilterAsync(filter);

                if (filteredUsers.Count == 0)
                {
                    string passwordHash = BCr.BCrypt.HashPassword(userDto.Password);
                    user.Password = passwordHash;
                    await _repository.CreateAsync(user);
                    apiResponse.Success = true;
                    apiResponse.Message = "Account Created Successfully!";
                    Log.Information($"Traveller account created. UserName: {user.FirstName}");
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "User has already registered!";
                    Log.Error($"Traveller account creation failed. Duplicated NIC! UserName: {user.FirstName}");
                }
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateUserAccount(CreateUserDto userDto)
        {
            ApiResponse apiResponse = new();
            try
            {
                User user = _mapper.Map<User>(userDto);
                var filterDefinition = new FilterDefinitionBuilder<User>();
                var filter = filterDefinition.Eq(u => u.Email, userDto.Email);
                IReadOnlyCollection<User> filteredUsers = await _repository.FilterAsync(filter);

                if (filteredUsers.Count == 0)
                {
                    string passwordHash = BCr.BCrypt.HashPassword(userDto.Password);
                    user.Password = passwordHash;
                    user.IsActivated = true;
                    await _repository.CreateAsync(user);
                    apiResponse.Success = true;
                    apiResponse.Message = "Account Created Successfully!";
                    Log.Information($"User account created. UserName: {user.FirstName}");
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "User has already registered!";
                    Log.Error($"Traveller account creation failed. Duplicated Email! UserName: {user.FirstName}");
                }
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> LoginAsync(LoginUserDto userLoginDto)
        {
            try
            {
                ApiResponse response = new();
                FilterDefinitionBuilder<User> Fdb = new FilterDefinitionBuilder<User>();
                FilterDefinition<User> filterDefinition = Fdb.Eq(u => u.Email, userLoginDto.Email);
                IReadOnlyCollection<User> users = await _repository.FilterAsync(filterDefinition);

                if (users.Count > 0)
                {
                    User user = users.FirstOrDefault()!;
                    var isVerified = BCr.BCrypt.Verify(userLoginDto.Password, user.Password);

                    if (isVerified)
                    {

                        if (!user.IsActivated)
                        {
                            response.Success = false;
                            response.Message = "Your account is not activated!";
                        }
                        else
                        {
                            var token = CreateToken(user);
                            response.Data = token;
                            response.Success = true;
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Email or Password is invalid";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Email or Password is invalid";
                }

                return response;

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Task<ApiResponse> SeedRolesAndUsers()
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(type: "UserId", user.Id!),
                new Claim(type: "Role", user.UserType.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Auth:SecurityKey").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ApiResponse> DeactivateAccout()
        {
            var userId = _httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;

            User user = await _repository.GetByIdAsync(userId);

            if (user != null)
            {
                user.IsActivated = false;
                await _repository.UpdateAsync(userId, user);
                return new ApiResponse { Success = true, Message = "Account deactivated successfully!" };
            }
            else
            {
                return new ApiResponse { Success = false, Message = "Account deactivation failed!" };
            }

        }

        public async Task<ApiResponse> ActivateAccount(ActivateUserAccountDto userToActivate)
        {
            var userId = userToActivate.UserId;
            User user = await _repository.GetByIdAsync(userId);

            if (user.IsActivated)
            {
                return new ApiResponse { Success = false, Message = "Account already activated!" };
            }

            if (user != null)
            {
                user.IsActivated = true;
                await _repository.UpdateAsync(userId, user);
                return new ApiResponse { Success = true, Message = "Account activated successfully!" };
            }
            else
            {
                return new ApiResponse { Success = false, Message = "Account activation failed!" };
            }

        }

        public async Task<ApiResponse> GetAllTravellers()
        {
            try
            {
                ApiResponse response = new();
                FilterDefinitionBuilder<User> Fdb = new FilterDefinitionBuilder<User>();
                FilterDefinition<User> filterDefinition = Fdb.Eq(u => u.UserType, UserTypes.Traveller);
                IReadOnlyCollection<User> users = await _repository.FilterAsync(filterDefinition);
                response.Data = _mapper.Map<IReadOnlyCollection<GetTravellersDto>>(users);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
