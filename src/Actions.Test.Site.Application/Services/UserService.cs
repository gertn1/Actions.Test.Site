


using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services;
using Actions.Test.Site.Application.Response;
using Actions.Test.Site.Domain.Entities;
using Actions.Test.Site.Domain.Interfaces.Repositories;
using FluentValidation;  // Importação do FluentValidation
using BCrypt.Net;

namespace Actions.Test.Site.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserCreateDto> _userCreateValidator;  // Injeção do validador
        private readonly IValidator<UserEditDto> _userEditValidator;  // Injeção do validador

        public UserService(IUserRepository userRepository,
                           IValidator<UserCreateDto> userCreateValidator,
                           IValidator<UserEditDto> userEditValidator)
        {
            _userRepository = userRepository;
            _userCreateValidator = userCreateValidator;  // Inicialização do validador
            _userEditValidator = userEditValidator;  // Inicialização do validador
        }

        public async Task<ResponseModel<List<UserEntity>>> ListAsync()
        {
            var response = new ResponseModel<List<UserEntity>>();
            try
            {
                var users = await _userRepository.ListAllAsync();
                response.Dados = users;
                response.Status = true;
                response.Mensagem = "Users retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<UserEntity?>> GetByIdAsync(int id)
        {
            var response = new ResponseModel<UserEntity?>();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }
                response.Status = true;
                response.Dados = user;
                response.Mensagem = "User retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<UserEntity>> CreateAsync(UserCreateDto userDto)
        {
            var response = new ResponseModel<UserEntity>();

            // Validação do DTO
            var validationResult = await _userCreateValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                response.Status = false;
                response.Mensagem = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return response;
            }

            try
            {
                
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

                var user = new UserEntity
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    BirthDate = userDto.BirthDate,
                    Password = hashedPassword, 
                    Address = userDto.Address,
                    RoleId = userDto.RoleId
                };

                var createdUser = await _userRepository.CreateAsync(user);
                response.Status = true;
                response.Dados = createdUser;
                response.Mensagem = "User created successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }


        public async Task<ResponseModel<UserEntity?>> UpdateAsync(UserEditDto userDto)
        {
            var response = new ResponseModel<UserEntity?>();

            
            var validationResult = await _userEditValidator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                response.Status = false;
                response.Mensagem = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return response;
            }

            try
            {
                var user = await _userRepository.GetByIdAsync(userDto.Id);
                if (user == null)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }

                user.Name = userDto.Name;
                user.Email = userDto.Email;
                user.Phone = userDto.Phone;
                user.BirthDate = userDto.BirthDate;
                if (!string.IsNullOrWhiteSpace(userDto.Password))
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
                }

                user.Address = userDto.Address;
                user.RoleId = userDto.RoleId;

                var updatedUser = await _userRepository.UpdateAsync(user);
                response.Status = true;
                response.Dados = updatedUser;
                response.Mensagem = "User updated successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var deleted = await _userRepository.DeleteAsync(id);
                if (!deleted)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }
                response.Status = true;
                response.Dados = true;
                response.Mensagem = "User deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }
    }
}
