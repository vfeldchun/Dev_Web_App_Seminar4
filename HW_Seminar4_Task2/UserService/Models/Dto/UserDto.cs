﻿namespace UserService.Models.Dto
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
    }
}
