﻿namespace Actions.Test.Site.Application.DTOs.UserDto
{
    public class UserEditDto
    {

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
