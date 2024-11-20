using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class UserHandler
    {
        UserRepository repo = new UserRepository();

        public  List<User> GetAllUsers()
        {
            return repo.getAllUser();
        }

        public User GetUserByUsername(string username)
        {
            return repo.checkUser(username);
        }

        public User Login(string username,string pw) 
        { 
            return repo.login(username, pw);

        }

        public bool checkName (string name)
        {
            return repo.userAvail(name);    
        } 

        public void register (string username, string email, DateTime dob, string gender, string password)
        {
            repo.addUser(username,email, dob, gender, password);    
        }

        public List<String> getGender()
        {
            return repo.getGender();
        }

        public void update (int id, string username, string email, string gender, DateTime dob)
        {
            repo.update(id,username,email,gender,dob); 
        }

        public void changePassword(int userId, string newPassword)
        {
            repo.changePassword(userId,newPassword);
        }

        public User getUserFromID (int id)
        {
            return repo.checkUserFromID(id);
        }

        public int getIdFromUsername(string x)
        {
            return repo.getIdFromUsernme(x);
        }
    }
}