using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListEmployeeAPI.Data;
using ListEmployeeAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ListEmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Methoth get all registered user
        /// </summary>
        /// <returns>return list of user</returns>
        [HttpGet]
        public List<UsersBusinessModel> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// Method to add new user
        /// </summary>
        /// <param name="userModel">userModel as Object</param>
        /// <returns>return list of registered users</returns>
        [HttpPost]
        public List<UsersBusinessModel> AddUser([FromBody]UsersBusinessModel userModel)
        {
            userModel.selectedDays = userModel.selectedDays.Substring(1);
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return _context.Users.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}