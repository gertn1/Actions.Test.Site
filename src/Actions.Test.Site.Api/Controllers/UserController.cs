
using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services;
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

        
        [HttpGet]
        [Authorize(Roles = "Admin,Operador")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.ListAsync();
            if (!response.Status)
                return BadRequest(response.Mensagem);

            return Ok(response.Dados);
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Operador")]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = await _userService.GetByIdAsync(id);
            if (!response.Status)
                return NotFound(response.Mensagem);

            return Ok(response.Dados);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Operador")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.CreateAsync(userDto);
            if (!response.Status)
                return BadRequest(response.Mensagem);

            return CreatedAtAction(nameof(GetUser), new { id = response.Dados.Id }, response.Dados);
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserEditDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest("User ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _userService.UpdateAsync(userDto);
            if (!response.Status)
                return NotFound(response.Mensagem);

            return Ok(response.Dados);
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteAsync(id);
            if (!response.Status)
                return NotFound(response.Mensagem);

            return NoContent();
        }
    }
}
