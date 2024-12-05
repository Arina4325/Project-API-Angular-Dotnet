
namespace DotnetAPI.Dtos
{
    public partial class UserToAddDto
    {
        // public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Age {get; set;}
        public string UserRole {get; set;}
        public bool Active {get; set;}

        public UserToAddDto()
        {
            if (FirstName == null)
            {
                FirstName = "";
            }
            if (LastName == null)
            {
                LastName = "";
            }
            if (UserRole == null)
            {
                UserRole = "";
            }

        }

    }

}