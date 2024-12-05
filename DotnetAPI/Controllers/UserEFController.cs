
using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.Models;
using DotnetAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("DevCors")]

public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;

    IMapper _mapper;

    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF (config);

        _mapper = new Mapper(new MapperConfiguration (cfg => {
            cfg.CreateMap<UserToAddDto, User>();
        }));

    }
   

    [HttpGet("GetUsers")]

    public IEnumerable<User> GetUsers()
    {        
        IEnumerable<User> users = _entityFramework.Users.ToList<User>();
        return users;
    }


     [HttpGet("GetSingleUsers/{userId}")]

    public User GetSingleUsers(int userId)
    {

        User? user = _entityFramework.Users
            .Where(u => u.UserId == userId)
            .FirstOrDefault<User>();

        if (user != null)
        {
            return user;
        }
        throw new Exception("Failed to Get User");
    }



    [HttpPut("EditUser")]

    public IActionResult EditUser(User user)
    {
        User? userDb = _entityFramework.Users
            .Where(u => u.UserId == user.UserId)
            .FirstOrDefault<User>();

        if (userDb != null)
        {
            userDb.Active = user.Active;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Age = user.Age;
            userDb.UserRole = user.UserRole;
            if (_entityFramework.SaveChanges() >0)
            {
                return Ok();
            }
            throw new Exception("Failed to Update User");
            
        }
        throw new Exception("Failed to Get User");
    }



    [HttpPost ("AddUser")]

    public IActionResult AddtUser(UserToAddDto user)
    {
       User userDb = _mapper.Map<User>(user);

        // userDb.Active = user.Active;
        // userDb.FirstName = user.FirstName;
        // userDb.LastName = user.LastName;
        // userDb.Age = user.Age;
        // userDb.UserRole = user.UserRole;

        _entityFramework.Add(userDb);
        if (_entityFramework.SaveChanges() >0)
        {
            return Ok();
        }
        throw new Exception("Failed to Add User");         
    }



    [HttpDelete ("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
       User? userDb = _entityFramework.Users
            .Where(u => u.UserId == userId)
            .FirstOrDefault<User>();

        if (userDb != null)
        {
            _entityFramework.Users.Remove(userDb);
            if (_entityFramework.SaveChanges() >0)
            {
                return Ok();
            }
            throw new Exception("Failed to Delete User");
            
        }
        throw new Exception("Failed to Get User");
    }
    
}



