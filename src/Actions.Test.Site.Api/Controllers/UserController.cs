
using Actions.Test.Site.Application.DTOs.UserDto;
using Actions.Test.Site.Application.Interfaces.Services;
using Actions.Test.Site.Application.Dto.Responses.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Actions.Test.Site.Api.Controllers.Base;

namespace Actions.Test.Site.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Operator")]
        [ProducesResponseType(typeof(SuccessResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var response = await _userService.ListAsync();
                if (!response.Status)
                    return BadRequestResponse(response.Mensagem);

                return SuccessResponse(response.Dados);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse("An error occurred while fetching users.", ex);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Operator")]
        [ProducesResponseType(typeof(SuccessResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var response = await _userService.GetByIdAsync(id);
                if (!response.Status)
                    return NotFoundResponse(response.Mensagem);

                return SuccessResponse(response.Dados);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse($"An error occurred while fetching the user with ID {id}.", ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Operator")]
        [ProducesResponseType(typeof(SuccessResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequestResponse("Invalid model state");

            try
            {
                var response = await _userService.CreateAsync(userDto);
                if (!response.Status)
                    return BadRequestResponse(response.Mensagem);

                return CustomSuccessResponse(StatusCodes.Status201Created, response.Dados);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse("An error occurred while creating the user.", ex);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(SuccessResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserEditDto userDto)
        {
            if (id != userDto.Id)
                return BadRequestResponse("User ID mismatch");

            if (!ModelState.IsValid)
                return BadRequestResponse("Invalid model state");

            try
            {
                var response = await _userService.UpdateAsync(userDto);
                if (!response.Status)
                    return NotFoundResponse(response.Mensagem);

                return SuccessResponse(response.Dados);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse($"An error occurred while updating the user with ID {id}.", ex);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var response = await _userService.DeleteAsync(id);
                if (!response.Status)
                    return NotFoundResponse(response.Mensagem);

                return NoContent();
            }
            catch (Exception ex)
            {   
                return InternalServerErrorResponse($"An error occurred while deleting the user with ID {id}.", ex);
            }
        }
    }
}
