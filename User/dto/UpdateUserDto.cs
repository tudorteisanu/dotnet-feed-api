﻿using System;
using System.ComponentModel.DataAnnotations;

namespace feedApi.Users.dto
{
	public class UpdateUserDto
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

