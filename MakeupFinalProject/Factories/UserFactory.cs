using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class UserFactory
    {

        public static User Create(int id,string username,string email,DateTime dob,string gender,string role,string password)
        {
            User user = new User();
            user.UserID = id;
            user.Username = username;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserPassword = password;
            return user;
        }

    }
}