﻿using SocialNGO.Common.Filters;
using System.Text.Json.Serialization;

namespace SocialNGO.Infrastructure.Db.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public required string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
