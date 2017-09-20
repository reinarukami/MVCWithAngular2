using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MVCWithAngular2.Models
{
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}