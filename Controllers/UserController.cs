using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaCRUD.Models;

namespace TareaCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserCRUDContext _context;

        public UserController(UserCRUDContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> CreateTaks(User user)
        {
            await _context.Client.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("ListUser")]
        public async Task<ActionResult<IEnumerable<User>>> UserList()
        {
            var user = await _context.Client.ToListAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("seeUser")]
        public async Task<ActionResult> SeeTask(int id)
        {
            User user = await _context.Client.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut]
        [Route("editUser")]
        public async Task<IActionResult> UpdateTask(int id, User user)
        {
            //Actualizar el producto en la base de datos
            var userExist = await _context.Client.FindAsync(id);
            userExist!.Name = user.Name;
            userExist.Email = user.Email;
            userExist.DateCreation = user.DateCreation;

            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok();
        }

        [HttpDelete]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteTack(int id)
        {
            var userDelete = await _context.Client.FindAsync(id);

            _context.Client.Remove(userDelete!);

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
