﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Example.Api.Commands
{
    public class AuthorForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }

        public DateTime Birthdate { get; set; }
    }
}