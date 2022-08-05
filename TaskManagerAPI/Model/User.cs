using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string LoginStat { get; set; }  = "N";
        public DateTime? LastLogin { get; set; }
    }
}

