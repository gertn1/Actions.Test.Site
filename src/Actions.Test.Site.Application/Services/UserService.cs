
using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services;
using Actions.Test.Site.Application.Response;
using Actions.Test.Site.Domain.Entities;
using Actions.Test.Site.Domain.Interfaces.Repositories;
using FluentValidation;
using YourNamespace.Application.Map;

namespace Actions.Test.Site.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserCreateDto> _userCreateValidator;
        private readonly IValidator<UserEditDto> _userEditValidator;

        public UserService(IUserRepository userRepository,
                           IValidator<UserCreateDto> userCreateValidator,
                           IValidator<UserEditDto> userEditValidator)
        {
            _userRepository = userRepository;
            _userCreateValidator = userCreateValidator;
            _userEditValidator = userEditValidator;
        }

        public async Task<ResponseModel<List<UserEntity>>> ListAsync()
        {
            try
            {
                var users = await _userRepository.ListAllAsync();
                return ResponseModel<List<UserEntity>>.Success(users, "Users retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ResponseModel<List<UserEntity>>.Error($"An error occurred: {ex.Message}");
            }
        }

        public async Task<ResponseModel<UserEntity?>> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                    return ResponseModel<UserEntity?>.Error("User not found.");

                return ResponseModel<UserEntity?>.Success(user, "User retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ResponseModel<UserEntity?>.Error($"An error occurred: {ex.Message}");
            }
        }

        public async Task<ResponseModel<UserEntity>> CreateAsync(UserCreateDto userDto)
        {
            var validationResult = await _userCreateValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                return ResponseModel<UserEntity>.Error(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            try
            {
                var user = userDto.MapToEntity();
                var createdUser = await _userRepository.CreateAsync(user);
                return ResponseModel<UserEntity>.Success(createdUser, "User created successfully.");
            }
            catch (Exception ex)
            {
                return ResponseModel<UserEntity>.Error($"An error occurred: {ex.Message}");
            }
        }

        public async Task<ResponseModel<UserEntity?>> UpdateAsync(UserEditDto userDto)
        {
            var validationResult = await _userEditValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                return ResponseModel<UserEntity?>.Error(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            try
            {
                var user = await _userRepository.GetByIdAsync(userDto.Id);
                if (user == null)
                {
                    return ResponseModel<UserEntity?>.Error("User not found.");
                }

                userDto.MapUpdateEntity(user);
                var updatedUser = await _userRepository.UpdateAsync(user);
                return ResponseModel<UserEntity?>.Success(updatedUser, "User updated successfully.");
            }
            catch (Exception ex)
            {
                return ResponseModel<UserEntity?>.Error($"An error occurred: {ex.Message}");
            }
        }

        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            try
            {
                var deleted = await _userRepository.DeleteAsync(id);
                if (!deleted)
                {
                    return ResponseModel<bool>.Error("User not found.");
                }
                return ResponseModel<bool>.Success(true, $"User Id {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return ResponseModel<bool>.Error($"An error occurred: {ex.Message}");
            }
        }
    }
}
