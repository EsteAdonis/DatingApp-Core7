using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController: BaseApiController
  {
    public readonly DataContext _context;

    public UsersController(DataContext context)
    {
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> Get()
    {
      var users = await _context.Users.ToListAsync();
      return users;
    }

    [HttpGet("{id}")]
    public ActionResult<AppUser> GetUser(int id)
    {
      var user = _context.Users.Find(id);
      return user;
    }
  }
}