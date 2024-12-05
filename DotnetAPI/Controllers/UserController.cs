
using DotnetAPI.Data;
using DotnetAPI.Models;
using DotnetAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("DevCors")]

public class UserController : ControllerBase
{
    DataContextDapper _dapper;

    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper (config);

    }

    [HttpGet("TestConnection")]

    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers")]

    public IEnumerable<User> GetUsers()
    {
        string sql = @"
            SELECT
                [UserId],
                [FirstName],
                [LastName],
                [Age],
                [UserRole],
                [Active]
            FROM TutorialAppSchema.Users";

        IEnumerable<User> users = _dapper.LoadData<User>(sql);
        return users;
        // string[] responseArray = new string[] {
        //     "test1",
        //     "test2"
            
        // };
    
    // return responseArray;
    }


     [HttpGet("GetSingleUsers/{userId}")]

    public User GetSingleUsers(int userId)
    {
        string sql = @"
            SELECT
                [UserId],
                [FirstName],
                [LastName],
                [Age],
                [UserRole],
                [Active]
            FROM TutorialAppSchema.Users
            WHERE UserId =" + userId.ToString();

        User user = _dapper.LoadDataSingle<User>(sql);
        return user;
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        string sql = @"
        UPDATE TutorialAppSchema.Users
                SET [FirstName] = '"+ user.FirstName +
                "',[LastName] = '"+ user.LastName +
                "',[Age] = "+ user.Age +
                ",[UserRole] = '"+ user.UserRole +
                "',[Active] = '" + user.Active +
            "' WHERE UserId = " + user.UserId;

        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to Update User");
    }

    [HttpPost ("AddUser")]
    public IActionResult AddtUser(UserToAddDto user)
    {
        string sql = @"INSERT INTO TutorialAppSchema.Users(
                [FirstName],
                [LastName],
                [Age],
                [UserRole],
                [Active]
                )
            VALUES ("+
               " '"+ user.FirstName +
                "','"+ user.LastName +
                "',"+ user.Age +
                ", '"+ user.UserRole +
                "','" + user.Active +
            "')";

        Console.WriteLine(sql);
         if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to Add User");
    }

    [HttpDelete ("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        string sql = @"
            DELETE FROM TutorialAppSchema.Users 
                WHERE UserId = " + userId.ToString();

         Console.WriteLine(sql);
         if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to Delete User");
    }
    
}



