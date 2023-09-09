﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Common.Dtos
{
	public class LoginModel
	{
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

