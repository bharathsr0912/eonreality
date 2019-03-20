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

        [HttpGet]
        //[Route("RegisteredUser")]
        public List<UsersBusinessModel> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        //[Route("RegisteredUser")]
        public List<UsersBusinessModel> AddUser([FromBody]UsersBusinessModel userModel)
        {
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