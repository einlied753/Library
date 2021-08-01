using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.DAL.Repositories;
using Library.DAL;
using Library.DAL.Models;

namespace Library.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        private IUserRepo _userRepo;

        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepo = UnitOfWork.GetUserRepo();
        }

        [HttpGet]
        [Route("get/{userId:int}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            User user = await _userRepo.SelectByIdAsync(userId);
            return user == null ? NotFound() : (IActionResult)Ok(user);
        }

        [HttpGet]
        [Route("get_list")]
        public async Task<IActionResult> GetUserListAsync()
        {
            IEnumerable<User> userList = await _userRepo.SelectListAsync();
            return userList.Count() == 0 ? NotFound() : (IActionResult)Ok(userList);
        }

        [HttpGet]
        [Route("get_list_by_name/{userName}")]
        public async Task<IActionResult> GetUserListByNameAsync(string userName)
        {
            IEnumerable<User> users = await _userRepo.SelectListByNameAsync(userName);
            return users.Count() == 0 ? NotFound() : (IActionResult)Ok(users);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody] User newUser)
        {
            User user = await _userRepo.SelectByIdAsync(newUser.Id);
            if (user != null)
            {
                return Conflict();
            }
            else
            {
                _userRepo.Insert(newUser);
                await UnitOfWork.SaveAsync();
                IEnumerable<User> userList = await _userRepo.SelectListAsync();
                return Ok(userList);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditUserAsync(int userId, [FromBody] User changedUser)
        {
            User user = await _userRepo.SelectByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userRepo.Update(changedUser);
                await UnitOfWork.SaveAsync();
                IEnumerable<User> userList = await _userRepo.SelectListAsync();
                return userList.Count() == 0 ? NotFound() : (IActionResult)Ok(userList);
            }
        }

        [HttpDelete]
        [Route("delete_by_fio")]
        public async Task<IActionResult> DeleteUserByFioAsync(string name, string surname, string patronymic)
        {
            User user = await _userRepo.SelectByFioAsync(name.Trim(), surname.Trim(), patronymic.Trim());
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userRepo.Delete(user);
                await UnitOfWork.SaveAsync();
                IEnumerable<User> userList = await _userRepo.SelectListAsync();
                return Ok(userList);
            }

        }

        [HttpDelete]
        [Route("delete_by_id/{userId:int}")]
        public async Task<IActionResult> DeleteUserByIdAsync(int userId)
        {
            User user = await _userRepo.SelectByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userRepo.Delete(user);
                await UnitOfWork.SaveAsync();
                IEnumerable<User> userList = await _userRepo.SelectListAsync();
                return Ok(userList);
            }
        }
    }
}