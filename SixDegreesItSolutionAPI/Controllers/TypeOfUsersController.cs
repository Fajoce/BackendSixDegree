using Entities.DTO;
using Infraestructura.Interfaces.TypeOfUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixDegreesItSolutionServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfUsersController : ControllerBase
    {
        #region Properties
        public readonly ITypeOfUserRepositoryRead _IrepositorioRead;
    
        #endregion Properties

        #region Constructor
        public TypeOfUsersController(ITypeOfUserRepositoryRead repositorioread)
        {
            _IrepositorioRead = repositorioread;
       
        }

        #endregion Constructor

        #region Public Methods
        // GET: api/<ProductosController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<TypeOfUserDTO>>> Get()
        {
            var res = await _IrepositorioRead.GetAllTypeOfUsers();
            if (res != null)
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfUserDTO>> GetbyId(int id)
        {
            var res = await _IrepositorioRead.GetTypeOfuserById(id);
            if (res != null)
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
    #endregion
}
