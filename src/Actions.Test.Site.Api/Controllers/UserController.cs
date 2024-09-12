
using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services;
using Actions.Test.Site.Application.Response;
using Actions.Test.Site.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Actions.Test.Site.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase 
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("ListarUsuarios")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<ActionResult<ResponseModel<List<UserEntity>>>> GetUsers()
        {
            var response = await _userService.ListAsync();
            return Ok(response);
        }

        [HttpGet("BuscarUsuarioPorId/{id}")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<ActionResult<ResponseModel<UserEntity>>> GetUser(int id)
        {
            var response = await _userService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost("CriarUsuario")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<ActionResult<ResponseModel<UserEntity>>> CreateUser([FromBody] UserCreateDto userDto)
        {
            var response = await _userService.CreateAsync(userDto);
            return Ok(response);
        }

        [HttpPut("EditarUsuario/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<UserEntity>>> UpdateUser(int id, [FromBody] UserEditDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest(new ResponseModel<UserEntity>
                {
                    Status = false,
                    Mensagem = "User ID mismatch"
                });
            }

            var response = await _userService.UpdateAsync(userDto);
            return Ok(response);
        }

        [HttpDelete("ExcluirUsuario/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<UserEntity>>> DeleteUser(int id)
        {
            var response = await _userService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
