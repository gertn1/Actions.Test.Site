﻿using Actions.Test.Site.Domain.Enums;

namespace Actions.Test.Site.Application.DTOs.UserDto
{
    public class UserCreationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleType RoleId { get; set; }
    }
}
