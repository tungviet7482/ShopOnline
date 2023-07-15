﻿using System;

namespace Shop.ViewModels.User
{
    public class RegisterRequest
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime Dob { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }
}
