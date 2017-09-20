//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWithAngular2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Login
    {
        public int? UserID { get; set; }
        [Required(ErrorMessage ="Username Required", AllowEmptyStrings =false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Required", AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(ErrorMessage = "FullName Required", AllowEmptyStrings = false)]
        public string FullName { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" , ErrorMessage= "Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender Required", AllowEmptyStrings = false)]
        public string Gender { get; set; }
    }
}