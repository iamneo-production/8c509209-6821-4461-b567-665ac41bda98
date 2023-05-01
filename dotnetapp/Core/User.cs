using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Linq;

namespace dotnetapp.Core
{
    public class User:IUser
    {
        private readonly PrinterServiceContext _context;
        public User(PrinterServiceContext _context)
        {
            this._context = _context;
        }

        public string addUser(UserModel data)
        {
            try
            {
                if (data != null)
                {


                    _context.userModels.Add(data);
                    // _context.SaveChanges();
                    var role = data.UserRole.ToLower();
                    if (role == "admin")
                    {
                        AdminModel admin = new AdminModel();
                        admin.Email = data.Email;
                        admin.Password = data.Password;
                        admin.MobileNumber = data.MobileNumber;
                        admin.UserRole = data.UserRole;

                        _context.adminModels.Add(admin);
                    }
                    //_context.SaveChanges();
                    LoginModel login = new LoginModel();
                    login.Email = data.Email;
                    login.Password = data.Password;
                    _context.loginModels.Add(login);
                    _context.SaveChanges();
                    return "User created successfully";









                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string deleteUser(string UserID)
        {
            try
            {
                int userID = Convert.ToInt32(UserID);
                var role = _context.userModels.Where(x => x.UserId == userID).Select(x => x.UserRole).First();
                var data = _context.userModels.Where(x => x.UserId == userID).First();
                role = role.ToLower();
                if (role == "admin")
                {
                    var i = _context.userModels.Find(userID);
                    _context.userModels.Remove(i);
                    var admin = _context.adminModels.Where(x => x.Email == data.Email).First();
                    _context.adminModels.Remove(admin);
                    var login = _context.loginModels.Where(x => x.Email == data.Email).First();
                    _context.loginModels.Remove(login);
                    _context.SaveChanges();
                    return "user deleted";
                }
                else
                {
                    var i = _context.userModels.Find(userID);
                    if (i != null)
                    {
                        var login = _context.loginModels.Where(x => x.Email == data.Email).First();
                        _context.loginModels.Remove(login); 
                        _context.userModels.Remove(i);
                        _context.SaveChanges();
                        return "user deleted";

                    }
                    else
                    {
                        return " deletion failed";
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string editUser(UserModel data)
        {

            var role = _context.userModels.Where(x => x.UserId == data.UserId).Select(y => y.UserRole).First();
            role = role.ToLower();
            if (role == "admin")
            {
                var k = _context.userModels.Find(data.UserId);
                if (k != null)
                {
                    var admin = _context.adminModels.Where(x => x.Email == k.Email).First();
                    var login = _context.loginModels.Where(x => x.Email == k.Email).First();
                    k.MobileNumber = data.MobileNumber;
                    k.UserName = data.UserName;
                    k.Email = data.Email;
                    k.Password = data.Password;


                    k.UserRole = data.UserRole;
                    _context.userModels.Update(k);
                    
                    admin.Email = data.Email;
                    admin.Password = data.Password;
                    admin.MobileNumber = data.MobileNumber;
                    admin.UserRole = data.UserRole;
                    _context.adminModels.Update(admin);
                    
                    login.Email = data.Email;
                    login.Password = data.Password;
                    _context.loginModels.Update(login);
                    _context.SaveChanges();
                    return "User Editted";
                }
                else
                {
                    return "User not edited";
                }

            }
            else
            {

                var i = _context.userModels.Find(data.UserId);
                if (i != null)
                {
                    var login = _context.loginModels.Where(x => x.Email == i.Email).First();
                    i.MobileNumber = data.MobileNumber;
                    i.UserName = data.UserName;
                    i.Email = data.Email;
                    i.Password = data.Password;


                    i.UserRole = data.UserRole;
                    _context.userModels.Update(i);
                    
                    login.Email = data.Email;
                    login.Password = data.Password;
                    _context.loginModels.Update(login);
                    _context.SaveChanges();
                    return "User Editted";
                }
                else
                {
                    return "User not edited";
                }
            }
        }

        public UserModel getUser(string UserID)
        {
            try
            {
                int userID = Convert.ToInt32(UserID);
                var i = _context.userModels.Find(userID);
                if (i != null) {

                    return i;
                
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
