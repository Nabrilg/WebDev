﻿using System.ComponentModel.DataAnnotations;

namespace WebDev.Api.Model
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Username { get; set; }
  }
}