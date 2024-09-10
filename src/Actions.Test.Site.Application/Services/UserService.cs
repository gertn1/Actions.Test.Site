

////using Actions.Test.Site.Application.DTOs.UserDto;
////using Actions.Test.Site.Application.Interfaces.Services;
////using Actions.Test.Site.Application.Response;
////using Actions.Test.Site.Domain.Entities;
////using Actions.Test.Site.Domain.Interfaces.Repositories;

////namespace Actions.Test.Site.Application.Services
////{
////    public class UserService : IUserService
////    {
////        private readonly IUserRepository _userRepository;

////        public UserService(IUserRepository userRepository)
////        {
////            _userRepository = userRepository;
////        }

////        public async Task<ResponseModel<List<UserEntity>>> ListAsync()
////        {
////            var response = new ResponseModel<List<UserEntity>>();
////            try
////            {
////                var users = await _userRepository.ListAllAsync();
////                response.Dados = users;
////                response.Mensagem = "Users retrieved successfully.";
////            }
////            catch (Exception ex)
////            {
////                response.Status = false;
////                response.Mensagem = $"An error occurred: {ex.Message}";
////            }
////            return response;
////        }

////        public async Task<ResponseModel<UserEntity>> GetByIdAsync(int id)
////        {
////            var response = new ResponseModel<UserEntity>();
////            try
////            {
////                var user = await _userRepository.GetByIdAsync(id);
////                if (user == null)
////                {
////                    response.Status = false;
////                    response.Mensagem = "User not found.";
////                    return response;
////                }
////                response.Dados = user;
////                response.Mensagem = "User retrieved successfully.";
////            }
////            catch (Exception ex)
////            {
////                response.Status = false;
////                response.Mensagem = $"An error occurred: {ex.Message}";
////            }
////            return response;
////        }

////        public async Task<ResponseModel<UserEntity>> CreateAsync(UserCreateDto userDto)
////        {
////            var response = new ResponseModel<UserEntity>();
////            try
////            {
////                // Criação do UserEntity
////                var user = new UserEntity
////                {

////                };

////                var createdUser = await _userRepository.CreateAsync(user);

////                response.Dados = createdUser;
////                response.Mensagem = "User created successfully.";
////            }
////            catch (Exception ex)
////            {
////                response.Status = false;
////                response.Mensagem = $"An error occurred: {ex.Message}";
////            }
////            return response;
////        }

////        public async Task<ResponseModel<UserEntity>> UpdateAsync(UserEditDto userDto)
////        {
////            var response = new ResponseModel<UserEntity>();
////            try
////            {
////                var user = await _userRepository.GetByIdAsync(userDto.Id);
////                if (user == null)
////                {
////                    response.Status = false;
////                    response.Mensagem = "User not found.";
////                    return response;
////                }

////                user.Name = userDto.Name;
////                user.Email = userDto.Email;
////                user.Phone = userDto.Phone;
////                user.BirthDate = userDto.BirthDate;
////                user.Password = userDto.Password;
////                user.Address = userDto.Address;
////                user.RoleId = userDto.RoleId;

////                var updatedUser = await _userRepository.UpdateAsync(user);
////                response.Dados = updatedUser;
////                response.Mensagem = "User updated successfully.";
////            }
////            catch (Exception ex)
////            {
////                response.Status = false;
////                response.Mensagem = $"An error occurred: {ex.Message}";
////            }
////            return response;
////        }

////        public async Task<ResponseModel<bool>> DeleteAsync(int id)
////        {
////            var response = new ResponseModel<bool>();
////            try
////            {
////                var deleted = await _userRepository.DeleteAsync(id);
////                if (!deleted)
////                {
////                    response.Status = false;
////                    response.Mensagem = "User not found.";
////                    return response;
////                }
////                response.Dados = true;
////                response.Mensagem = "User deleted successfully.";
////            }
////            catch (Exception ex)
////            {
////                response.Status = false;
////                response.Mensagem = $"An error occurred: {ex.Message}";
////            }
////            return response;
////        }
////    }
////}


