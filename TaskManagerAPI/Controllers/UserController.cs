using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController (DataContext context)
        {
            _context = context;
        }

        //Register
        //Login
        //Get users

        // GET: /<controller>/


        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(User user )
        {
            var userExist = _context.User.FirstOrDefault(h=>h.Username==user.Username);
            if (userExist == null)
            {
                _context.Add(user);
                _context.SaveChanges();
                return Ok("user registered successfully");
            }
            else
            {
                return Ok("user already exist");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult UserLogin(string username, string password)
        {
            var user = _context.User.FirstOrDefault(h => h.Username == username & h.Password == password);
            if (user == null)
            {
                return Ok("wrong username/password");
            }
            else
            {
                if (user.LoginStat == "Y")
                {
                    return Ok("user already logged in");
                }
                else
                {
                    user.LoginStat = "Y";
                    user.LastLogin = DateTime.Now;
                    _context.User.Update(user);
                    _context.SaveChanges();
                    return Ok("login successful");
                }

            }
        }
        [HttpPost]
        [Route("logout")]
        public IActionResult UserLogout(string username)
        {
            var user = _context.User.FirstOrDefault(h => h.Username == username);
            if (user == null)
            {
                return Ok("user does not exist");
            }
            else
            {
                if (user.LoginStat == "N")
                {
                    return Ok("user already logged out");
                }
                else
                {
                    user.LoginStat = "N";
                    _context.User.Update(user);
                    _context.SaveChanges();
                    return Ok("logout successful");
                }

            }
        }
    }
}

