using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    public class UserController
    {
        UserHandler handler = new UserHandler();


        public  List<User> getAllUser()
        {
            return handler.GetAllUsers();
        }

        //validasi delete update

        public User GetUser(string name)
        {
            return handler.GetUserByUsername(name);
        }

        public String checkLoginUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Please fill in the username";
            }
            return null;
        }

        public String checkLoginPassword(string pw)
        {
            if (string.IsNullOrEmpty(pw))
            {
                return "Please fill password";
            }
            return null;
        }

        public string login(string username, string password)
        {
           string error = null;
            if(error == null)
            {
                error = checkLoginUsername(username);
            }
            if(error == null)
            {
                error = checkLoginPassword(password);
            }
            if(error == null)
            { 
               var x =  handler.Login(username, password);
                if (x == null)
                {
                    return "Wrong Credentials";
                }
            }

            return error;

        }

        public string checkUsername (string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Please fill username";
            }
            if(username.Length <= 5 || username.Length >= 15)
            {
                return "Username must be 5-15 characters";
            }
            if (handler.checkName(username))
            {
                return "Username already taken";
            }
            return null;
        }

        public string checkEmail (string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return "Please enter email";
            }
            if(!email.EndsWith(".com", StringComparison.OrdinalIgnoreCase))
            {
                return "Email must end with .com";
            }
            return null;
        }

        public string checkGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
            {
                return "Enter gender plesaseaseae , Enlgish or spanish";
            }
            return null;
        }

        public string checkPassword(string password,string confirmPas)
        {
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPas))
            {
                return "Please fill in the passwords";
            }
            if(password != confirmPas)
            {
                return "Re enter the same password for confirm password";
            }
            return null;
        }

        public string checkdate (DateTime x)
        {
            if(x == DateTime.Today)
            {
                return "Enter a valid date";
            }
            return null;
        }

        public string register (string username, string email, DateTime dob, string gender, string password,string confirm)
        {
            string error = null;
            if(error == null)
            {
                error = checkUsername(username);
            }
            if(error == null)
            {
                error = checkEmail(email);
            }
            if(error == null)
            {
                error = checkdate(dob);
            }
            if(error == null)
            {
                error = checkGender(gender);
            }
            if(error == null)
            {
                error = checkPassword(password, confirm);
            }
            if(error == null)
            {
                handler.register(username, email, dob,gender, password);
            }
            return error;

        }

        public List<String> getGender()
        {
            return handler.getGender();
        }

        public string update (int id, string username, string email, string gender, DateTime dob)
        {
            string error = null;
            if(error == null)
            {
                error = checkUsername(username);
            }
            if (error == null)
            {
                error = checkEmail(email);
            }
            if(error == null)
            {
                error = checkGender(gender);
            }
            if(error == null)
            {
                error = checkdate(dob);
            }
            if(error == null)
            {
                handler.update(id, username, email, gender,dob);
            }
            return error;
        }

        public string checkChangePassword(string old,string newpw)
        {
            if(string.IsNullOrEmpty(old) || string.IsNullOrEmpty(newpw))
            {
                return "Password fields cannot be empty";
            }
            return null;
        }
        public string changePass(int id ,string old, string pw)
        {
            string error = null;
            if(error == null)
            {
                error = checkChangePassword(old,pw);
            }
            if(error == null)
            {
                handler.changePassword(id, pw);
            }
            return null;
        }

        public User getUserFromID(int id)
        {
            return handler.getUserFromID(id);
        }

        public int getIdFromUsername(string name)
        {
            return handler.getIdFromUsername(name);
        }
    }
}