//using Actions.Test.Site.Application.DTOs.UserDto;
//using Actions.Test.Site.Application.Interfaces.Services;
//using Actions.Test.Site.Application.Response;
//using Actions.Test.Site.Domain.Entities;
//using Actions.Test.Site.Domain.Interfaces.Repositories;

//namespace Actions.Test.Site.Application.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public async Task<ResponseModel<List<UserEntity>>> ListAsync()
//        {
//            var response = new ResponseModel<List<UserEntity>>();
//            try
//            {
//                var users = await _userRepository.ListAllAsync();
//                response.Dados = users;
//                response.Mensagem = "Users retrieved successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<UserEntity?>> GetByIdAsync(int id)
//        {
//            var response = new ResponseModel<UserEntity?>();
//            try
//            {
//                var user = await _userRepository.GetByIdAsync(id);
//                if (user == null)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }
//                response.Dados = user;
//                response.Mensagem = "User retrieved successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<UserEntity>> CreateAsync(UserCreateDto userDto)
//        {
//            var response = new ResponseModel<UserEntity>();
//            try
//            {
//                // Criação do UserEntity
//                var user = new UserEntity
//                {

//                };

//                var createdUser = await _userRepository.CreateAsync(user);

//                response.Dados = createdUser;
//                response.Mensagem = "User created successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<UserEntity?>> UpdateAsync(UserEditDto userDto)
//        {
//            var response = new ResponseModel<UserEntity?>();
//            try
//            {
//                var user = await _userRepository.GetByIdAsync(userDto.Id);
//                if (user == null)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }

//                user.Name = userDto.Name;
//                user.Email = userDto.Email;
//                user.Phone = userDto.Phone;
//                user.BirthDate = userDto.BirthDate;
//                user.Password = userDto.Password;
//                user.Address = userDto.Address;
//                user.RoleId = userDto.RoleId;

//                var updatedUser = await _userRepository.UpdateAsync(user);
//                response.Dados = updatedUser;
//                response.Mensagem = "User updated successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<bool>> DeleteAsync(int id)
//        {
//            var response = new ResponseModel<bool>();
//            try
//            {
//                var deleted = await _userRepository.DeleteAsync(id);
//                if (!deleted)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }
//                response.Dados = true;
//                response.Mensagem = "User deleted successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }
//    }
//}


using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services;
using Actions.Test.Site.Application.Response;
using Actions.Test.Site.Domain.Entities;
using Actions.Test.Site.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actions.Test.Site.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Listar todos os usuários
        public async Task<ResponseModel<List<UserEntity>>> ListAsync()
        {
            var response = new ResponseModel<List<UserEntity>>();
            try
            {
                var users = await _userRepository.ListAllAsync();
                response.Dados = users;
                response.Mensagem = "Users retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        // Obter usuário por Id (alterado para int)
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

        // Criar um novo usuário
        public async Task<ResponseModel<UserEntity>> CreateAsync(UserCreateDto userDto)
        {
            var response = new ResponseModel<UserEntity>();
            try
            {
                // Criar nova entidade UserEntity
                var user = new UserEntity
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Phone = userDto.Phone,
                    BirthDate = userDto.BirthDate,
                    Password = userDto.Password,
                    Address = userDto.Address,
                    RoleId = userDto.RoleId
                };

                var createdUser = await _userRepository.CreateAsync(user);

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

        // Atualizar usuário existente (alterado para int)
        public async Task<ResponseModel<UserEntity?>> UpdateAsync(UserEditDto userDto)
        {
            var response = new ResponseModel<UserEntity?>();
            try
            {
                var user = await _userRepository.GetByIdAsync(userDto.Id);
                if (user == null)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }

                // Atualizando os campos do usuário
                user.Name = userDto.Name;
                user.Email = userDto.Email;
                user.Phone = userDto.Phone;
                user.BirthDate = userDto.BirthDate;
                user.Password = userDto.Password;
                user.Address = userDto.Address;
                user.RoleId = userDto.RoleId;

                var updatedUser = await _userRepository.UpdateAsync(user);
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

        // Excluir usuário (alterado para int)
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
