﻿using System.ComponentModel.DataAnnotations;

namespace AzureTest.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
}