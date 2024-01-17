using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaCRUD.Models;

namespace TareaCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskCRUDContext _context;

        public TaskController(TaskCRUDContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("createTask")]
        public async Task<IActionResult> CreateTaks(Tack tack)
        {
            await _context.Task.AddAsync(tack);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("ListTask")]
        public async Task<ActionResult<IEnumerable<Tack>>>TackList()
        {
            var tuck = await _context.Task.ToListAsync();
            return Ok(tuck);
        }

        [HttpGet]
        [Route("seeTask")]
        public async Task<ActionResult>SeeTask(int id)
        {
            Tack tack = await _context.Task.FindAsync(id);
            if(tack == null)
            {
                return NotFound();
            }
            return Ok(tack);
        }

        [HttpPut]
        [Route("editTask")]
        public async Task<IActionResult> UpdateTask(int id, Tack tack)
        {
            //Actualizar el producto en la base de datos
            var tackExist = await _context.Task.FindAsync(id);
            tackExist!.title = tack.title;
            tackExist.Description = tack.Description;
            tackExist.DateCreation = tack.DateCreation;

            await _context.SaveChangesAsync();

            //devolver un mensaje de exito
            return Ok();
        }

        [HttpDelete]
        [Route("deleteTask")]
        public async Task<IActionResult>DeleteTack(int id)
        {
            var tackDelete = await _context.Task.FindAsync(id);

            _context.Task.Remove(tackDelete!);

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
        