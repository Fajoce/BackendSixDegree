using Domain.Data;
using Entities.DTO;
using Infraestructura.Interfaces.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixDegreesItSolutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Properties
        public readonly IUserRepositoryRead _IrepositorioRead;
        public readonly IUserRepositoryWrite _IrepositorioWrite;
        public readonly SDDbContexto _context;
        #endregion Properties

        #region Constructor
        public UsersController(IUserRepositoryRead repositorioread, IUserRepositoryWrite repositoryWrite, SDDbContexto context)
        {
            _IrepositorioRead = repositorioread;
            _IrepositorioWrite = repositoryWrite;
            _context = context;
        }

        #endregion Constructor

        #region Public Methods
        // GET: api/<ProductosController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var res = await _IrepositorioRead.GetAllUsers();
            if (res != null)
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetbyId(int id)
        {
            var res = await _IrepositorioRead.GetuserById(id);
            if (res != null)
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var res = await _IrepositorioWrite.CreateUserAsync(user);
            if (res != null)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UserDTO user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            await _IrepositorioWrite.UpdateUserAsync(user);

            return NoContent();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var res = await _IrepositorioWrite.DeleteUserAsync(id);
            if (res != false)
            {
                return StatusCode(StatusCodes.Status204NoContent, true);
            }
            return StatusCode(StatusCodes.Status404NotFound, false);
        }

        #endregion Public Methods

        #region Private Methods
        //POST LOGIN
        [HttpPost("Logearse")]
        public async Task<IActionResult> Login(LoginDTO usuarios)
        {
            var userAvailable = await _context.Users.Where(u => u.UserName == usuarios.UserName
            && u.password == usuarios.Password).FirstOrDefaultAsync();
            if (userAvailable == null)
            {
                return Ok("Failure");
            }
            else if (userAvailable.TypeOfUserId == 1)
            {
                return Ok("Admin");
            }
            else
            {
                return Ok("Success");
            }
        }
        #endregion Private Methods
    }
}
   

