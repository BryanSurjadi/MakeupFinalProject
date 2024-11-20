using MakeupFinalProject.Factories;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class UserRepository
    {
        static MakeupDatabaseEntities db = DatabaseSingleton.getInstance();

        public  List<User> getAllUser()
        {
            return db.Users.ToList();
        }

        public static int lastID()
        {
            return (from x in db.Users select x.UserID).ToList().LastOrDefault();
        }

        public static int generateID()
        {
            int id=lastID();
            if (id==0)
            {
                id = 1;
            }
            else
            {
                id = id + 1;
            }
            return id;
        }

       
        public User checkUser(string username)
        {
            return (from x in db.Users where x.Username == username select x).FirstOrDefault();
        }

        public User login (string user,string pw)
        {
            return (from x in db.Users where x.Username ==  user && x.UserPassword == pw select x).FirstOrDefault();
        }
        
        public void addUser(string username,string email,DateTime dob,string gender,string password) {
            int id = generateID();
            string role = "customer";
            User user = UserFactory.Create(id, username, email, dob, gender, role, password);
            db.Users.Add(user);
            db.SaveChanges();
        

        }

        public bool userAvail(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }

        public int getIdFromUsernme(string username)
        {
            return (from x in db.Users where x.Username == username select x.UserID).FirstOrDefault();
        }

        public List<String> getGender()
        {
            return (from x in db.Users select x.UserGender).Distinct().ToList();    
        }


        public User checkUserFromID(int id)
        {
            return (from x in db.Users where x.UserID ==  id select x).FirstOrDefault();
        }
        public void update(int id,string username,string email, string gender, DateTime dob)
        {
            User x =checkUserFromID(id);
            x.Username = username;
            x.UserEmail = email;
            x.UserGender = gender;
            x.UserDOB = dob;
            db.SaveChanges();

        }

        public void changePassword(int userId, string newPassword)
        {
            var user = checkUserFromID(userId);
            if (user != null)
            {
                user.UserPassword = newPassword;
                db.SaveChanges();
            }
        }

    }
}